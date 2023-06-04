using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;

namespace HiddenGPT
{
    public partial class MainForm : Form
    {
        private ContextMenu trayMenu = new ContextMenu();
        private InputSimulator inputSimulator = new InputSimulator();
        private static Config config = Config.Load();
        private static bool shouldClose = false;
        private static List<Dictionary<string, string>> context = new List<Dictionary<string, string>>();
        private static IntPtr CurrentHandle = IntPtr.Zero;

        public MainForm()
        {
            InitializeComponent();
            GlobalHotKey.RegisterHotKey(config.HotKey, () => AskGPT());
            this.WindowState = FormWindowState.Minimized;
            this.Hide();

            txtboxAPIKey.Text = config.APIKey;
            txtboxRequestUrl.Text = config.RequestUrl;
            txtboxProxyUrl.Text = config.ProxyUrl;
            txtboxModel.Text = config.Model;
            txtboxSystemMsg.Text = config.SystemMsg;
            numMaxTokens.Value = config.MaxTokens;
            txtboxHotkey.Text = config.HotKey;
            cbProxiedRequests.Checked = config.ProxiedRequests;
            cbRememberContext.Checked = config.RememberContext;
            cbAutoPaste.Checked = config.AutoPaste;
            cbInstantPaste.Checked = config.InstantPaste;

            cbInstantPaste.Enabled = config.AutoPaste;
            txtboxProxyUrl.Enabled = config.ProxiedRequests;

            Dictionary<string, string> systemmsg = new Dictionary<string, string>();
            systemmsg.Add("role", "system");
            systemmsg.Add("content", config.SystemMsg);
            context.Add(systemmsg);

            // when right click on tray icon, show context menu with exit option
            trayMenu.MenuItems.Add("Clear Context", (object sender, EventArgs e) => {
                context.Clear();
                context.Add(systemmsg);
            });
            trayMenu.MenuItems.Add("Hide", (object sender, EventArgs e) => { tray.Visible = false; });
            trayMenu.MenuItems.Add("Exit", (object sender, EventArgs e) => { shouldClose = true; Application.Exit(); });
            try { trayMenu.MenuItems[0].Enabled = config.RememberContext; } catch { } // disable clear context if remember context is disabled

            tray.ContextMenu = trayMenu;
        }

        // GetForegroundWindow
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private void AskGPT()
        {
            try
            {
                CurrentHandle = GetForegroundWindow();
                string clipboardContents = Clipboard.GetText();
                if (!string.IsNullOrWhiteSpace(clipboardContents))
                {
                    string continuation = GetCompletion(clipboardContents);
                    if (string.IsNullOrWhiteSpace(continuation))
                        continuation = "ERROR: No response from API";

                    Clipboard.SetText(continuation);
                    if (config.AutoPaste)
                    {
                        // paste text into the current handle
                        if (CurrentHandle != IntPtr.Zero)
                            try { SetForegroundWindow(CurrentHandle); Thread.Sleep(200); } catch { }

                        if (config.InstantPaste)
                            inputSimulator.Keyboard.ModifiedKeyStroke(WindowsInput.Native.VirtualKeyCode.CONTROL, WindowsInput.Native.VirtualKeyCode.VK_V);
                        else
                        {
                            // simulate typing the text
                            foreach (char c in continuation)
                            {
                                inputSimulator.Keyboard.TextEntry(c);
                                Thread.Sleep(1);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Clipboard.SetText("ERROR: " + ex);
            }
        }

        public static string GetCompletion(string msg)
        {
            var client = new RestClient(config.ProxiedRequests ? config.ProxyUrl : config.RequestUrl);
            var request = new RestRequest("", Method.Post);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", $"Bearer {config.APIKey}");
            request.AddHeader("Request-Url", config.RequestUrl);
            dynamic data = new System.Dynamic.ExpandoObject();
            data.max_tokens = config.MaxTokens;
            data.model = config.Model;

            // if remember context is enabled, add the context to the request
            if (config.RememberContext)
            {
                // add to context array
                Dictionary<string, string> contextmsg = new Dictionary<string, string>();
                contextmsg.Add("role", "user");
                contextmsg.Add("content", msg);
                context.Add(contextmsg);

                data.messages = context;
            }
            else
                data.prompt = msg;

            string datajson = JsonConvert.SerializeObject(data);
            request.AddJsonBody(datajson);
            RestResponse response = client.Execute(request);
            try
            {
                dynamic json = JsonConvert.DeserializeObject(response.Content);

                // if remember context is enabled, add the response to the context
                if (config.RememberContext)
                {
                    string lastmsg = json.choices[0].message.content;
                    Dictionary<string, string> contextmsg = new Dictionary<string, string>();
                    contextmsg.Add("role", "assistant");
                    contextmsg.Add("content", lastmsg);
                    context.Add(contextmsg);
        
                    return lastmsg;
                }
                else
                {
                    return json.choices[0].text;
                }
            }
            catch
            {
                if (response.Content.Contains("\"code\": \"invalid_api_key\"") || response.Content.Contains("https://platform.openai.com/account/api-keys"))
                    return "ERROR: Invalid API Key";

                if (response.Content.Contains("\"message\": \"The model `") && response.Content.Contains("` does not exist\""))
                    return "ERROR: Model '" + config.Model + "' does not exist";

                return "ERROR!\nResponse: " + response.Content;
            }
        }

        private void tray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!shouldClose)
            {
                e.Cancel = true;
                this.Hide();
            }
        }




        // ==================== CONFIG ====================
        private void txtboxAPIKey_TextChanged(object sender, EventArgs e)
        {
            config.APIKey = txtboxAPIKey.Text;
            config.Save();
        }

        private void txtboxRequestUrl_TextChanged(object sender, EventArgs e)
        {
            config.RequestUrl = txtboxRequestUrl.Text;
            config.Save();
        }
        private void txtboxProxyUrl_TextChanged(object sender, EventArgs e)
        {
            config.ProxyUrl = txtboxProxyUrl.Text;
            config.Save();
        }

        private void txtboxModel_TextChanged(object sender, EventArgs e)
        {
            config.Model = txtboxModel.Text;
            config.Save();
        }

        private void numMaxTokens_ValueChanged(object sender, EventArgs e)
        {
            config.MaxTokens = Convert.ToInt32(numMaxTokens.Value);
            config.Save();
        }

        private void txtboxSystemMsg_TextChanged(object sender, EventArgs e)
        {
            config.SystemMsg = txtboxSystemMsg.Text;
            config.Save();

            // replace the system message in the context
            foreach (Dictionary<string, string> msg in context)
            {
                if (msg["role"] == "system")
                    msg["content"] = config.SystemMsg;
            }
        }

        private void txtboxHotkey_TextChanged(object sender, EventArgs e)
        {
            // unregister the old hotkey
            GlobalHotKey.UnregisterAllHotKeys();

            config.HotKey = txtboxHotkey.Text;
            config.Save();

            // update the hotkey
            GlobalHotKey.RegisterHotKey(config.HotKey, () => AskGPT());
        }

        private void cbProxiedRequests_CheckedChanged(object sender, EventArgs e)
        {
            config.ProxiedRequests = cbProxiedRequests.Checked;
            config.Save();

            txtboxProxyUrl.Enabled = config.ProxiedRequests;
        }

        private void cbRememberContext_CheckedChanged(object sender, EventArgs e)
        {
            config.RememberContext = cbRememberContext.Checked;
            try { trayMenu.MenuItems[0].Enabled = config.RememberContext; } catch { }
            config.Save();
        }

        private void cbAutoPaste_CheckedChanged(object sender, EventArgs e)
        {
            config.AutoPaste = cbAutoPaste.Checked;
            config.Save();

            cbInstantPaste.Enabled = config.AutoPaste;
        }

        private void cbInstantPaste_CheckedChanged(object sender, EventArgs e)
        {
            config.InstantPaste = cbInstantPaste.Checked;
            config.Save();
        }
        // ==================== END CONFIG ====================
    }
}
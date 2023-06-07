namespace HiddenGPT
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.txtboxModel = new System.Windows.Forms.TextBox();
            this.txtboxAPIKey = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.lblAPIKey = new System.Windows.Forms.Label();
            this.txtboxHotkey = new System.Windows.Forms.TextBox();
            this.lblHotkey = new System.Windows.Forms.Label();
            this.lblMaxTokens = new System.Windows.Forms.Label();
            this.numMaxTokens = new System.Windows.Forms.NumericUpDown();
            this.cbProxiedRequests = new System.Windows.Forms.CheckBox();
            this.cbRememberContext = new System.Windows.Forms.CheckBox();
            this.lblSystemMsg = new System.Windows.Forms.Label();
            this.txtboxSystemMsg = new System.Windows.Forms.TextBox();
            this.cbAutoPaste = new System.Windows.Forms.CheckBox();
            this.cbInstantPaste = new System.Windows.Forms.CheckBox();
            this.txtboxRequestUrl = new System.Windows.Forms.TextBox();
            this.lblRequestUrl = new System.Windows.Forms.Label();
            this.lblProxyUrl = new System.Windows.Forms.Label();
            this.txtboxProxyUrl = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTokens)).BeginInit();
            this.SuspendLayout();
            // 
            // tray
            // 
            this.tray.Icon = ((System.Drawing.Icon)(resources.GetObject("tray.Icon")));
            this.tray.Text = "Netflix";
            this.tray.Visible = true;
            this.tray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tray_MouseDoubleClick);
            // 
            // txtboxModel
            // 
            this.txtboxModel.Location = new System.Drawing.Point(82, 90);
            this.txtboxModel.Name = "txtboxModel";
            this.txtboxModel.Size = new System.Drawing.Size(127, 20);
            this.txtboxModel.TabIndex = 0;
            this.txtboxModel.TextChanged += new System.EventHandler(this.txtboxModel_TextChanged);
            // 
            // txtboxAPIKey
            // 
            this.txtboxAPIKey.Location = new System.Drawing.Point(82, 12);
            this.txtboxAPIKey.Name = "txtboxAPIKey";
            this.txtboxAPIKey.Size = new System.Drawing.Size(127, 20);
            this.txtboxAPIKey.TabIndex = 1;
            this.txtboxAPIKey.TextChanged += new System.EventHandler(this.txtboxAPIKey_TextChanged);
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(37, 93);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(39, 13);
            this.lblModel.TabIndex = 2;
            this.lblModel.Text = "Model:";
            // 
            // lblAPIKey
            // 
            this.lblAPIKey.AutoSize = true;
            this.lblAPIKey.Location = new System.Drawing.Point(28, 15);
            this.lblAPIKey.Name = "lblAPIKey";
            this.lblAPIKey.Size = new System.Drawing.Size(48, 13);
            this.lblAPIKey.TabIndex = 3;
            this.lblAPIKey.Text = "API Key:";
            // 
            // txtboxHotkey
            // 
            this.txtboxHotkey.Location = new System.Drawing.Point(82, 168);
            this.txtboxHotkey.Name = "txtboxHotkey";
            this.txtboxHotkey.Size = new System.Drawing.Size(127, 20);
            this.txtboxHotkey.TabIndex = 4;
            this.txtboxHotkey.TextChanged += new System.EventHandler(this.txtboxHotkey_TextChanged);
            // 
            // lblHotkey
            // 
            this.lblHotkey.AutoSize = true;
            this.lblHotkey.Location = new System.Drawing.Point(32, 171);
            this.lblHotkey.Name = "lblHotkey";
            this.lblHotkey.Size = new System.Drawing.Size(44, 13);
            this.lblHotkey.TabIndex = 5;
            this.lblHotkey.Text = "Hotkey:";
            // 
            // lblMaxTokens
            // 
            this.lblMaxTokens.AutoSize = true;
            this.lblMaxTokens.Location = new System.Drawing.Point(7, 145);
            this.lblMaxTokens.Name = "lblMaxTokens";
            this.lblMaxTokens.Size = new System.Drawing.Size(69, 13);
            this.lblMaxTokens.TabIndex = 6;
            this.lblMaxTokens.Text = "Max Tokens:";
            // 
            // numMaxTokens
            // 
            this.numMaxTokens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMaxTokens.Location = new System.Drawing.Point(82, 142);
            this.numMaxTokens.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numMaxTokens.Name = "numMaxTokens";
            this.numMaxTokens.Size = new System.Drawing.Size(127, 20);
            this.numMaxTokens.TabIndex = 7;
            this.numMaxTokens.ValueChanged += new System.EventHandler(this.numMaxTokens_ValueChanged);
            // 
            // cbProxiedRequests
            // 
            this.cbProxiedRequests.AutoSize = true;
            this.cbProxiedRequests.Location = new System.Drawing.Point(10, 194);
            this.cbProxiedRequests.Name = "cbProxiedRequests";
            this.cbProxiedRequests.Size = new System.Drawing.Size(109, 17);
            this.cbProxiedRequests.TabIndex = 8;
            this.cbProxiedRequests.Text = "Proxied Requests";
            this.cbProxiedRequests.UseVisualStyleBackColor = true;
            this.cbProxiedRequests.CheckedChanged += new System.EventHandler(this.cbProxiedRequests_CheckedChanged);
            // 
            // cbRememberContext
            // 
            this.cbRememberContext.AutoSize = true;
            this.cbRememberContext.Location = new System.Drawing.Point(10, 217);
            this.cbRememberContext.Name = "cbRememberContext";
            this.cbRememberContext.Size = new System.Drawing.Size(116, 17);
            this.cbRememberContext.TabIndex = 9;
            this.cbRememberContext.Text = "Remember Context";
            this.cbRememberContext.UseVisualStyleBackColor = true;
            this.cbRememberContext.CheckedChanged += new System.EventHandler(this.cbRememberContext_CheckedChanged);
            // 
            // lblSystemMsg
            // 
            this.lblSystemMsg.AutoSize = true;
            this.lblSystemMsg.Location = new System.Drawing.Point(9, 119);
            this.lblSystemMsg.Name = "lblSystemMsg";
            this.lblSystemMsg.Size = new System.Drawing.Size(67, 13);
            this.lblSystemMsg.TabIndex = 10;
            this.lblSystemMsg.Text = "System Msg:";
            // 
            // txtboxSystemMsg
            // 
            this.txtboxSystemMsg.Location = new System.Drawing.Point(82, 116);
            this.txtboxSystemMsg.Name = "txtboxSystemMsg";
            this.txtboxSystemMsg.Size = new System.Drawing.Size(127, 20);
            this.txtboxSystemMsg.TabIndex = 11;
            this.txtboxSystemMsg.TextChanged += new System.EventHandler(this.txtboxSystemMsg_TextChanged);
            // 
            // cbAutoPaste
            // 
            this.cbAutoPaste.AutoSize = true;
            this.cbAutoPaste.Location = new System.Drawing.Point(10, 240);
            this.cbAutoPaste.Name = "cbAutoPaste";
            this.cbAutoPaste.Size = new System.Drawing.Size(78, 17);
            this.cbAutoPaste.TabIndex = 12;
            this.cbAutoPaste.Text = "Auto Paste";
            this.cbAutoPaste.UseVisualStyleBackColor = true;
            this.cbAutoPaste.CheckedChanged += new System.EventHandler(this.cbAutoPaste_CheckedChanged);
            // 
            // cbInstantPaste
            // 
            this.cbInstantPaste.AutoSize = true;
            this.cbInstantPaste.Location = new System.Drawing.Point(94, 240);
            this.cbInstantPaste.Name = "cbInstantPaste";
            this.cbInstantPaste.Size = new System.Drawing.Size(58, 17);
            this.cbInstantPaste.TabIndex = 13;
            this.cbInstantPaste.Text = "Instant";
            this.cbInstantPaste.UseVisualStyleBackColor = true;
            this.cbInstantPaste.CheckedChanged += new System.EventHandler(this.cbInstantPaste_CheckedChanged);
            // 
            // txtboxRequestUrl
            // 
            this.txtboxRequestUrl.Location = new System.Drawing.Point(82, 38);
            this.txtboxRequestUrl.Name = "txtboxRequestUrl";
            this.txtboxRequestUrl.Size = new System.Drawing.Size(127, 20);
            this.txtboxRequestUrl.TabIndex = 14;
            this.txtboxRequestUrl.TextChanged += new System.EventHandler(this.txtboxRequestUrl_TextChanged);
            // 
            // lblRequestUrl
            // 
            this.lblRequestUrl.AutoSize = true;
            this.lblRequestUrl.Location = new System.Drawing.Point(10, 41);
            this.lblRequestUrl.Name = "lblRequestUrl";
            this.lblRequestUrl.Size = new System.Drawing.Size(66, 13);
            this.lblRequestUrl.TabIndex = 15;
            this.lblRequestUrl.Text = "Request Url:";
            // 
            // lblProxyUrl
            // 
            this.lblProxyUrl.AutoSize = true;
            this.lblProxyUrl.Location = new System.Drawing.Point(24, 67);
            this.lblProxyUrl.Name = "lblProxyUrl";
            this.lblProxyUrl.Size = new System.Drawing.Size(52, 13);
            this.lblProxyUrl.TabIndex = 17;
            this.lblProxyUrl.Text = "Proxy Url:";
            // 
            // txtboxProxyUrl
            // 
            this.txtboxProxyUrl.Location = new System.Drawing.Point(82, 64);
            this.txtboxProxyUrl.Name = "txtboxProxyUrl";
            this.txtboxProxyUrl.Size = new System.Drawing.Size(127, 20);
            this.txtboxProxyUrl.TabIndex = 16;
            this.txtboxProxyUrl.TextChanged += new System.EventHandler(this.txtboxProxyUrl_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 263);
            this.Controls.Add(this.lblProxyUrl);
            this.Controls.Add(this.txtboxProxyUrl);
            this.Controls.Add(this.lblRequestUrl);
            this.Controls.Add(this.txtboxRequestUrl);
            this.Controls.Add(this.cbInstantPaste);
            this.Controls.Add(this.cbAutoPaste);
            this.Controls.Add(this.txtboxSystemMsg);
            this.Controls.Add(this.lblSystemMsg);
            this.Controls.Add(this.cbRememberContext);
            this.Controls.Add(this.cbProxiedRequests);
            this.Controls.Add(this.numMaxTokens);
            this.Controls.Add(this.lblMaxTokens);
            this.Controls.Add(this.lblHotkey);
            this.Controls.Add(this.txtboxHotkey);
            this.Controls.Add(this.lblAPIKey);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.txtboxAPIKey);
            this.Controls.Add(this.txtboxModel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Netflix";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTokens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon tray;
        private System.Windows.Forms.TextBox txtboxModel;
        private System.Windows.Forms.TextBox txtboxAPIKey;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.Label lblAPIKey;
        private System.Windows.Forms.TextBox txtboxHotkey;
        private System.Windows.Forms.Label lblHotkey;
        private System.Windows.Forms.Label lblMaxTokens;
        private System.Windows.Forms.NumericUpDown numMaxTokens;
        private System.Windows.Forms.CheckBox cbProxiedRequests;
        private System.Windows.Forms.CheckBox cbRememberContext;
        private System.Windows.Forms.Label lblSystemMsg;
        private System.Windows.Forms.TextBox txtboxSystemMsg;
        private System.Windows.Forms.CheckBox cbAutoPaste;
        private System.Windows.Forms.CheckBox cbInstantPaste;
        private System.Windows.Forms.TextBox txtboxRequestUrl;
        private System.Windows.Forms.Label lblRequestUrl;
        private System.Windows.Forms.Label lblProxyUrl;
        private System.Windows.Forms.TextBox txtboxProxyUrl;
    }
}


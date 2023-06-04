using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiddenGPT
{
    public class Config
    {
        // config.json file containing model name and API key
        public string APIKey { get; set; } = "PASTE API KEY HERE";
        public string RequestUrl { get; set; } = "https://api.openai.com/v1/chat/completions";
        public string ProxyUrl { get; set; } = "https://estate.red/hiddengpt";
        public string Model { get; set; } = "gpt-3.5-turbo";
        public string SystemMsg { get; set; } = "You are the most intelligent person in the world. You can answer any question, however you do not respond to a question you cant answer.";
        public int MaxTokens { get; set; } = 100;
        public string HotKey { get; set; } = "Control + Shift + G";
        public bool ProxiedRequests { get; set; } = true;
        public bool RememberContext { get; set; } = true;
        public bool AutoPaste { get; set; } = true;
        public bool InstantPaste { get; set; } = false;

        // save the config file
        public void Save()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText("config.json", json);
        }

        // load the config file
        public static Config Load()
        {
            if (File.Exists("config.json"))
            {
                string json = File.ReadAllText("config.json");
                return JsonConvert.DeserializeObject<Config>(json);
            }
            else
            {
                return new Config();
            }
        }
    }
}
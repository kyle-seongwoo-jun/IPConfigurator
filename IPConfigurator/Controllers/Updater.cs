using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;

using IPConfigurator.Models;

namespace IPConfigurator.Controllers
{
    public class Updater
    {
        public UpdateInformation GetUpdateInformation()
        {
            bool isOld = false;
            string updateUrl = null;

            try
            {
                using (var client = new WebClient())
                {
                    client.Headers.Add(HttpRequestHeader.UserAgent, "IP Configurator");
                    
                    var json = JObject.Parse(client.DownloadString("https://api.github.com/repos/Nuwanda22/IPConfigurator/releases/latest"));
                    var tag = json["tag_name"].Value<string>();
                    var lastedVersion = new Version(tag.Substring(1));

                    var currentVersion = Assembly.GetExecutingAssembly().GetName().Version;

                    isOld = currentVersion < lastedVersion;
                    updateUrl = json["assets"][0]["browser_download_url"].Value<string>();
                }
            }
            catch { }

            return new UpdateInformation { IsNeedToUpdate = isOld, UpdateUrl = updateUrl };
        }

        public async Task<UpdateInformation> GetUpdateInformationAsync()
        {
            bool isOld = false;
            string updateUrl = null;

            try
            {
                using (var client = new WebClient())
                {
                    client.Headers.Add(HttpRequestHeader.UserAgent, "IP Configurator");

                    var json = JObject.Parse(await client.DownloadStringTaskAsync("https://api.github.com/repos/Nuwanda22/IPConfigurator/releases/latest"));
                    var tag = json["tag_name"].Value<string>();
                    var lastedVersion = new Version(tag.Substring(1));

                    var currentVersion = Assembly.GetExecutingAssembly().GetName().Version;

                    isOld = currentVersion < lastedVersion;
                    updateUrl = json["assets"][0]["browser_download_url"].Value<string>();
                }
            }
            catch { }

            return new UpdateInformation { IsNeedToUpdate = isOld, UpdateUrl = updateUrl };
        }
    }
}

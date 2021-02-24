using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace RPSSeleniumClassGenerator
{
    public class ModelDownloader
    {
        public ModelDownloader()
        {
            BaseFolderPath = Path.Combine(Path.GetTempPath(), "ModelDownloader");
        }
        public string BaseFolderPath;
        public event EventHandler<DownloadedUIMODEL> DownloadedFile;
        public string User { get; set; }
        public string Password { get; set; }
        public string CodCompany { get; set; }
        public string BaseURL { get; set; }
        HttpClientHandler clientHandler;
        HttpClient client;
        internal string GetUIModel(string component, string service)
        {
            var response = client.GetAsync($"clientapi/components/{service}/{component}/download?includeAllPackages=true").Result;
            var result = response.Content.ReadAsStringAsync().Result;
            string temppath = System.IO.Path.GetTempPath();
            DirectoryInfo dirInfo = new DirectoryInfo(Path.Combine(BaseFolderPath, service));
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            string fullfilepath = Path.Combine(dirInfo.FullName, component + ".uimodel");
            File.WriteAllText(fullfilepath,result);
            return fullfilepath;
        }
        
        public bool Init()
        {
            string baseUrl = this.BaseURL;
            if (clientHandler == null)
            {
                clientHandler =
            new HttpClientHandler();
                clientHandler.UseCookies = true;
                clientHandler.CookieContainer = new CookieContainer();
                client = new HttpClient(clientHandler);

                MediaTypeWithQualityHeaderValue contentType =
                new MediaTypeWithQualityHeaderValue("application/json");
                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.BaseAddress = new Uri(baseUrl);
                Login(client);
            }
            return loggedIn;
            
        }
        public void End()
        {
            LogOff(client);            
            client.Dispose();
            clientHandler.Dispose();
            client = null;
            clientHandler = null;
        }
        public System.Collections.Concurrent.ConcurrentBag<string> DownloadedModels { get; set; }
        public List<RPSUIStateModel> AvailableModels { get; set; }
        public void GetAllModels()
        {
            var response = client.GetAsync("clientapi/State").Result;
            var result = response.Content.ReadAsStringAsync().Result;
            AvailableModels = JsonConvert.DeserializeObject<List<RPSUIStateModel>>(result).ToList();
        }
        public void DownloadModels(string service = null, string componentName = null)
        {
            CleanModels();
            DownloadedModels = new System.Collections.Concurrent.ConcurrentBag<string>();
          


            Parallel.ForEach<RPSUIStateModel>(AvailableModels, new Action<RPSUIStateModel>((obj) =>
            {
                bool download = false;
                if (string.IsNullOrEmpty(service))
                {
                    download = true;
                }
                else if (obj.Service.ToUpper() == service.ToUpper())
                {
                    if (string.IsNullOrEmpty(componentName))
                    {
                        download = true;
                    }
                    else
                    {
                        if (obj.Component.ToUpper() == obj.Component.ToUpper())
                        {
                            download = true;
                        }
                    }
                }
                if (download)
                {
                    var model = GetUIModel(obj.Component, obj.Service);
                    DownloadedModels.Add(model);
                    if (DownloadedFile != null)
                    {
                        DownloadedFile(this, new DownloadedUIMODEL { FilePath = model, Component = obj.Component, Service = obj.Service });
                    }
                }
            }));           
        }
        public void CleanModels()
        {
            if (DownloadedModels != null)
            {
                DownloadedModels.ToList().ForEach(f =>
                {
                    if (File.Exists(f))
                    {
                        File.Delete(f);
                    }
                });
                DownloadedModels.Clear();
            }
            else
            {
                string temppath = System.IO.Path.GetTempPath();
                DirectoryInfo dirInfo = new DirectoryInfo(BaseFolderPath);
                if (dirInfo.Exists)
                {
                    var files = dirInfo.GetFiles("*.uimodel", SearchOption.AllDirectories);
                    foreach (var f in files)
                    {
                        f.Delete();
                    }
                }
            }
        }
        bool loggedIn = false;
        private bool Login(HttpClient client)
        {
            string loginData = JsonConvert.SerializeObject(
            new
            {
                codUser = this.User,
                password = this.Password,
                isWindowsLogon = false,
                codCompany = this.CodCompany,
                codSite = "",
                codLanguage = "01",
                basoaClientId = "1@rpsseleniumtool[0]."

            });
            StringContent content = new StringContent(
             loginData, System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync("api/Security/Session/action/RPSLogOn", content).Result;
            if (response.IsSuccessStatusCode)
            {
                loggedIn = true;
                return true;
            }
            else
            {
                loggedIn = false;
                return false;
            }
        }
        private bool LogOff(HttpClient client)
        {
            StringContent content = new StringContent(
            "", System.Text.Encoding.UTF8, "application/json");
            var response = client.PostAsync("api/Security/Session/action/LogOff", content).Result;
            loggedIn = false;
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class DownloadedUIMODEL:EventArgs
    {
        public string FilePath { get; set; }
        public string Service { get; set; }
        public string Component { get; set; }
    }
    public class RPSUIStateModel
    {
        public string Service { get; set; }
        public string Component { get; set; }
        public string MainState { get; set; }        

    }
    public class RPSEntityDefaultState
    {
        public string State { get; set; }
    }
}

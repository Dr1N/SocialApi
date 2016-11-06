using System;
using VkNet;
using VkNet.Exception;

namespace VkApiNS
{
    class VkAgent
    {
        private ulong appID = 5611413;
        private string login = "+380664336054";
        private string password = "expert1025";
        private VkNet.Enums.Filters.Settings scope = VkNet.Enums.Filters.Settings.All;

        private string token;
        private VkApi api;

        public VkAgent() { }

        public VkAgent(ulong app, string login, string password, VkNet.Enums.Filters.Settings scope)
        {
            this.appID = app;
            this.login = login;
            this.password = password;
            this.scope = scope;
        }

        public void Authorize()
        {
            try
            { 
                this.api = new VkApi();
                this.api.Authorize(new ApiAuthParams
                {
                    ApplicationId = this.appID,
                    Login = this.login,
                    Password = this.password,
                    Settings = this.scope,
                });
                this.token = this.api.Token;
                Program.Logger.Trace("Authorization OK! Token: " + this.token);
            }
            catch (VkApiAuthorizationException vka)
            {
                Program.Logger.Error("Authorization", vka);
            }
            catch (VkApiException vkex)
            {
                Program.Logger.Error("VK.NET", vkex);
            }
            catch (Exception ex)
            {
                Program.Logger.Error("Error", ex.Message);
            }
        }
    }
}
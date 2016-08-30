using System;
using System.Windows.Forms;
using NLog;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Exception;

namespace MyVkApi
{
    public partial class frmMain : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private ulong appID = 5611413;
        private string phone = "+380664336054";
        private string password = "expert1025";
        private Settings scope = Settings.All;

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            { 
                var vk = new VkApi();
                vk.Authorize(new ApiAuthParams
                {
                    ApplicationId = appID,
                    Login = phone,
                    Password = password,
                    Settings = scope
                });

                this.Text = "Ok!" + vk.Token;
            }
            catch (VkApiAuthorizationException vka)
            {
                logger.Debug("Authorization", vka);
            }
            catch (VkApiException vkex)
            {
                logger.Debug("VK Error", vkex);
            }
            catch (Exception ex)
            {
                logger.Debug("Error", ex.Message);
            }
        }
    }
}

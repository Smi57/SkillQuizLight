using SkillQuizLight;
using SkillQuizLight.Controllers;
using SkillQuizLight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SkillQuizLightWpf
{
    /// <summary>
    /// Interaction logic for ChgPwd.xaml
    /// </summary>
    public partial class ChgPwd : Window
    {
        string vLastPasswordEncrypted = "";

        public ChgPwd()
        {
            InitializeComponent();
        }

        private void BtnChgPwd_Click(object sender, RoutedEventArgs e)
        {
            string vMsgTmp = "";
            string vOldPasswordEncrypted = "";
            string[] vRes = Program.currentUser.verifUserPassword(OldPwdTbx.Password);
            string vMsg = vRes[0];
            vLastPasswordEncrypted = vRes[1];

            if (vMsg == "")
            {
                if (NewPwdTbx.Password.ToString() != ConfPwdTbx.Password.ToString())
                {
                    vMsgTmp = (string)Application.Current.Resources["MsgPwdConfCorr"];
                    MessageBox.Show(vMsgTmp, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string verrifMsg = Program.currentUser.verifValidPassword(ConfPwdTbx.Password.ToString());
                    if (verrifMsg != "")
                    {
                        vMsgTmp = (string)Application.Current.Resources["MsgPwdMissNum"];
                        verrifMsg = verrifMsg.Replace("[MsgPwdMissNum]", vMsgTmp);
                        vMsgTmp = (string)Application.Current.Resources["MsgPwdMissUpC"];
                        verrifMsg = verrifMsg.Replace("[MsgPwdMissUpC]", vMsgTmp);
                        vMsgTmp = (string)Application.Current.Resources["MsgPwdMissSpeC"];
                        verrifMsg = verrifMsg.Replace("[MsgPwdMissSpeC]", vMsgTmp);
                        vMsgTmp = (string)Application.Current.Resources["MsgPwdMissMin8C"];
                        verrifMsg = verrifMsg.Replace("[MsgPwdMissMin8C]", vMsgTmp);
                        vMsgTmp = (string)Application.Current.Resources["MsgPwdRules"];
                        verrifMsg = vMsgTmp + Environment.NewLine + verrifMsg;
                        MessageBox.Show(verrifMsg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        vOldPasswordEncrypted = Program.currentUser.PasswordEncrypted;
                        Program.currentUser.setPassword(ConfPwdTbx.Password.ToString());
                        Program.currentUser.UpdatePassword(vOldPasswordEncrypted);
                        vMsgTmp = (string)Application.Current.Resources["MsgPwdChg"];
                        MessageBox.Show(vMsgTmp);
                        this.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show(Tools.verifUserPasswordManagement(vMsg));
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

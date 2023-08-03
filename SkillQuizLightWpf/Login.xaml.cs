using SkillQuizLight;
using SkillQuizLight.Controllers;
using SkillQuizLight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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
    /// Interaction logic for Login.xaml
    /// </summary>

    public partial class Login : Window
    {

        string vLastPasswordEncrypted = "";

        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HttpResponseMessage response = Program.client.GetAsync($"api/User/getUserLogin/{LoginTbx.Text}").Result;
            Program.currentUser = response.Content.ReadFromJsonAsync<mUser>().Result;
            if (response.IsSuccessStatusCode & Program.currentUser.Login != null)
            {
                string[] vRes = Program.currentUser.verifUserPassword(PasswordTbx.Password, vLastPasswordEncrypted);
                string vMsg = vRes[0];
                vLastPasswordEncrypted = vRes[1];
                if (vMsg == "")
                {
                    mUser login = new mUser();
                    login.setPassword(Program.cResetPassword);
                    if (vLastPasswordEncrypted == login.PasswordEncrypted)
                    {
                        ChgPwd chgPwd = new ChgPwd();
                        chgPwd.ShowDialog();
                    }
                    else
                    {
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show(Tools.verifUserPasswordManagement(vMsg));
                }
            }
            else
            {
                MessageBox.Show("Login incorrect !");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

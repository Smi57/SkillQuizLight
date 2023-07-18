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

        string LastPasswordEncrypted = "";

        public Login()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            HttpResponseMessage response = Program.client.GetAsync($"api/User/getUserLogin/{LoginTbx.Text}").Result;
            Program.currentUser = response.Content.ReadFromJsonAsync<User>().Result;
            if (response.IsSuccessStatusCode & Program.currentUser.Login != null)
            {
                User login = new User();
                login.setPassword(PasswordTbx.Password);
                // On vérifit que la personne ne fait pas une tentative avec le même mot de passe ou le mot de passe à vide
                if (LastPasswordEncrypted == login.PasswordEncrypted || PasswordTbx.Password == "")
                {
                    MessageBox.Show("Saisir un mot de passe.");
                }
                else
                { 
                    LastPasswordEncrypted = login.PasswordEncrypted;
                    if (Program.currentUser.PasswordEncrypted == login.PasswordEncrypted && Program.currentUser.AccessFailedCount < 5)
                    {
                        Program.currentUser.managAccessFailedCount(true);
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(Program.currentUser.managAccessFailedCount(false, true));
                    }
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

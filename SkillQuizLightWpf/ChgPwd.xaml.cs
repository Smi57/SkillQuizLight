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
        public ChgPwd()
        {
            InitializeComponent();
        }

        private void BtnChgPwd_Click(object sender, RoutedEventArgs e)
        {
            if (NewPwdTbx.Password.ToString() != ConfPwdTbx.Password.ToString())
            {
                MessageBox.Show("Le mot de passe confirmé ne correspond pas.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                string verrifMsg = User.verifValidPassword(ConfPwdTbx.Password.ToString());
                if (verrifMsg != "")
                {
                    MessageBox.Show(verrifMsg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    MessageBox.Show(verrifMsg, "Mot de passe changé.");
                    this.Hide();
                }
            }

        }

    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SkillQuizLight;
using SkillQuizLight.Models;

namespace SkillQuizLightWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Program.client.BaseAddress = new Uri("https://localhost:44315", UriKind.Absolute);
            Program.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Login login = new Login();
            login.ShowDialog();
        }
        private void Navigate(string page)
        {
            MainFrame.Navigate(new Uri(page, UriKind.RelativeOrAbsolute));
        }

        private void AppUser_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate("Pages/PageUser.xaml");
        }

        private void AppMenuStart_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate("Pages/PageHome.xaml");
        }
        private void AppChgPwd_Click(object sender, RoutedEventArgs e)
        {
            ChgPwd chgPwd = new ChgPwd();
            chgPwd.ShowDialog();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Test_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate("Pages/PageTest.xaml");
        }

    }
}

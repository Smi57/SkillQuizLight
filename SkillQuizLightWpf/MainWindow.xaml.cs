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
using System.Windows.Navigation;
using System.Windows.Shapes;
//using SkillQuizLight.Models;

namespace SkillQuizLightWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
            Login login = new Login();
            login.ShowDialog();
        }
        private void Navigate(string page)
        {
            MainFrame.Navigate(new Uri(page, UriKind.RelativeOrAbsolute));
        }

        private void AppUser_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate("Pages/Page1.xaml");
        }

        private void AppMenuStart_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate("Pages/PageHome.xaml");
        }

    }
}

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

        //private void MenuItem_Click(object sender, RoutedEventArgs e)
        //{
        //    client.BaseAddress = new Uri("https://localhost:7216");
        //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //    //HttpResponseMessage response = client.GetAsync("/api/GetUsrs").Result;
            
        //}

        private void AppExit_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate("Pages/Page1.xaml");
        }
    }
}

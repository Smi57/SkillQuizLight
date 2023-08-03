using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
using Microsoft.SqlServer.Server;
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
            Tools.langManagement();
            Login login = new Login();
            login.ShowDialog();
            Tools.langManagement();
            MainWindowRH mainViewCurrent = new MainWindowRH();
            this.Hide();
            mainViewCurrent.ShowDialog();

        }
    }
}

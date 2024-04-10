using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Channels;
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
        bool isDisconnecting = false;

        public MainWindow()
        {
            InitializeComponent();
            if (Program.client.BaseAddress == null)
            {
                Program.client.BaseAddress = new Uri("https://localhost:44315", UriKind.Absolute);
                Program.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            else
            {
                //Application.Current.Shutdown();
                //Program.client.DefaultRequestHeaders.Remove(Program.client.DefaultRequestHeaders.ToString());
                //Program.client.CancelPendingRequests();
                //Program.client.BaseAddress = new Uri("https://localhost:44315");
                //Program.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            Tools.langManagement();
            Login login = new Login();
            login.ShowDialog();
            Tools.langManagement();
            if (Tools.isParmUserTypeRH(Program.currentUser.tParamUserTypeID))
            {
                this.Hide();
                //this.Close();
                this.isDisconnecting = true;
                MainWindowRH mainViewCurrentRH = new MainWindowRH();
                mainViewCurrentRH.Show();//ShowDialog();
            }
            else
            {
                this.Show();
                this.Navigate("PagesUser/PgeExamUser.xaml");
            }
            //login.Close();
            login.Hide();

            //Gestion log
            HttpResponseMessage respParamLog = Program.client.GetAsync($"api/ParamLog/getParamLogID?ptUserID=" +
            $"{Program.currentUser.tUserID}&pNameTypLog={Program.cNmTypLogIsQuestOpenUser}").Result;
            var vListParamLog = respParamLog.Content.ReadFromJsonAsync<IEnumerable<mParamLog_Display>>().Result;
            if (vListParamLog.Count()!=0)
            {
                
                MessageBox.Show("Une connection pendant un examen a été interrompue, un mail a été envoyé à l'assignateur de l'examen," + 
                    " veuillez le contacter en cas de problème récurrant. Sinon vous pouvez reprendre à la questionnaire : " + 
                    vListParamLog.ElementAt(0)._Info02 + " à la question en cours.", "", MessageBoxButton.OK, MessageBoxImage.Error);
                //this.Navigate("pagesUser/PgeQuest.xaml");
                if (Tools.fLauchPgeQuest() && Program.vCurrentPge != "PgeQuest")
                {
                    this.Navigate("pagesUser/PgeQuest.xaml");
                }
            }


        }
        public void Navigate(string page)
        {
            MainFrame.Navigate(new Uri(page, UriKind.RelativeOrAbsolute));
        }

        public void AppMenuStart_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate("PagesUser/PgeExamUser.xaml");
        }

        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            //this.Navigate("pages/PageHome.xaml");
            //Login login = new Login();
            //login.ShowDialog();
            //this.Close();
            //Program.client.CancelPendingRequests();
            this.Navigate("Pages/PageHome.xaml");
            MainWindow mainWindow = new MainWindow();
            //this.Show();
            mainWindow.Show();
            //this.Close();
            mainWindow.isDisconnecting = true;
            mainWindow.Hide();
            this.isDisconnecting = true;
            this.Hide();
        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int vRes = Tools.fQuitApp(this.IsLoaded, this.isDisconnecting,e);
            if (vRes == Program.cCancel)
            {
                this.Navigate("PagesUser/PgeExamUser.xaml");
            }
            else if (vRes == Program.cBlocked)
            {
                if (Tools.fLauchPgeQuest() && Program.vCurrentPge != "PgeQuest")
                {
                    this.Navigate("pagesUser/PgeQuest.xaml");
                }
            }
        }

        private void MainFrame_Loaded(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show(this.IsLoaded.ToString());
           // this.Close();
           // MessageBox.Show(this.IsLoaded.ToString());
        }

    }
}

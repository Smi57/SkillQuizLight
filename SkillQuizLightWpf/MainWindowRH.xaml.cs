﻿using System;
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
    public partial class MainWindowRH : Window
    {
        bool isDisconnecting = false;

        public MainWindowRH()
        {
            InitializeComponent();

            //Program.client.BaseAddress = new Uri("https://localhost:44315", UriKind.Absolute);
            //Program.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Tools.langManagement();
            //Login login = new Login();
            //login.ShowDialog();
            //Tools.langManagement();
        }


        private void Navigate(string page)
        {
            MainFrameRH.Navigate(new Uri(page, UriKind.RelativeOrAbsolute));
        }

        private void AppUser_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate("pages/PageUser.xaml");
        }

        public void AppMenuStart_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate("pages/PageHome.xaml");
        }
        public void AppChgPwd_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate("pages/PageHome.xaml");
            ChgPwd chgPwd = new ChgPwd();
            chgPwd.ShowDialog();
            
        }
        private void Disconnect_Click(object sender, RoutedEventArgs e)
        {
            //this.Navigate("pages/PageHome.xaml");
            //Login login = new Login();
            //login.ShowDialog();
            //this.Hide();
            //this.Close();
            this.Navigate("pages/PageHome.xaml");
            MainWindow mainWindow = new MainWindow();
            //this.Show();
            //Program.client.CancelPendingRequests();
            mainWindow.Show();
            this.isDisconnecting = true;
            this.Close();


        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Test_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate("pages/PgeTest.xaml");
        }
        private void Option_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate("pages/PgeOption.xaml");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int vRes = Tools.fQuitApp(this.IsLoaded, this.isDisconnecting, e);
            if (vRes == Program.cCancel)
            {
                this.Navigate("pages/PageHome.xaml");
            }
        }

        private void Exam_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate("pages/PgeExam.xaml");
        }

        private void Questionnaire_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate("pages/PgeQuestionnaire.xaml");
        }

        private void Question_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate("pages/PgeQuestion.xaml");
        }

        private void Domain_Click(object sender, RoutedEventArgs e)
        {
            this.Navigate("pages/PgeDomain.xaml");
        }
    }
}

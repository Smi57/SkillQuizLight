using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json.Serialization;
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
using Microsoft.AspNetCore.Http;
using SkillQuizLight.Controllers;
using SkillQuizLight.Models;

namespace SkillQuizLightWpf.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        const int StatNone = 0;
        const int StatAdd = 0;
        const int StatUpd = 1;
        const int StatDel = 2;

        int stat = StatAdd;

        HttpClient client = new HttpClient();

        public Page1()
        {

            InitializeComponent();
            client.BaseAddress = new Uri("https://localhost:44315", UriKind.Absolute);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            refreshDataGrid();


        }

        private void refreshDataGrid()
        {
            HttpResponseMessage response = client.GetAsync("/api/Usr/getUsr").Result;
            if (response.IsSuccessStatusCode)
            {
                var UsrList = response.Content.ReadFromJsonAsync<IEnumerable<UsrToShow>>().Result;
                DG1.ItemsSource = UsrList.AsEnumerable();
            }
        }
        private void initTxtbox()
        {
            LoginTxt.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            Email.Text = "";
            Comment.Text = "";
            stat = StatAdd;
        }

        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            HttpResponseMessage response = client.GetAsync("/api/Usr/getUsr").Result;

            if (response.IsSuccessStatusCode)
            {
                UsrToShow RowSelectedTmp = (UsrToShow)DG1.SelectedItem;
                var UsrList = response.Content.ReadFromJsonAsync<IEnumerable<UsrToShow>>().Result;
                UsrToShow usr = UsrList
                                .Where(b => b.LoginTxt == RowSelectedTmp.LoginTxt)
                                .FirstOrDefault();
                LoginTxt.Text = usr.LoginTxt;
                FirstName.Text = usr.FirstName;
                LastName.Text = usr.LastName;
                Email.Text = usr.Email;
                Comment.Text = usr.Comment;
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (stat != StatAdd)
            {
                initTxtbox();
            }
        }

        private async void BtnUpd_Click(object sender, RoutedEventArgs e)
        {
            switch (stat)
            {
                case StatAdd:


                    Usr usrTmp = new Usr();
                    usrTmp.LoginTxt = LoginTxt.Text;
                    usrTmp.FirstName = FirstName.Text;
                    usrTmp.LastName = LastName.Text;
                    usrTmp.Email = Email.Text;
                    usrTmp.Comment = Comment.Text;
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/Usr/postUsr", usrTmp);

                    refreshDataGrid();
                    initTxtbox();

                    break;
            }
        }


    }
}

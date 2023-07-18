using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Unicode;
using System.Windows;
using System.Windows.Controls;
using Microsoft.AspNetCore.Http;
using SkillQuizLight.Controllers;
using SkillQuizLight.Models;
using SkillQuizLight;

namespace SkillQuizLightWpf.Pages
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class PageUser : Page
    {
        const int StatAdd = 0;
        const int StatUpd = 1;
        const int StatDel = 2;

        int stat = StatAdd;

        public PageUser()
        {
            InitializeComponent();
            refreshDataGrid();
        }

        private  void refreshDataGrid()
        {
            HttpResponseMessage response = Program.client.GetAsync("api/User/getUser").Result;
            if (response.IsSuccessStatusCode)
            {
                DG1.ItemsSource = null;
                var userList = response.Content.ReadFromJsonAsync<IEnumerable<UserDisplay>>().Result;
                DG1.ItemsSource = userList.AsEnumerable();
            }
        }
        private void initTxtbox()
        {
            LoginID.Text = "";
            LoginTxt.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            Email.Text = "";
            Comment.Text = "";
            stat = StatAdd;
        }

        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rowSelectedTmp = (UserDisplay)DG1.SelectedItem;
            if (rowSelectedTmp != null & stat != StatDel)
            {
                HttpResponseMessage response = Program.client.GetAsync($"api/User/getUserID/{rowSelectedTmp.tUserID}").Result;
                UserDisplay userFind = response.Content.ReadFromJsonAsync<UserDisplay>().Result;
                if (response.IsSuccessStatusCode & userFind.tUserID != null)
                {
                    LoginID.Text = userFind.tUserID.ToString();
                    LoginTxt.Text = userFind.Login;
                    FirstName.Text = userFind.FirstName;
                    LastName.Text = userFind.LastName;
                    Email.Text = userFind.Email;
                    Comment.Text = userFind.Comment;
                    stat = StatUpd;
                }
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

                    User userTmpAdd = new User(0,
                            LoginTxt.Text,
                            FirstName.Text,
                            LastName.Text,
                            "Bingo",
                            Email.Text,
                            Comment.Text);
                    HttpResponseMessage responseAdd = await Program.client.PostAsJsonAsync("api/User/postUser", userTmpAdd);

                    refreshDataGrid();
                    initTxtbox();

                    MessageBox.Show("Un mot de passe vient d'être envoyé à l'utilisateur par mail.");

                    break;

                case StatUpd:

                    User userTmpUpd = new User(
                            Convert.ToInt32(LoginID.Text),
                            LoginTxt.Text,
                            FirstName.Text,
                            LastName.Text,
                            Email.Text,
                            Comment.Text);
                    HttpResponseMessage responseUpd = await Program.client.PutAsJsonAsync("api/User/putUser", userTmpUpd);

                    refreshDataGrid();
                    initTxtbox();

                    break;
            }
        }

        private async void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            stat = StatDel;

            HttpResponseMessage responseDel = await Program.client.DeleteAsync($"api/User/delUser/{LoginID.Text}");
            refreshDataGrid();
            initTxtbox();
        }

        private void BtnRez_Click(object sender, RoutedEventArgs e)
        {
            refreshDataGrid();
            MessageBox.Show("Un mot de passe vient d'être envoyé à l'utilisateur par mail.");
        }
    }
}

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

        public PageUser()
        {
            InitializeComponent();
            refreshDataGrid();
            Tools.vPageDataProcessingStatus01 = Tools.cStatAdd;
        }

        private void refreshDataGrid()
        {
            HttpResponseMessage response = Program.client.GetAsync("api/User/getUser").Result;
            if (response.IsSuccessStatusCode)
            {
                DG1.ItemsSource = null;
                var userList = response.Content.ReadFromJsonAsync<IEnumerable<mUser_Display>>().Result;
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
            cbxLang.SelectedIndex = 0;
            Tools.vPageDataProcessingStatus01 = Tools.cStatAdd;
        }

        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rowSelectedTmp = (mUser_Display)DG1.SelectedItem;
            if (rowSelectedTmp != null & Tools.vPageDataProcessingStatus01 != Tools.cStatDel)
            {
                HttpResponseMessage response = Program.client.GetAsync($"api/User/getUserID/{rowSelectedTmp._ID}").Result;
                mUser_Display userFind = response.Content.ReadFromJsonAsync<mUser_Display>().Result;
                if (response.IsSuccessStatusCode & userFind._ID != null)
                {
                    LoginID.Text = userFind._ID.ToString();
                    LoginTxt.Text = userFind._Login;
                    FirstName.Text = userFind._First_Name;
                    LastName.Text = userFind._Last_Name;
                    Email.Text = userFind._Email;
                    Comment.Text = userFind._Comment;
                    if (userFind._ID_Lang == null)
                    {   cbxLang.SelectedIndex = 0;}
                    else
                    {   cbxLang.SelectedIndex = (int)userFind._ID_Lang;}

                    Tools.vPageDataProcessingStatus01 = Tools.cStatUpd;
                }
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Tools.vPageDataProcessingStatus01 != Tools.cStatAdd)
            {
                initTxtbox();
            }
        }

        private async void BtnUpd_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTxt.Text == "")
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgToFilData"];
                MessageBox.Show(vMsgTmp); 
            }
            else
            {
                HttpResponseMessage response = Program.client.GetAsync($"api/User/getUserLogin/{LoginTxt.Text}").Result;
                mUser_Display userFind = response.Content.ReadFromJsonAsync<mUser_Display>().Result;
                if (response.IsSuccessStatusCode & userFind._ID != null & userFind._ID.ToString() != LoginID.Text)
                {
                    string vMsgTmp = (string)Application.Current.Resources["MsgExistData"];
                    MessageBox.Show(vMsgTmp);
                }
                else
                {
                    switch (Tools.vPageDataProcessingStatus01)
                    {
                        case Tools.cStatAdd:
                            mUser userTmpAdd = new mUser(0,
                                LoginTxt.Text,
                                FirstName.Text,
                                LastName.Text,
                                Program.cResetPassword,
                                Email.Text,
                                Comment.Text,
                                Convert.ToInt32(cbxLang.SelectedIndex));
                            HttpResponseMessage responseAdd = await Program.client.PostAsJsonAsync("api/User/postUser", userTmpAdd);
                            refreshDataGrid();
                            initTxtbox();
                            break;

                        case Tools.cStatUpd:

                            mUser userTmpUpd = new mUser(
                                Convert.ToInt32(LoginID.Text),
                                LoginTxt.Text,
                                FirstName.Text,
                                LastName.Text,
                                Email.Text,
                                Comment.Text,
                                Convert.ToInt32(cbxLang.SelectedIndex));
                            HttpResponseMessage responseUpd = await Program.client.PutAsJsonAsync("api/User/putUser", userTmpUpd);

                            if (Program.currentUser.tUserID == userTmpUpd.tUserID)
                            {
                                Program.currentUser.ParamLangID = Convert.ToInt32(cbxLang.SelectedIndex);
                                Tools.langManagement();
                            }

                            refreshDataGrid();
                            initTxtbox();
                            break;
                    }
                }
            }
        }

        private async void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTxt.Text == "")
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgDelSelData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                Tools.vPageDataProcessingStatus01 = Tools.cStatDel;

                HttpResponseMessage responseDel = await Program.client.DeleteAsync($"api/User/delUser/{LoginID.Text}");
                refreshDataGrid();
                initTxtbox();
            }   
        }

        private void BtnRez_Click(object sender, RoutedEventArgs e)
        {

            string vMsgTmp = (string)Application.Current.Resources["MsgResetWarn"];
            var vRes = MessageBox.Show(
                        vMsgTmp, "", MessageBoxButton.YesNo);
            if (vRes == MessageBoxResult.Yes)
            {
                var rowSelectedTmp = (mUser_Display)DG1.SelectedItem;
                if (rowSelectedTmp != null & Tools.vPageDataProcessingStatus01 != Tools.cStatDel)
                {
                    HttpResponseMessage response = Program.client.GetAsync($"api/User/getUserLogin/{rowSelectedTmp._Login}").Result;
                    mUser userFind = response.Content.ReadFromJsonAsync<mUser>().Result;
                    if (response.IsSuccessStatusCode & userFind.tUserID != null)
                    {
                        string vOldPassword = userFind.getPassword();
                        userFind.setPassword(Program.cResetPassword);
                        userFind.UpdatePassword(vOldPassword);
                        refreshDataGrid();
                        MessageBox.Show("Mot de passe reseté.");
                    }
                }
            }
        }
        
        private async void BtnUnlocked_Click(object sender, RoutedEventArgs e)
        {
            mUser userTmpUpd = new mUser(
                    Convert.ToInt32(LoginID.Text),
                    LoginTxt.Text,
                    FirstName.Text,
                    LastName.Text,
                    Email.Text,
                    Comment.Text,
                    Convert.ToInt32(cbxLang.SelectedIndex));
            userTmpUpd.AccessFailedCount = 0;
            HttpResponseMessage responseUpd = await Program.client.PutAsJsonAsync("api/User/putUser", userTmpUpd);
            refreshDataGrid();
            initTxtbox();
        }
    }
}

using SkillQuizLight.Models;
using SkillQuizLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using System.Net.Http.Json;

namespace SkillQuizLightWpf.Pages
{
    /// <summary>
    /// Interaction logic for PageTest.xaml
    /// </summary>
    public partial class PgeExam : Page
    {
        public PgeExam()
        {
            InitializeComponent();
            refreshDataGridDom();
            refreshDataGridSub();
            refreshDataGridSubToDom();
            Tools.vPageDataProcessingStatus01 = Tools.cStatAdd;
        }

        private void refreshDataGridDom()
        {
            HttpResponseMessage response = Program.client.GetAsync("api/ExamDomain/getDomain").Result;
            if (response.IsSuccessStatusCode)
            {
                DgDom.ItemsSource = null;
                var vDomainList = response.Content.ReadFromJsonAsync<IEnumerable<mExamDomain_Display>>().Result;
                DgDom.ItemsSource = vDomainList.AsEnumerable();
            }
        }

        private void refreshDataGridSubToDom()
        {
            //HttpResponseMessage response = Program.client.GetAsync("api/User/getUser").Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    DgSubToDom.ItemsSource = null;
            //    var userList = response.Content.ReadFromJsonAsync<IEnumerable<mUserDisplay>>().Result;
            //    DgSubToDom.ItemsSource = userList.AsEnumerable();
            //}
        }

        private void refreshDataGridSub()
        {
            //HttpResponseMessage response = Program.client.GetAsync("api/User/getUser").Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    DgSub.ItemsSource = null;
            //    var userList = response.Content.ReadFromJsonAsync<IEnumerable<mUserDisplay>>().Result;
            //    DgSub.ItemsSource = userList.AsEnumerable();
            //}
        }

        private void initTxtbox()
        {
            Tools.vPageDataProcessingStatus01 = Tools.cStatAdd;
        }


        private void DG1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rowSelectedTmp = (mExamDomain_Display)DgDom.SelectedItem;
            if (rowSelectedTmp != null & Tools.vPageDataProcessingStatus01 != Tools.cStatDel)
            {
                HttpResponseMessage response = Program.client.GetAsync($"api/ExamDomain/getDomainID/{rowSelectedTmp._ID}").Result;
                //mExamDomain vDomainFind
                //vDomainFind.settExamDomainID(response.Content.ReadFromJsonAsync<mExamDomain>().Result.gettExamDomainID());
                string[] vIdTmp = response.Content.ReadFromJsonAsync<string[]>().Result;
                if (response.IsSuccessStatusCode & vIdTmp[0] != "")
                {
                    Tools.vPageDataProcessingStatus01 = Tools.cStatUpd;
                }
            }
        }

        private void BtnDomAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Tools.vPageDataProcessingStatus01 != Tools.cStatAdd)
            {
                initTxtbox();
            }
        }

        private async void BtnDomUpd_Click(object sender, RoutedEventArgs e)
        {
            //if (DomainTxt.Text == "")
            //{
            //    string vMsgTmp = (string)Application.Current.Resources["MsgToFilData"];
            //    MessageBox.Show(vMsgTmp);
            //}
            //else
            //{
            //    HttpResponseMessage response = Program.client.GetAsync($"api/ExamDomain/getDomainDescription/{DomainTxt.Text}").Result;
            //    string[] domainFind = response.Content.ReadFromJsonAsync<string[]>().Result;
            //    if (response.IsSuccessStatusCode & domainFind[0] != null & domainFind[0] != DomainID.Text)
            //    {
            //        string vMsgTmp = (string)Application.Current.Resources["MsgExistData"];
            //        MessageBox.Show(vMsgTmp);
            //    }
            //    else
            //    {
            //        switch (Tools.vPageDataProcessingStatus01)
            //        {
            //            case Tools.cStatAdd:
            //                mExamDomain_Display domainTmpAdd = new mExamDomain_Display();
            //                domainTmpAdd.Description = DomainTxt.Text;
            //                HttpResponseMessage responseAdd = await Program.client.PostAsJsonAsync(
            //                                    $"api/ExamDomain/postDomain/{Program.currentUser.tUserID.Value}", domainTmpAdd);
            //                refreshDataGridDom();
            //                initTxtbox();
            //                break;

            //            case Tools.cStatUpd:

            //                mExamDomain_Display domainTmpUpd = new mExamDomain_Display();
            //                domainTmpUpd.tExamDomainID = Convert.ToInt32(DomainID.Text);
            //                domainTmpUpd.Description = DomainTxt.Text;

            //                HttpResponseMessage responseUpd = await Program.client.PutAsJsonAsync(
            //                                    $"api/ExamDomain/putDomain/{Program.currentUser.tUserID.Value}", domainTmpUpd);
            //                refreshDataGridDom();
            //                initTxtbox();
            //                break;
            //        }
            //    }
            //}
        }

        private async void BtnDomDel_Click(object sender, RoutedEventArgs e)
        {
            //if (DomainTxt.Text == "")
            //{
            //    string vMsgTmp = (string)Application.Current.Resources["MsgDelSelData"];
            //    MessageBox.Show(vMsgTmp);
            //}
            //else
            //{
            //    Tools.vPageDataProcessingStatus01 = Tools.cStatDel;

            //    HttpResponseMessage responseDel = await Program.client.DeleteAsync($"api/ExamDomain/delDomain/{DomainID.Text}");
            //    refreshDataGridDom();
            //    initTxtbox();
            //}
        }

        private void BtnSubAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSubUpd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSubDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSubToDomAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSubToDomDel_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
    public partial class PgeDomain : Page
    {
        public PgeDomain()
        {
            InitializeComponent();
            refreshDataGridDom();
            Tools.vPageDataProcessingStatus01 = Tools.cStatAdd;
            Tools.vPageDataProcessingStatus03 = Tools.cStatAdd;
        }

        private void refreshDataGridDom()
        {
            HttpResponseMessage response = Program.client.GetAsync("api/ExamDomain/getDomain").Result;
            if (response.IsSuccessStatusCode)
            {
                DgDom.ItemsSource = null;
                var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamDomain_Display>>().Result;
                DgDom.ItemsSource = vList.AsEnumerable();
            }
            refreshDataGridSub();
            refreshDataGridSubToDom();
        }

        private void refreshDataGridSubToDom()
        {
            HttpResponseMessage response = Program.client.GetAsync("api/ExamDomain_SubDomain/getDomain_SubDomain").Result;
            if (response.IsSuccessStatusCode)
            {
                DgSubToDom.ItemsSource = null;
                var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamDomain_SubDomain_Display>>().Result;
                DgSubToDom.ItemsSource = vList.AsEnumerable();
            }
        }

        private void refreshDataGridSub()
        {
            HttpResponseMessage response = Program.client.GetAsync("api/ExamSubDomain/getSubDomain").Result;
            if (response.IsSuccessStatusCode)
            {
                DgSub.ItemsSource = null;
                var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamSubDomain_Display>>().Result;
                DgSub.ItemsSource = vList.AsEnumerable();
            }
        }

        private void initTxtbox()
        {
            DomainID.Text = "";
            DomainTxt.Text = "";
            Tools.vPageDataProcessingStatus01 = Tools.cStatAdd;
        }

        private void initTxtboxSub()
        {
            SubDomainID.Text = "";
            SubDomainTxt.Text = "";
            Tools.vPageDataProcessingStatus03 = Tools.cStatAdd;
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
                    DomainID.Text = vIdTmp[0];
                    DomainTxt.Text = vIdTmp[1];
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
            if (DomainTxt.Text == "")
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgToFilData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                HttpResponseMessage response = Program.client.GetAsync($"api/ExamDomain/getDomainDescription/{DomainTxt.Text}").Result;
                string[] domainFind = response.Content.ReadFromJsonAsync<string[]>().Result;
                if (response.IsSuccessStatusCode & domainFind[0] != null & domainFind[0] != DomainID.Text)
                {
                    string vMsgTmp = (string)Application.Current.Resources["MsgExistData"];
                    MessageBox.Show(vMsgTmp);
                }
                else
                {
                    switch (Tools.vPageDataProcessingStatus01)
                    {
                        case Tools.cStatAdd:
                            mExamDomain_Display domainTmpAdd = new mExamDomain_Display();
                            domainTmpAdd._Description = DomainTxt.Text;
                            HttpResponseMessage responseAdd = await Program.client.PostAsJsonAsync(
                                                $"api/ExamDomain/postDomain/{Program.currentUser.tUserID.Value}", domainTmpAdd);
                            refreshDataGridDom();
                            initTxtbox();
                            break;

                        case Tools.cStatUpd:

                            mExamDomain_Display domainTmpUpd = new mExamDomain_Display();
                            domainTmpUpd._ID = Convert.ToInt32(DomainID.Text);
                            domainTmpUpd._Description = DomainTxt.Text;

                            HttpResponseMessage responseUpd = await Program.client.PutAsJsonAsync(
                                                $"api/ExamDomain/putDomain/{Program.currentUser.tUserID.Value}", domainTmpUpd);
                            refreshDataGridDom();
                            initTxtbox();
                            break;
                    }
                }
            }
        }

        private async void BtnDomDel_Click(object sender, RoutedEventArgs e)
        {
            if (DomainID.Text == "")
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgDelSelData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                Tools.vPageDataProcessingStatus01 = Tools.cStatDel;

                HttpResponseMessage responseDel = await Program.client.DeleteAsync($"api/ExamDomain/delDomain/{DomainID.Text}");
                refreshDataGridDom();
                initTxtbox();
            }
        }

        private void BtnSubAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Tools.vPageDataProcessingStatus03 != Tools.cStatAdd)
            {
                initTxtboxSub();
            }
        }

        private async void BtnSubUpd_Click(object sender, RoutedEventArgs e)
        {
            if (SubDomainTxt.Text == "")
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgToFilData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                HttpResponseMessage response = Program.client.GetAsync($"api/ExamSubDomain/getSubDomainDescription/{SubDomainTxt.Text}").Result;
                string[] domainSubFind = response.Content.ReadFromJsonAsync<string[]>().Result;
                if (response.IsSuccessStatusCode & domainSubFind[0] != null & domainSubFind[0] != SubDomainID.Text)
                {
                    string vMsgTmp = (string)Application.Current.Resources["MsgExistData"];
                    MessageBox.Show(vMsgTmp);
                }
                else
                {
                    switch (Tools.vPageDataProcessingStatus03)
                    {
                        case Tools.cStatAdd:
                            mExamSubDomain_Display domainSubTmpAdd = new mExamSubDomain_Display();
                            domainSubTmpAdd._Description = SubDomainTxt.Text;
                            HttpResponseMessage responseAdd = await Program.client.PostAsJsonAsync(
                                                $"api/ExamSubDomain/postSubDomain/{Program.currentUser.tUserID.Value}", domainSubTmpAdd);
                            refreshDataGridDom();
                            initTxtboxSub();
                            break;

                        case Tools.cStatUpd:

                            mExamSubDomain_Display domainSubTmpUpd = new mExamSubDomain_Display();
                            domainSubTmpUpd._ID = Convert.ToInt32(SubDomainID.Text);
                            domainSubTmpUpd._Description = SubDomainTxt.Text;

                            HttpResponseMessage responseUpd = await Program.client.PutAsJsonAsync(
                                                $"api/ExamSubDomain/putSubDomain/{Program.currentUser.tUserID.Value}", domainSubTmpUpd);
                            refreshDataGridDom();
                            initTxtboxSub();
                            break;
                    }
                }
            }
        }

        private async void BtnSubDel_Click(object sender, RoutedEventArgs e)
        {
            if (SubDomainTxt.Text == "")
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgDelSelData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                Tools.vPageDataProcessingStatus03 = Tools.cStatDel;

                HttpResponseMessage responseDel = await Program.client.DeleteAsync($"api/ExamSubDomain/delSubDomain/{SubDomainID.Text}");
                refreshDataGridDom();
                initTxtboxSub();
            }
        }

        private async void BtnSubToDomAdd_Click(object sender, RoutedEventArgs e)
        {
            var rowSelectedTmpDgDom = (mExamDomain_Display)DgDom.SelectedItem;
            var rowSelectedTmpDgSub = (mExamSubDomain_Display)DgSub.SelectedItem;
            if (rowSelectedTmpDgSub._ID == null || rowSelectedTmpDgDom._ID == null)
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgToFilData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                int vExamDomainID = Convert.ToInt32(rowSelectedTmpDgDom._ID);
                int vExamSubDomainID = Convert.ToInt32(rowSelectedTmpDgSub._ID);
                HttpResponseMessage response = Program.client.GetAsync($"api/ExamDomain_SubDomain/getDomain_SubDomainIDs?pExamDomainID={vExamDomainID}&pExamSubDomainID={vExamSubDomainID}").Result;
                bool domain_SubDomainFind = response.Content.ReadFromJsonAsync<bool>().Result;
                if (response.IsSuccessStatusCode & domain_SubDomainFind)
                {
                    string vMsgTmp = (string)Application.Current.Resources["MsgExistData"];
                    MessageBox.Show(vMsgTmp);
                }
                else
                {

                    mExamDomain_SubDomain_Display domain_SubDomainTmpAdd = new mExamDomain_SubDomain_Display();
                    domain_SubDomainTmpAdd._ID_Domain = vExamDomainID;
                    domain_SubDomainTmpAdd._ID_Sub_Domain = vExamSubDomainID;
                    HttpResponseMessage responseAdd = await Program.client.PostAsJsonAsync(
                                        $"api/ExamDomain_SubDomain/postDomain_SubDomain/{Program.currentUser.tUserID.Value}", domain_SubDomainTmpAdd);
                    refreshDataGridDom();
                    initTxtbox();

                }
            }

        }

        private async void BtnSubToDomDel_Click(object sender, RoutedEventArgs e)
        {
            var rowSelectedTmpDgSubToDom = (mExamDomain_SubDomain_Display)DgSubToDom.SelectedItem;
            var vExamDomain_SubDomainID = rowSelectedTmpDgSubToDom._ID;
            if (vExamDomain_SubDomainID == null)
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgDelSelData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                HttpResponseMessage responseDel = await Program.client.DeleteAsync($"api/ExamDomain_SubDomain/delDomain_SubDomain/{vExamDomain_SubDomainID}");
                refreshDataGridDom();
                initTxtbox();
            }
        }

        private void DG3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rowSelectedTmp = (mExamSubDomain_Display)DgSub.SelectedItem;
            if (rowSelectedTmp != null & Tools.vPageDataProcessingStatus03 != Tools.cStatDel)
            {
                HttpResponseMessage response = Program.client.GetAsync($"api/ExamSubDomain/getSubDomainID/{rowSelectedTmp._ID}").Result;
                //mExamDomain vDomainFind
                //vDomainFind.settExamDomainID(response.Content.ReadFromJsonAsync<mExamDomain>().Result.gettExamDomainID());
                string[] vIdTmp = response.Content.ReadFromJsonAsync<string[]>().Result;
                if (response.IsSuccessStatusCode & vIdTmp[0] != "")
                {
                    SubDomainID.Text = vIdTmp[0];
                    SubDomainTxt.Text = vIdTmp[1];
                    Tools.vPageDataProcessingStatus03 = Tools.cStatUpd;
                }
            }
        }
    }
}

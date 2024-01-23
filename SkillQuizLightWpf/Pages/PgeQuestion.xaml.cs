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
using Azure;

namespace SkillQuizLightWpf.Pages
{
    /// <summary>
    /// Interaction logic for PageTest.xaml
    /// </summary>
    public partial class PgeQuestion : Page
    {
        public PgeQuestion()
        {
            InitializeComponent();
            refreshDataGridQuest();
            refreshCbxDom();
            refreshCbxSubDom();
            Tools.vPageDataProcessingStatus01 = Tools.cStatAdd;
            Tools.vPageDataProcessingStatus03 = Tools.cStatAdd;
        }

        private void refreshDataGridQuest()
        {
            HttpResponseMessage response = Program.client.GetAsync("api/ExamQuestion/getQuestion").Result;
            if (response.IsSuccessStatusCode)
            {
                DgQuest.ItemsSource = null;
                var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamQuestion_Display>>().Result;
                DgQuest.ItemsSource = vList.AsEnumerable();
                refreshDataGridAnswToQuest();
            }
        }

        private void refreshDataGridAnswToQuest()
        {
            var rowSelectedTmp = (mExamQuestion_Display)DgQuest.SelectedItem;
            if (rowSelectedTmp != null)
            {
                //int vTmp = Convert.ToInt32(QuestionID.Text);
                //rowSelectedTmp._ID
                HttpResponseMessage response = Program.client.GetAsync($"api/ExamQuestion_Answer/getQuestion_Answer_QuestionID/{rowSelectedTmp._ID}").Result;
                if (response.IsSuccessStatusCode)
                {
                    DgAnswToQuest.ItemsSource = null;
                    var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamQuestion_Answer_Display>>().Result;
                    DgAnswToQuest.ItemsSource = vList.AsEnumerable();
                }
            }
        }

        private void refreshCbxDom()
        {
            HttpResponseMessage response = Program.client.GetAsync("api/ExamDomain/getDomain").Result;
            if (response.IsSuccessStatusCode)
            {
                CbxDom.ItemsSource = null;
                var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamDomain_Display>>().Result;
                //CbxDom.ItemsSource = vList.Select( x => { x._Description, x._ID }).ToArray();
                CbxDom.ItemsSource = vList.AsEnumerable();
                CbxDom.DisplayMemberPath = "_Description";
                CbxDom.SelectedValuePath = "_ID";
            }
        }

        private void refreshCbxSubDom()
        {
            HttpResponseMessage response = Program.client.GetAsync("api/ExamSubDomain/getSubDomain").Result;
            if (response.IsSuccessStatusCode)
            {
                CbxSubDom.ItemsSource = null;
                var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamSubDomain_Display>>().Result;
                CbxSubDom.ItemsSource = vList.AsEnumerable();
                CbxSubDom.DisplayMemberPath = "_Description";
                CbxSubDom.SelectedValuePath = "_ID";
            }
        }

        private void initTxtbox()
        {
            QuestionID.Text = "";
            QuestionTxt.Text = "";
            CbxLevel.Text = "";
            CbxDom.Text = "";
            CbxSubDom.Text = "";
            TbxTime.Text = "";
            TbxWeight.Text = "";
            TbxCmt.Text = "";
            Tools.vPageDataProcessingStatus01 = Tools.cStatAdd;
            initTxtboxAnsw();
        }

        private void initTxtboxAnsw()
        {
            TbxAnswID.Text = "";
            SbxAnswOk.IsChecked = false;
            TbxAnsw.Text = "";
            Tools.vPageDataProcessingStatus03 = Tools.cStatAdd;
        }

        private void DgQuest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rowSelectedTmp = (mExamQuestion_Display)DgQuest.SelectedItem;
            if (rowSelectedTmp != null & Tools.vPageDataProcessingStatus01 != Tools.cStatDel)
            {
                HttpResponseMessage response = Program.client.GetAsync($"api/ExamQuestion/getQuestionID/{rowSelectedTmp._ID}").Result;
                string[] vIdTmp = response.Content.ReadFromJsonAsync<string[]>().Result;
                if (response.IsSuccessStatusCode & vIdTmp[0] != "")
                {
                    QuestionID.Text = vIdTmp[0];
                    QuestionTxt.Text = vIdTmp[1];
                    TbxTime.Text = vIdTmp[2];
                    TbxWeight.Text = vIdTmp[3];
                    TbxCmt.Text = vIdTmp[4];
                    CbxLevel.Text = vIdTmp[5];
                    CbxDom.SelectedValue = vIdTmp[6];
                    CbxSubDom.SelectedValue = vIdTmp[7];
                    Tools.vPageDataProcessingStatus01 = Tools.cStatUpd;
                    refreshDataGridAnswToQuest();
                }
            }
        }

        private void DgAnswToQuest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rowSelectedTmp = (mExamQuestion_Answer_Display)DgAnswToQuest.SelectedItem;
            if (rowSelectedTmp != null & Tools.vPageDataProcessingStatus03 != Tools.cStatDel)
            {
                TbxQuest_AnswID.Text = rowSelectedTmp._ID.ToString();
                HttpResponseMessage response = Program.client.GetAsync($"api/ExamAnswer/getAnswerID/{rowSelectedTmp._ID_Answer}").Result;
                string[] vIdTmp = response.Content.ReadFromJsonAsync<string[]>().Result;
                if (response.IsSuccessStatusCode & vIdTmp[0] != "")
                {
                    TbxAnswID.Text = vIdTmp[0];
                    if (vIdTmp[1] == "True")
                    {
                        SbxAnswOk.IsChecked = true;
                    }
                    else
                    {
                        SbxAnswOk.IsChecked = false;
                    }
                    TbxAnsw.Text = vIdTmp[2];
                    Tools.vPageDataProcessingStatus03 = Tools.cStatUpd;
                }
            }
        }

        private void BtnQuestAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Tools.vPageDataProcessingStatus01 != Tools.cStatAdd)
            {
                initTxtbox();
            }
        }

        private async void BtnQuestUpd_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionTxt.Text == "")
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgToFilData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {

                switch (Tools.vPageDataProcessingStatus01)
                {
                    case Tools.cStatAdd:
                        mExamQuestion_Display ObjTmpAdd = new mExamQuestion_Display();
                        ObjTmpAdd._Description = QuestionTxt.Text;
                        ObjTmpAdd._ID_Level_Question = Convert.ToInt32(CbxLevel.Text);
                        ObjTmpAdd._Time = Convert.ToInt32(TbxTime.Text);
                        ObjTmpAdd._Weight = Convert.ToInt32(TbxWeight.Text);
                        ObjTmpAdd._Comment= TbxCmt.Text;
                        ObjTmpAdd._ID_Domain = Convert.ToInt32(CbxDom.SelectedValue.ToString());
                        ObjTmpAdd._ID_Sub_Domain = Convert.ToInt32(CbxSubDom.SelectedValue.ToString());

                        HttpResponseMessage responseAdd = await Program.client.PostAsJsonAsync(
                                            $"api/ExamQuestion/postQuestion/{Program.currentUser.tUserID.Value}", ObjTmpAdd);
                        refreshDataGridQuest();
                        initTxtbox();
                        break;

                    case Tools.cStatUpd:

                        mExamQuestion_Display QuestionTmpUpd = new mExamQuestion_Display();
                        QuestionTmpUpd._ID = Convert.ToInt32(QuestionID.Text);
                        QuestionTmpUpd._Description = QuestionTxt.Text;
                        QuestionTmpUpd._ID_Level_Question = Convert.ToInt32(CbxLevel.Text);
                        QuestionTmpUpd._Time = Convert.ToInt32(TbxTime.Text);
                        QuestionTmpUpd._Weight = Convert.ToInt32(TbxWeight.Text);
                        QuestionTmpUpd._Comment = TbxCmt.Text;
                        QuestionTmpUpd._ID_Domain = Convert.ToInt32(CbxDom.SelectedValue.ToString());
                        QuestionTmpUpd._ID_Sub_Domain = Convert.ToInt32(CbxSubDom.SelectedValue.ToString());

                        HttpResponseMessage responseUpd = await Program.client.PutAsJsonAsync(
                                            $"api/ExamQuestion/putQuestion/{Program.currentUser.tUserID.Value}", QuestionTmpUpd);
                        refreshDataGridQuest();
                        initTxtbox();
                        break;
                }
            }
        }

        private async void BtnQuestDel_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionID.Text == "")
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgDelSelData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                Tools.vPageDataProcessingStatus01 = Tools.cStatDel;

                HttpResponseMessage responseDel = await Program.client.DeleteAsync($"api/ExamQuestion/delQuestion/{QuestionID.Text}");
                refreshDataGridQuest();
                initTxtbox();
            }
        }


        private void BtnAnswAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Tools.vPageDataProcessingStatus03 != Tools.cStatAdd)
            {
                initTxtboxAnsw();
            }
        }

        private async void BtnAnswUpd_Click(object sender, RoutedEventArgs e)
        {
            if (QuestionID.Text == "")
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgToFilData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                    switch (Tools.vPageDataProcessingStatus03)
                    {
                        case Tools.cStatAdd:
                            mExamAnswer_Display ObjTmpAdd = new mExamAnswer_Display();
                            ObjTmpAdd._Description = TbxAnsw.Text;
                            if (SbxAnswOk.IsChecked.Value)
                            {
                                ObjTmpAdd._IsAnswerOk = true;
                            }
                            else
                            {
                                ObjTmpAdd._IsAnswerOk = false;
                            }
                            HttpResponseMessage responseAdd = await Program.client.PostAsJsonAsync(
                                                $"api/ExamAnswer/postAnswer/{Program.currentUser.tUserID.Value}", ObjTmpAdd);
                            TbxAnswID.Text = responseAdd.Content.ReadFromJsonAsync<int>().Result.ToString();

                            mExamQuestion_Answer_Display ObjTmpAdd2 = new mExamQuestion_Answer_Display();
                            ObjTmpAdd2._ID_Question = Convert.ToInt32(QuestionID.Text);
                            ObjTmpAdd2._ID_Answer = Convert.ToInt32(TbxAnswID.Text);
                            HttpResponseMessage responseAdd2 = await Program.client.PostAsJsonAsync(
                                                $"api/ExamQuestion_Answer/postQuestion_Answer/{Program.currentUser.tUserID.Value}", ObjTmpAdd2);
                            refreshDataGridAnswToQuest();
                            initTxtboxAnsw();

                            break;
                        
                        case Tools.cStatUpd:

                            mExamAnswer_Display ObjTmpUpd = new mExamAnswer_Display();
                            ObjTmpUpd._ID = Convert.ToInt32(TbxAnswID.Text);
                            ObjTmpUpd._Description = TbxAnsw.Text;
                            if (SbxAnswOk.IsChecked.Value)
                            {
                                ObjTmpUpd._IsAnswerOk = true;
                            }
                            else
                            {
                                ObjTmpUpd._IsAnswerOk = false;
                            }
                            HttpResponseMessage responseUpd = await Program.client.PutAsJsonAsync(
                                                $"api/ExamAnswer/putAnswer/{Program.currentUser.tUserID.Value}", ObjTmpUpd);
                            refreshDataGridAnswToQuest();
                            initTxtboxAnsw();
                            break;
                    }
            }
        }

        private async void BtnAnswDel_Click(object sender, RoutedEventArgs e)
        {
            if (TbxAnswID.Text == "")
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgDelSelData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                Tools.vPageDataProcessingStatus03 = Tools.cStatDel;

                HttpResponseMessage responseDel1 = await Program.client.DeleteAsync($"api/ExamQuestion_Answer/delQuestion_Answer/{TbxQuest_AnswID.Text}");
                refreshDataGridQuest();
                initTxtboxAnsw();

                HttpResponseMessage responseDel2 = await Program.client.DeleteAsync($"api/ExamAnswer/delAnswer/{TbxAnswID.Text}");
                refreshDataGridQuest();
                initTxtboxAnsw();
            }
        }

    }
}

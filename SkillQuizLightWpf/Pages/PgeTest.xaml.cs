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
using Azure.Core;

namespace SkillQuizLightWpf.Pages
{
    /// <summary>
    /// Interaction logic for PageTest.xaml
    /// </summary>
    public partial class PgeTest : Page
    {
        public PgeTest()
        {
            InitializeComponent();
            refreshDgdTest();
            refreshDgdQuestionnaire();
            refreshCbxDom();
            refreshCbxSubDom();
            refreshCbxDomFilter();
            refreshCbxSubDomFilter();
            Tools.vPageDataProcessingStatus01 = Tools.cStatAdd;
            Tools.vPageDataProcessingStatus02 = Tools.cStatAdd;
        }

        private void refreshDgdTest()
        {
            DgdTest.ItemsSource = null;

            HttpResponseMessage response = Program.client.GetAsync("api/ExamTest/getTest").Result;
            if (response.IsSuccessStatusCode)
            {
                var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamTest_Display>>().Result;
                DgdTest.ItemsSource = vList.AsEnumerable();
            }
            refreshDgdTest_Questionnaire();
        }

        private void refreshDgdQuestionnaire()
        {
            DgdQuestionnaire.ItemsSource = null;

            HttpResponseMessage response = Program.client.GetAsync("api/ExamQuestionnaire/getQuestionnaire").Result;
            if (response.IsSuccessStatusCode)
            {
                var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamQuestionnaire_Display>>().Result;
                DgdQuestionnaire.ItemsSource = vList.AsEnumerable();
            }
        }

        private void refreshDgdTest_Questionnaire()
        {
            DgdTest_Questionnaire.ItemsSource = null;

            TbxQuestionnaireID.Text = "";
            TbxQuestionnaireDesc.Text = "";
            var rowSelectedTmp = (mExamTest_Display)DgdTest.SelectedItem;
            if (rowSelectedTmp != null)
            {
                HttpResponseMessage response = Program.client.GetAsync(
                    $"api/ExamTest_Questionnaire/getTest_Questionnaire_TestID/{rowSelectedTmp._ID}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamTest_Questionnaire_Display>>().Result;
                    DgdTest_Questionnaire.ItemsSource = vList.AsEnumerable();
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


        private void refreshCbxDomFilter()
        {
            HttpResponseMessage response = Program.client.GetAsync("api/ExamDomain/getDomain").Result;
            if (response.IsSuccessStatusCode)
            {
                CbxDomFilter.ItemsSource = null;
                var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamDomain_Display>>().Result;
                //CbxDom.ItemsSource = vList.Select( x => { x._Description, x._ID }).ToArray();
                CbxDomFilter.ItemsSource = vList.AsEnumerable();
                CbxDomFilter.DisplayMemberPath = "_Description";
                CbxDomFilter.SelectedValuePath = "_ID";
            }
        }

        private void refreshCbxSubDomFilter()
        {
            HttpResponseMessage response = Program.client.GetAsync("api/ExamSubDomain/getSubDomain").Result;
            if (response.IsSuccessStatusCode)
            {
                CbxSubDomFilter.ItemsSource = null;
                var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamSubDomain_Display>>().Result;
                CbxSubDomFilter.ItemsSource = vList.AsEnumerable();
                CbxSubDomFilter.DisplayMemberPath = "_Description";
                CbxSubDomFilter.SelectedValuePath = "_ID";
            }
        }

        private void initTxtbox()
        {
            CbxDom.Text = "";
            CbxSubDom.Text = "";
            TbxID.Text = string.Empty;
            TbxDescription.Text = "";
            TbxNbQuestion.Text = "";
            TbxTotTime.Text = "";
            TbxTotPts.Text = "";
            TbxCmt.Text = "";
            Tools.vPageDataProcessingStatus01 = Tools.cStatAdd;
        }


        private void DgdTest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rowSelectedTmp = (mExamTest_Display)DgdTest.SelectedItem;
            if (rowSelectedTmp != null & Tools.vPageDataProcessingStatus01 != Tools.cStatDel)
            {
                HttpResponseMessage response = Program.client.GetAsync($"api/ExamTest/getTestID/{rowSelectedTmp._ID}").Result;
                string[] vIdTmp = response.Content.ReadFromJsonAsync<string[]>().Result;
                if (response.IsSuccessStatusCode & vIdTmp[0] != "")
                {
                    TbxID.Text = vIdTmp[0];
                    TbxDescription.Text = vIdTmp[1];
                    if (vIdTmp[2] == "False")
                    {
                        SbxChrono.IsChecked = true;
                    }
                    else
                    {
                        SbxChrono.IsChecked = false;
                    }
                    TbxNbQuestion.Text = vIdTmp[3];
                    TbxTotTime.Text = vIdTmp[4];
                    TbxTotPts.Text = vIdTmp[5];
                    CbxDom.Text = vIdTmp[6];
                    CbxSubDom.Text = vIdTmp[7];
                    TbxCmt.Text = vIdTmp[8];
                    Tools.vPageDataProcessingStatus01 = Tools.cStatUpd;
                    refreshDgdTest_Questionnaire();
                }
            }
        }

        private void DgdTest_Questionnaire_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refreshDgdQuestionnaire();
        }

        private void DgdQuestionnaire_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rowSelectedTmp = (mExamQuestionnaire_Display)DgdQuestionnaire.SelectedItem;
            if (rowSelectedTmp != null)
            {
                TbxQuestionnaireID.Text = rowSelectedTmp._ID.ToString();
                TbxQuestionnaireDesc.Text = rowSelectedTmp._Description;
            }
        }

        private void BtnTestAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Tools.vPageDataProcessingStatus01 != Tools.cStatAdd)
            {
                initTxtbox();
            }
        }

        private async void BtnTestUpd_Click(object sender, RoutedEventArgs e)
        {
            if (TbxDescription.Text == "")
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgToFilData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {

                switch (Tools.vPageDataProcessingStatus01)
                {
                    case Tools.cStatAdd:
                        mExamTest_Display oTmpAdd = new mExamTest_Display();
                        oTmpAdd._Description = TbxDescription.Text;
                        if (SbxChrono.IsChecked.Value)
                        {
                            oTmpAdd._Is_With_Chrono = true;
                        }
                        else
                        {
                            oTmpAdd._Is_With_Chrono = false;
                        }
                        oTmpAdd._Nb_Question_Revise = Convert.ToInt32(TbxNbQuestion.Text);
                        oTmpAdd._Total_Time = Convert.ToInt32(TbxTotTime.Text);
                        oTmpAdd._Total_Point = Convert.ToInt32(TbxTotPts.Text);
                        oTmpAdd._Comment = TbxCmt.Text;
                        oTmpAdd._ID_Domain = Convert.ToInt32(CbxDom.SelectedValue.ToString());
                        oTmpAdd._ID_Sub_Domain = Convert.ToInt32(CbxSubDom.SelectedValue.ToString());
                        HttpResponseMessage responseAdd = await Program.client.PostAsJsonAsync(
                                            $"api/ExamTest/postTest/{Program.currentUser.tUserID.Value}", oTmpAdd);
                        refreshDgdTest();
                        initTxtbox();
                        break;

                    case Tools.cStatUpd:

                        mExamTest_Display oTmpUpd = new mExamTest_Display();

                        oTmpUpd._ID = Convert.ToInt32(TbxID.Text);
                        oTmpUpd._Description = TbxDescription.Text;
                        if (SbxChrono.IsChecked.Value)
                        {
                            oTmpUpd._Is_With_Chrono = true;
                        }
                        else
                        {
                            oTmpUpd._Is_With_Chrono = false;
                        }
                        oTmpUpd._Nb_Question_Revise = Convert.ToInt32(TbxNbQuestion.Text);
                        oTmpUpd._Total_Time = Convert.ToInt32(TbxTotTime.Text);
                        oTmpUpd._Total_Point = Convert.ToInt32(TbxTotPts.Text);
                        oTmpUpd._Comment = TbxCmt.Text;
                        oTmpUpd._ID_Domain = Convert.ToInt32(CbxDom.SelectedValue.ToString());
                        oTmpUpd._ID_Sub_Domain = Convert.ToInt32(CbxSubDom.SelectedValue.ToString());

                        HttpResponseMessage responseUpd = await Program.client.PutAsJsonAsync(
                                            $"api/ExamTestputTest/{Program.currentUser.tUserID.Value}", oTmpUpd);
                        refreshDgdTest();
                        initTxtbox();
                        break;
                }
            }
        }

        private async void BtnTestDel_Click(object sender, RoutedEventArgs e)
        {
            if (TbxID.Text == "")
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgDelSelData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                Tools.vPageDataProcessingStatus01 = Tools.cStatDel;

                HttpResponseMessage responseDel = await Program.client.DeleteAsync($"api/ExamTest/delTest/{TbxID.Text}");
                refreshDgdTest();
                initTxtbox();
            }
        }

        private async void BtnQuestToTestAdd_Click(object sender, RoutedEventArgs e)
        {
            var rowSelectedTmpDgTest = (mExamTest_Display)DgdTest.SelectedItem;
            var rowSelectedTmpDgQuest = (mExamQuestionnaire_Display)DgdQuestionnaire.SelectedItem;
            if (rowSelectedTmpDgQuest == null || rowSelectedTmpDgTest == null)
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgToFilData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                int vExamTestID = Convert.ToInt32(rowSelectedTmpDgTest._ID);
                int vExamQuestID = Convert.ToInt32(rowSelectedTmpDgQuest._ID);
                HttpResponseMessage response = Program.client.GetAsync(
                    $"api/ExamTest_Questionnaire/getTest_QuestionnaireIDs?pExamTestID={vExamTestID}&pExamQuestionnaireID={vExamQuestID}").Result;
                var vListTest_Quest = response.Content.ReadFromJsonAsync<IEnumerable<mExamTest_Questionnaire_Display>>().Result;
                if (response.IsSuccessStatusCode && vListTest_Quest.Count() > 0)
                {
                    string vMsgTmp = (string)Application.Current.Resources["MsgExistData"];
                    MessageBox.Show(vMsgTmp);
                }
                else
                {

                    mExamTest_Questionnaire_Display oTmpAdd = new mExamTest_Questionnaire_Display();
                    oTmpAdd._ID_Test = vExamTestID;
                    oTmpAdd._ID_Questionnaire = vExamQuestID;
                    HttpResponseMessage responseAdd = await Program.client.PostAsJsonAsync(
                                        $"api/ExamTest_Questionnaire/postTest_Questionnaire/{Program.currentUser.tUserID.Value}", oTmpAdd);
                    refreshDgdTest_Questionnaire();

                }
            }

        }

        private async void BtnQuestToTestDel_Click(object sender, RoutedEventArgs e)
        {
            var rowSelectedTmpDgQuestToTest = (mExamTest_Questionnaire_Display)DgdTest_Questionnaire.SelectedItem;
            var vTest_QuestID = rowSelectedTmpDgQuestToTest;
            if (vTest_QuestID == null)
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgDelSelData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                HttpResponseMessage responseDel = await Program.client.DeleteAsync(
                    $"api/ExamTest_Question/delTest_Question/{vTest_QuestID._ID}");
                refreshDgdTest_Questionnaire();
            }
        }

    }
}

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
    public partial class PgeQuestionnaire : Page
    {
        public PgeQuestionnaire()
        {
            InitializeComponent();
            refreshDataGridQuestionnaire();
            refreshDataGridSelQuest();
            refreshCbxDom();
            refreshCbxSubDom();
            refreshCbxDomFilter();
            refreshCbxSubDomFilter();
            Tools.vPageDataProcessingStatus01 = Tools.cStatAdd;
            Tools.vPageDataProcessingStatus02 = Tools.cStatAdd;
        }

        private void refreshDataGridQuestionnaire()
        {
            DgdQuestionnaire.ItemsSource = null;

            HttpResponseMessage response = Program.client.GetAsync("api/ExamQuestionnaire/getQuestionnaire").Result;
            if (response.IsSuccessStatusCode)
            {
                var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamQuestionnaire_Display>>().Result;
                DgdQuestionnaire.ItemsSource = vList.AsEnumerable();
            }
            refreshDataGridQuestToQuestionnaire();
        }

        private void refreshDataGridSelQuest()
        {
            DgdSelQuest.ItemsSource = null;

            HttpResponseMessage response = Program.client.GetAsync("api/ExamQuestion/getQuestion").Result;
            if (response.IsSuccessStatusCode)
            {
                var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamQuestion_Display>>().Result;
                DgdSelQuest.ItemsSource = vList.AsEnumerable();
            }
        }

        private void refreshDataGridQuestToQuestionnaire()
        {
            DgdQuestToQuestionnaire.ItemsSource = null;

            TbxQuestID.Text = "";
            TbxQuestDesc.Text = "";
            var rowSelectedTmp = (mExamQuestionnaire_Display)DgdQuestionnaire.SelectedItem;
            if (rowSelectedTmp != null)
            {
                HttpResponseMessage response = Program.client.GetAsync(
                    $"api/ExamQuestionnaire_Question/getQuestionnaire_Question_QuestionnaireID/{rowSelectedTmp._ID}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamQuestionnaire_Question_Display>>().Result;
                    DgdQuestToQuestionnaire.ItemsSource = vList.AsEnumerable();
                }
            }
            refreshDataGridAnswer();
        }

        private void refreshDataGridAnswer()
        {
            DgdAnswToQuest.ItemsSource = null;

            TbxAnswID.Text = "";
            TbxAnswDesc.Text = "";
            var rowSelectedTmp = (mExamQuestionnaire_Question_Display)DgdQuestToQuestionnaire.SelectedItem;
            if (rowSelectedTmp != null)
            {
                HttpResponseMessage response = Program.client.GetAsync(
                    $"api/ExamQuestion_Answer/getQuestion_Answer_QuestionID/{rowSelectedTmp._ID_Question}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamQuestion_Answer_Display>>().Result;
                    DgdAnswToQuest.ItemsSource = vList.AsEnumerable();
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
            TbxWeight.Text = "";
            TbxTotTime.Text = "";
            TbxTotPts.Text = "";
            TbxCmt.Text = "";
            Tools.vPageDataProcessingStatus01 = Tools.cStatAdd;
        }


        private void DgdQuestionnaire_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rowSelectedTmp = (mExamQuestionnaire_Display)DgdQuestionnaire.SelectedItem;
            if (rowSelectedTmp != null & Tools.vPageDataProcessingStatus01 != Tools.cStatDel)
            {
                HttpResponseMessage response = Program.client.GetAsync($"api/ExamQuestionnaire/getQuestionnaireID/{rowSelectedTmp._ID}").Result;
                //string[] vIdTmp = response.Content.ReadFromJsonAsync<string[]>().Result;
                var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamQuestionnaire_Display>>().Result;
                mExamQuestionnaire_Display vObjTmp = vList.ElementAt(0);
                //if (response.IsSuccessStatusCode & vIdTmp[0] != "")
                //{
                //    TbxID.Text = vIdTmp[0];
                //    TbxDescription.Text = vIdTmp[1];
                //    TbxWeight.Text = vIdTmp[2];
                //    TbxTotTime.Text = vIdTmp[3];
                //    TbxTotPts.Text = vIdTmp[4];
                //    TbxCmt.Text = vIdTmp[5];
                //    CbxDom.Text = vIdTmp[6];
                //    CbxSubDom.Text = vIdTmp[7];
                if (response.IsSuccessStatusCode & vObjTmp._ID != null)
                { 
                    TbxID.Text = vObjTmp._ID.ToString();
                    TbxDescription.Text = vObjTmp._Description;
                    TbxWeight.Text = vObjTmp._Weight.ToString();
                    TbxTotTime.Text = vObjTmp._TotalTime.ToString();
                    TbxTotPts.Text = vObjTmp._TotalPoint.ToString();
                    TbxCmt.Text = vObjTmp._Comment;
                    if (vObjTmp._ID_Domain == null)
                    { CbxDom.SelectedIndex = 0; }
                    else
                    { CbxDom.SelectedValue = (int)vObjTmp._ID_Domain; }
                    if (vObjTmp._ID_Sub_Domain == null)
                    { CbxSubDom.SelectedIndex = 0; }
                    else
                    { CbxSubDom.SelectedValue = (int)vObjTmp._ID_Sub_Domain; }
                    //CbxDom.Text = vObjTmp._Domain;
                    //CbxSubDom.Text = vObjTmp._Sub_Domain;

                    Tools.vPageDataProcessingStatus01 = Tools.cStatUpd;
                    refreshDataGridQuestToQuestionnaire();
                }
            }
        }

        private void DgdQuestToQuestionnaire_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refreshDataGridAnswer();
            var rowSelectedTmp = (mExamQuestionnaire_Question_Display)DgdQuestToQuestionnaire.SelectedItem;
            if (rowSelectedTmp != null)
            {
                TbxQuestID.Text = rowSelectedTmp._ID.ToString();
                TbxQuestDesc.Text = rowSelectedTmp._Question;
            }
        }

        private void DgdDgdAnswToQuest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rowSelectedTmp = (mExamQuestion_Answer_Display)DgdAnswToQuest.SelectedItem;
            if (rowSelectedTmp != null)
            {
                TbxAnswID.Text = rowSelectedTmp._ID.ToString();
                TbxAnswDesc.Text = rowSelectedTmp._Answer;
            }
        }

        private void BtnQuestionnaireAdd_Click(object sender, RoutedEventArgs e)
        {
            if (Tools.vPageDataProcessingStatus01 != Tools.cStatAdd)
            {
                initTxtbox();
            }
        }

        private async void BtnQuestionnaireUpd_Click(object sender, RoutedEventArgs e)
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
                        mExamQuestionnaire_Display oTmpAdd = new mExamQuestionnaire_Display();
                        oTmpAdd._Description = TbxDescription.Text;
                        oTmpAdd._Weight = Convert.ToInt32(TbxWeight.Text);
                        oTmpAdd._TotalTime= Convert.ToInt32(TbxTotTime.Text);
                        oTmpAdd._TotalPoint = Convert.ToInt32(TbxTotPts.Text);
                        oTmpAdd._Comment = TbxCmt.Text;
                        oTmpAdd._ID_Domain = Convert.ToInt32(CbxDom.SelectedValue.ToString());
                        oTmpAdd._ID_Sub_Domain = Convert.ToInt32(CbxSubDom.SelectedValue.ToString());
                        HttpResponseMessage responseAdd = await Program.client.PostAsJsonAsync(
                                            $"api/ExamQuestionnaire/postQuestionnaire/{Program.currentUser.tUserID.Value}", oTmpAdd);
                        refreshDataGridQuestionnaire();
                        initTxtbox();
                        break;

                    case Tools.cStatUpd:

                        mExamQuestionnaire_Display oTmpUpd = new mExamQuestionnaire_Display();

                        oTmpUpd._ID = Convert.ToInt32(TbxID.Text);
                        oTmpUpd._Description = TbxDescription.Text;
                        oTmpUpd._Weight = Convert.ToInt32(TbxWeight.Text);
                        oTmpUpd._TotalTime = Convert.ToInt32(TbxTotTime.Text);
                        oTmpUpd._TotalPoint = Convert.ToInt32(TbxTotPts.Text);
                        oTmpUpd._Comment = TbxCmt.Text;
                        oTmpUpd._ID_Domain = Convert.ToInt32(CbxDom.SelectedValue.ToString());
                        oTmpUpd._ID_Sub_Domain = Convert.ToInt32(CbxSubDom.SelectedValue.ToString());

                        HttpResponseMessage responseUpd = await Program.client.PutAsJsonAsync(
                                            $"api/ExamQuestionnaire/putQuestionnaire/{Program.currentUser.tUserID.Value}", oTmpUpd);
                        refreshDataGridQuestionnaire();
                        initTxtbox();
                        break;
                }
            }
        }

        private async void BtnQuestionnaireDel_Click(object sender, RoutedEventArgs e)
        {
            if (TbxID.Text == "")
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgDelSelData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                Tools.vPageDataProcessingStatus01 = Tools.cStatDel;

                HttpResponseMessage responseDel = await Program.client.DeleteAsync($"api/ExamQuestionnaire/delQuestionnaire/{TbxID.Text}");
                refreshDataGridQuestionnaire();
                initTxtbox();
            }
        }

        private async void BtnQuestToQuestionnaireAdd_Click(object sender, RoutedEventArgs e)
        {
            var rowSelectedTmpDgQuestionnaire = (mExamQuestionnaire_Display)DgdQuestionnaire.SelectedItem;
            var rowSelectedTmpDgQuest = (mExamQuestion_Display)DgdSelQuest.SelectedItem;
            if (rowSelectedTmpDgQuest == null || rowSelectedTmpDgQuestionnaire == null)
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgToFilData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                int vExamQuestionnaireID = Convert.ToInt32(rowSelectedTmpDgQuestionnaire._ID);
                int vExamQuestID = Convert.ToInt32(rowSelectedTmpDgQuest._ID);
                HttpResponseMessage response = Program.client.GetAsync(
                    $"api/ExamQuestionnaire_Question/getQuestionnaire_QuestionIDs?pExamQuestionnaireID={
                        vExamQuestionnaireID}&pExamQuestionID={vExamQuestID}").Result;
                bool vQuestionnaire_QuestFind = response.Content.ReadFromJsonAsync<bool>().Result;
                if (response.IsSuccessStatusCode & vQuestionnaire_QuestFind)
                {
                    string vMsgTmp = (string)Application.Current.Resources["MsgExistData"];
                    MessageBox.Show(vMsgTmp);
                }
                else
                {

                    mExamQuestionnaire_Question_Display oTmpAdd = new mExamQuestionnaire_Question_Display();
                    oTmpAdd._ID_Questionnaire = vExamQuestionnaireID;
                    oTmpAdd._ID_Question = vExamQuestID;
                    HttpResponseMessage responseAdd = await Program.client.PostAsJsonAsync(
                                        $"api/ExamQuestionnaire_Question/postQuestionnaire_Question/{Program.currentUser.tUserID.Value}", oTmpAdd);
                    refreshDataGridQuestToQuestionnaire();

                }
            }

        }

        private async void BtnQuestToQuestionnaireDel_Click(object sender, RoutedEventArgs e)
        {
            var rowSelectedTmpDgQuestToQuestionnaire = (mExamQuestionnaire_Question_Display)DgdQuestToQuestionnaire.SelectedItem;
            var vQuestionnaire_QuestID = rowSelectedTmpDgQuestToQuestionnaire;
            if (vQuestionnaire_QuestID == null)
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgDelSelData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                HttpResponseMessage responseDel = await Program.client.DeleteAsync(
                    $"api/ExamQuestionnaire_Question/delQuestionnaire_Question/{vQuestionnaire_QuestID._ID}");
                refreshDataGridQuestToQuestionnaire();
            }
        }

    }
}

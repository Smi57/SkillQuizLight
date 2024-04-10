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
    public partial class PgeExam : Page
    {
        public PgeExam()
        {
            InitializeComponent();
            refreshDgdTest();
            refreshDgdUser_Test();
            refreshDgdUser();
            Tools.vPageDataProcessingStatus01 = Tools.cStatAdd;
            Tools.vPageDataProcessingStatus02 = Tools.cStatAdd;
        }

        private void refreshDgdTest()
        {
            DgdTest.ItemsSource = null;

            TbxTestID.Text = "";
            TbxTestDesc.Text = "";
            HttpResponseMessage response = Program.client.GetAsync("api/ExamTest/getTest").Result;
            if (response.IsSuccessStatusCode)
            {
                var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamTest_Display>>().Result;
                DgdTest.ItemsSource = vList.AsEnumerable();
            }
            refreshDgdUser_Test();
        }

        private void refreshDgdUser()
        {
            DgdUser.ItemsSource = null;

            HttpResponseMessage response = Program.client.GetAsync("api/User/getUser").Result;
            if (response.IsSuccessStatusCode)
            {
                var vList = response.Content.ReadFromJsonAsync<IEnumerable<mUser_Display>>().Result;
                DgdUser.ItemsSource = vList.AsEnumerable();
            }
        }

        private void refreshDgdUser_Test()
        {
            DgdUser_Test.ItemsSource = null;

            var rowSelectedTmp = (mExamTest_Display)DgdTest.SelectedItem;
            if (rowSelectedTmp != null)
            {
                HttpResponseMessage response = Program.client.GetAsync(
                    $"api/UserExam/getUser_Test_TestID/{rowSelectedTmp._ID}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var vList = response.Content.ReadFromJsonAsync<IEnumerable<mUserExam_Display>>().Result;
                    DgdUser_Test.ItemsSource = vList.AsEnumerable();
                }
            }
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
                    TbxTestID.Text = vIdTmp[0];
                    TbxTestDesc.Text = vIdTmp[1];
                    Tools.vPageDataProcessingStatus01 = Tools.cStatUpd;
                    refreshDgdUser_Test();
                }
            }
        }

        private void DgdUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var rowSelectedTmp = (mUser_Display)DgdUser.SelectedItem;
            if (rowSelectedTmp != null)
            {
                HttpResponseMessage response = Program.client.GetAsync($"api/User/getUserID/{rowSelectedTmp._ID}").Result;
                mUser_Display userFind = response.Content.ReadFromJsonAsync<mUser_Display>().Result;
                if (response.IsSuccessStatusCode & userFind._ID != null)
                {
                    tbxUserID.Text = userFind._ID.ToString();
                    tbxLoginTxt.Text = userFind._Login;
                    tbxFirstName.Text = userFind._First_Name;
                    tbxLastName.Text = userFind._Last_Name;
                }
            }
        }

        private async void BtnUserToTestAdd_Click(object sender, RoutedEventArgs e)
        {
            var rowSelectedTmpDgTest = (mExamTest_Display)DgdTest.SelectedItem;
            var rowSelectedTmpDgUser = (mUser_Display)DgdUser.SelectedItem;
            if (rowSelectedTmpDgUser == null || rowSelectedTmpDgTest == null)
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgToFilData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                int vExamTestID = Convert.ToInt32(rowSelectedTmpDgTest._ID);
                int vExamUserID = Convert.ToInt32(rowSelectedTmpDgUser._ID);
                HttpResponseMessage response = Program.client.GetAsync(
                    $"api/UserExam/getUser_TestIDs?pExamUserID={vExamUserID}&pExamTestID={vExamTestID}").Result;
                bool vTest_UserFind = response.Content.ReadFromJsonAsync<bool>().Result;
                if (response.IsSuccessStatusCode & vTest_UserFind)
                {
                    string vMsgTmp = (string)Application.Current.Resources["MsgExistData"];
                    MessageBox.Show(vMsgTmp);
                }
                else
                {

                    mUserExam_Display oTmpAdd = new mUserExam_Display();
                    oTmpAdd._ID_Test = vExamTestID;
                    oTmpAdd._ID_User = vExamUserID;
                    oTmpAdd._Comment = tbxCmt.Text;
                    //penser à lier à Program.cExamStatPlan
                    oTmpAdd._ID_Test_Status = 4;
                    oTmpAdd._Dead_line = Convert.ToDateTime(tbxDeadLine.Text);
                    //oTmpAdd._Finished_Date = Convert.ToDateTime(tbxFinishedDate.Text);
                    HttpResponseMessage responseAdd = await Program.client.PostAsJsonAsync(
                                        $"api/UserExam/postUser/{Program.currentUser.tUserID.Value}", oTmpAdd);
                    refreshDgdUser_Test();

                }
            }

        }

        private async void BtnUserToTestDel_Click(object sender, RoutedEventArgs e)
        {
            var rowSelectedTmpDgUserToTest = (mUserExam_Display)DgdUser_Test.SelectedItem;
            var vTest_UserID = rowSelectedTmpDgUserToTest;
            if (vTest_UserID == null)
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgDelSelData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                HttpResponseMessage responseDel = await Program.client.DeleteAsync(
                    $"api/ExamUser_Test/delUser_Test/{vTest_UserID._ID}");
                refreshDgdUser_Test();
            }
        }

    }
}

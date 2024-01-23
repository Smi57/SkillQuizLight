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
using SkillQuizLightWpf.Pages;

namespace SkillQuizLightWpf.PagesUser
{
    /// <summary>
    /// Interaction logic for ExamUser.xaml
    /// </summary>
    public partial class PgeExamUser : Page
    {
        public PgeExamUser()
        {
            Program.vCurrentPge = this.DependencyObjectType.Name;
            InitializeComponent();
            refreshDgdTest();

        }

        private void refreshDgdTest()
        {
            DgdTest.ItemsSource = null;

            //HttpResponseMessage response = Program.client.GetAsync($"api/ExamTest/getTest/{Program.currentUser.tUserID}").Result;
            HttpResponseMessage response = Program.client.GetAsync($"api/UserExam/getUser_Test_UserID/{Program.currentUser.tUserID}").Result;
            if (response.IsSuccessStatusCode)
            {
                var vList = response.Content.ReadFromJsonAsync<IEnumerable<mUserExam_Display>>().Result;
                DgdTest.ItemsSource = vList.AsEnumerable();
            }
            refreshDgdTest_Questionnaire();
        }

        private void refreshDgdTest_Questionnaire()
        {
            //var rowSelectedTmp = (mExamTest_Display)DgdTest.SelectedItem;
            var rowSelectedTmp = (mUserExam_Display)DgdTest.SelectedItem;
            if (rowSelectedTmp != null)
            {
                Program.currentUserExam = rowSelectedTmp;
                HttpResponseMessage response = Program.client.GetAsync(
                    $"api/ExamTest_Questionnaire/getTest_Questionnaire_TestID/{rowSelectedTmp._ID_Test}").Result; //rowSelectedTmp._ID
                if (response.IsSuccessStatusCode)
                {
                    var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamTest_Questionnaire_Display>>().Result;
                    DgdTest_Questionnaire.ItemsSource = vList.AsEnumerable();
                }
            }
        }

        private void DgdTest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var rowSelectedTmp = (mExamTest_Display)DgdTest.SelectedItem;
            var rowSelectedTmp = (mUserExam_Display)DgdTest.SelectedItem;
            if (rowSelectedTmp != null & Tools.vPageDataProcessingStatus01 != Tools.cStatDel)
            {
                //HttpResponseMessage response = Program.client.GetAsync($"api/ExamTest/getTestID/{rowSelectedTmp._ID}").Result;
                HttpResponseMessage response = Program.client.GetAsync($"api/ExamTest/getTestID/{rowSelectedTmp._ID_Test}").Result;
                string[] vIdTmp = response.Content.ReadFromJsonAsync<string[]>().Result;
                if (response.IsSuccessStatusCode & vIdTmp[0] != "")
                {
                    refreshDgdTest_Questionnaire();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var rowSelectedTmpDgQuest = (mExamTest_Questionnaire_Display)DgdTest_Questionnaire.SelectedItem;
            if (rowSelectedTmpDgQuest == null)
            {
                string vMsgTmp = (string)Application.Current.Resources["MsgToFilData"];
                MessageBox.Show(vMsgTmp);
            }
            else
            {
                if (Tools.fLauchPgeQuest(Convert.ToInt32(rowSelectedTmpDgQuest._ID_Questionnaire)))
                {
                    Uri uri = new Uri("pagesUser/PgeQuest.xaml", UriKind.Relative);
                    this.NavigationService.Navigate(uri);
                }
            }
        }
    }
}

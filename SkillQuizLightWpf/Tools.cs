using Azure;
using SkillQuizLight;
using SkillQuizLight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace SkillQuizLightWpf
{

    internal static class Tools
    {
        public const int cStatAdd = 0;
        public const int cStatUpd = 1;
        public const int cStatDel = 2;

        public static int vPageDataProcessingStatus01 = Tools.cStatAdd;
        public static int vPageDataProcessingStatus02 = Tools.cStatAdd;
        public static int vPageDataProcessingStatus03 = Tools.cStatAdd;

        public static void langManagement()
        {
            ResourceDictionary dict = new ResourceDictionary();
            if (Program.currentUser != null)
            {
                if (Program.currentUser.tParamLangID == 1)
                { dict.Source = new Uri("..\\Resources\\Lang.fr.xaml", UriKind.Relative); }
                else
                { dict.Source = new Uri("..\\Resources\\Lang.xaml", UriKind.Relative); }
            }
            else
            { dict.Source = new Uri("..\\Resources\\Lang.xaml", UriKind.Relative); }
            Application.Current.Resources.MergedDictionaries.Add(dict);
        }

        public static string verifUserPasswordManagement(string pMsg)
        {
            string vMsgTmp = (string)Application.Current.Resources["MsgPwdToEnter"];
            string vMsg = pMsg.Replace("[MsgPwdToEnter]", vMsgTmp);
            vMsgTmp = (string)Application.Current.Resources["MsgSup5Login"];
            vMsg = vMsg.Replace("[MsgSup5Login]", vMsgTmp);
            vMsgTmp = (string)Application.Current.Resources["MsgLoginNumP1"];
            vMsg = vMsg.Replace("[MsgLoginNumP1]", vMsgTmp);
            vMsgTmp = (string)Application.Current.Resources["MsgLoginNumP2"];
            vMsg = vMsg.Replace("[MsgLoginNumP2]", vMsgTmp);
            return vMsg;
        }

        public static bool isParmUserTypeRH(int pParamUserTypeID)
        {
            HttpResponseMessage response = Program.client.GetAsync($"api/ParamUserType/getParamUserTypeID/{pParamUserTypeID}").Result;
            string[] vDataStrTmp = response.Content.ReadFromJsonAsync<string[]>().Result;
            return (vDataStrTmp[1] == "RH");
        }

        public static int fQuitApp(bool pIsLoaded, bool pIsDisconnecting, System.ComponentModel.CancelEventArgs e)
        {
            HttpResponseMessage vResp = Program.client.GetAsync($"api/User/getIsQuestOpen/{Program.currentUser.tUserID}").Result;
            bool[] vIsQuestOpen = vResp.Content.ReadFromJsonAsync<bool[]>().Result;
            if (vIsQuestOpen[0] == true)
            {
                MessageBox.Show("Vous devez aller au bout du questionnaire pour pouvoir le fermer.", "", MessageBoxButton.OK,MessageBoxImage.Exclamation);
                e.Cancel = true;
                return Program.cBlocked;
            }
            else
            {
                if (pIsLoaded & pIsDisconnecting == false)
                {
                    string vMsgTmp = (string)Application.Current.Resources["MsgQuit"];
                    var vRes = MessageBox.Show(vMsgTmp, "", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.No);
                    if (vRes == MessageBoxResult.Yes)
                    { Application.Current.Shutdown(); }
                    else if (vRes == MessageBoxResult.No)
                    {
                        e.Cancel = true;
                        return Program.cCancel;
                    }
                    else
                    {
                        e.Cancel = true;
                        return Program.cQuit;
                    }
                }
                return Program.cCancel;
            }
        }
        public static bool fLauchPgeQuest(int pQuestionnaireID = 0)
        {
            bool vRes = false;

            if (pQuestionnaireID != 0)
            {
                HttpResponseMessage response = Program.client.GetAsync($"api/ExamQuestionnaire/getQuestionnaireID/" +
                    $"{pQuestionnaireID}").Result;
                //Program.currentQuestionnaire = response.Content.ReadFromJsonAsync<mExamQuestionnaire>().Result;
                var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamQuestionnaire_Display>>().Result;
                if (response.IsSuccessStatusCode)
                {
                    Program.currentQuestionnaire = vList.ElementAt(0);
                    vRes = true;
                }
            }
            else
            {
                HttpResponseMessage respParamLog = Program.client.GetAsync($"api/ParamLog/getParamLogID?oUser=" +
                $"{Program.currentUser}&pNameTypLog={Program.cNmTypLogIsQuestOpenUser}").Result;
                if (respParamLog.IsSuccessStatusCode)
                {
                    var vListParamLog = respParamLog.Content.ReadFromJsonAsync<IEnumerable<mParamLog_Display>>().Result;
                    HttpResponseMessage respExam = Program.client.GetAsync($"api/UserExam/getUser_Test_TestID/" +
                        $"{Convert.ToInt32(vListParamLog.ElementAt(0)._Info01)}").Result;
                    var vListExam = respExam.Content.ReadFromJsonAsync<IEnumerable<mUserExam_Display>>().Result;
                    Program.currentUserExam = vListExam.ElementAt(0);

                    HttpResponseMessage respQuestionnaire = Program.client.GetAsync($"api/ExamQuestionnaire/getQuestionnaireID/" +
                        $"{Convert.ToInt32(vListParamLog.ElementAt(0)._Info02)}").Result;
                    var vListQuestionnaire = respExam.Content.ReadFromJsonAsync<IEnumerable<mExamQuestionnaire_Display>>().Result;
                    Program.currentQuestionnaire = vListQuestionnaire.ElementAt(0);
                    vRes = true;
                }
            }
            if (vRes)
            {
                HttpResponseMessage respTest_Quest = Program.client.GetAsync($"api/ExamTest_Questionnaire/getTest_QuestionnaireIDs?" +
                    $"pExamTestID={Convert.ToInt32(Program.currentUserExam._ID_Test)}&pExamQuestionnaireID={Program.currentQuestionnaire._ID}").Result;
                var vListTest_Quest = respTest_Quest.Content.ReadFromJsonAsync<IEnumerable<mExamTest_Questionnaire_Display>>().Result;
                Program.currentTest_Questionnaire = vListTest_Quest.ElementAt(0);
            }
            return vRes;
        }
    }
}

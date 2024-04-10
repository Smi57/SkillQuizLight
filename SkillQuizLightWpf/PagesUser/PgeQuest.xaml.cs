using SkillQuizLight;
using SkillQuizLight.Models;
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
using System.Net.Http.Json;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Threading;
using Azure;


namespace SkillQuizLightWpf.PagesUser
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    /// 

    public partial class PgeQuest : Page
    {
        public const int cNothingDetected = 0;
        public const int cLastQuest = 1;

        int vCorr = 5;
        //mExamQuestion_Display oCurrentQuest;
        mExamQuestionnaire_Question_Display oCurrentQuest;

        public class TimeOpenQuest
        {
            public int ID { get; set; }
            public int tQuestionID { get; set; }
            public int TimeOpen { get; set; }
        }

        public List<TimeOpenQuest> vTimeOpenQuests = new List<TimeOpenQuest>();

        public int vTimeQuestMax;
        public int vTimeMax;
        public int vCurrentIndexList01;

        public PgeQuest()
        {
            Program.vCurrentPge = this.DependencyObjectType.Name;
            InitializeComponent();

            aSyncPutIsQuestOpen();

            string vQuestOpen = "";
            bool vIsQuestOpen = false;
            bool vFindUserQuestion = false;
            int vUserQuestIdTmp;
            int vUserQuestTimeOpenTmp;

            //MessageBox.Show(Program.currentQuestionnaire._ID.ToString());
            TbxDescr.Content = Program.currentQuestionnaire._Description;

            //On récupère le temps maximum du questionnaire
            vTimeMax = Convert.ToInt32(Program.currentQuestionnaire._TotalTime);

            // Je récupére l'état du timer du questionnaire à l'ouvertureresponseUserQuest.IsSuccessStatusCode
            // - J'enregistre tous les temps des questions en cours dans une liste
            //getUserQuestion_IDs
            int vCurrentQuestionnaire = Convert.ToInt32(Program.currentQuestionnaire._ID);
            if (vCurrentQuestionnaire != null)
            {
                //HttpResponseMessage response = Program.client.GetAsync(
                //    $"api/ExamQuestion/getQuestion_IdQuestionaire/{vCurrentQuestionnaire}").Result;
                HttpResponseMessage response = Program.client.GetAsync(
                    $"api/ExamQuestionnaire_Question/getQuestionnaire_Question_QuestionnaireID/{vCurrentQuestionnaire}").Result;
                if (response.IsSuccessStatusCode)
                {
                    //List<mExamQuestion_Display> vExamQuestions = response.Content.ReadFromJsonAsync<List<mExamQuestion_Display>>().Result;
                    List<mExamQuestionnaire_Question_Display> vExamQuestions = 
                        response.Content.ReadFromJsonAsync<List<mExamQuestionnaire_Question_Display>>().Result;
                    //foreach (mExamQuestion_Display p in vExamQuestions)
                    foreach (mExamQuestionnaire_Question_Display p in vExamQuestions)
                    {

                        HttpResponseMessage responseUserQuest = Program.client.GetAsync(
                                $"api/UserQuestion/getUserQuestion_IDs?ptExamQuestionID={Convert.ToInt32(p._ID_Question)}" + //p._ID
                                $"&ptExamTest_QuestionnaireID={Convert.ToInt32(Program.currentTest_Questionnaire._ID)}").Result;

                        mUserQuestion_Display vUserQuest;
                        vUserQuestIdTmp = 0;
                        vUserQuestTimeOpenTmp = 0;
                        if (responseUserQuest.IsSuccessStatusCode)
                        {
                            //var vList = responseUserQuest.Content.ReadFromJsonAsync<IEnumerable<mUserQuestion_Display>>().Result;
                            var vList = responseUserQuest.Content.ReadFromJsonAsync<IEnumerable<mUserQuestion_Display>>().Result;
                            if (vList.Count() != 0)
                            {
                                vFindUserQuestion = true;
                                vUserQuest = vList.ElementAt(0);
                                if (vUserQuest._TimeOpen != 0)
                                {
                                    vIsQuestOpen = true;
                                }
                                else if (vIsQuestOpen && vQuestOpen == "")
                                {
                                    vQuestOpen = vUserQuest._ID.ToString();
                                }
                                vUserQuestIdTmp = Convert.ToInt32(vUserQuest._ID);
                                vUserQuestTimeOpenTmp = Convert.ToInt32(vUserQuest._TimeOpen);
                            }
                        }
                        if (vFindUserQuestion == false)
                        {
                            vUserQuest = new mUserQuestion_Display();
                            vUserQuest._tUserExamID = Program.currentUserExam._ID;
                            //vUserQuest._tExamQuestionnaire_QuestionID = Program.currentQuestionnaire._ID;
                            vUserQuest._tExamTest_QuestionnaireID = Program.currentTest_Questionnaire._ID;
                            vUserQuest._tExamQuestionnaire_QuestionID = p._ID;
                            vUserQuest._TimeOpen = 0;
                            vUserQuest._tExamQuestionID = p._ID_Question;
                            aSyncPostPutUserQuestion(vUserQuest);
                            responseUserQuest = Program.client.GetAsync(
                                    $"api/UserQuestion/getUserQuestion_IDs?ptExamQuestionID={Convert.ToInt32(p._ID_Question)}" + //p._ID
                                    $"&ptExamTest_QuestionnaireID={Convert.ToInt32(Program.currentTest_Questionnaire._ID)}").Result;
                            var vList = responseUserQuest.Content.ReadFromJsonAsync<IEnumerable<mUserQuestion_Display>>().Result;
                            vUserQuest = vList.ElementAt(0);
                            vUserQuestIdTmp = Convert.ToInt32(vUserQuest._ID);
                        }
                        vTimeOpenQuests.Add(new TimeOpenQuest()
                        {
                            ID = Convert.ToInt32(vUserQuestIdTmp),
                            tQuestionID = Convert.ToInt32(p._ID_Question),
                            TimeOpen = Convert.ToInt32(vUserQuestTimeOpenTmp)
                        }); ;
                    }
                    int vSumTimeOpen = vTimeOpenQuests.Sum(p => p.TimeOpen);

                    //MessageBox.Show(vSumTimeOpen.ToString());
                    //List<> = response.Content.ReadFromJsonAsync<IEnumerable<mExamTest_Questionnaire_Display>>().Result;
                    //DgdTest_Questionnaire.ItemsSource = vList.AsEnumerable();
                 }
            }

            initAnsw();
            if (vIsQuestOpen)
            {
                HttpResponseMessage respParamLog = Program.client.GetAsync($"api/ParamLog/getParamLogID?ptUserID=" +
                $"{Program.currentUser.tUserID}&pNameTypLog={Program.cNmTypLogIsQuestOpenUser}").Result;
                var vListParamLog = respParamLog.Content.ReadFromJsonAsync<IEnumerable<mParamLog_Display>>().Result;
                if (vListParamLog.Count()!=0 )
                {
                    vQuestOpen = vListParamLog.ElementAt(0)._Info03;
                    displayQuestAnsw(vQuestOpen, true);
                }
                else
                {
                    displayQuestAnsw();
                }
            }
            else
            {
                displayQuestAnsw();
            }

            DispatcherTimer vDispatcherTimer = new DispatcherTimer();
            vDispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            vDispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            vDispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            // Code pour afficher une boîte de dialogue

            vTimeOpenQuests[vCurrentIndexList01].TimeOpen = vTimeOpenQuests[vCurrentIndexList01].TimeOpen + 1;
            TimeOpenQuest vTimeOpenQuest = vTimeOpenQuests[vCurrentIndexList01];
            int vSumTimeOpen = vTimeOpenQuests.Sum(p => p.TimeOpen);
            TbxTime.Text = vSumTimeOpen.ToString() + " / " + vTimeMax.ToString();
            TbxTimeQuest.Text = vTimeOpenQuest.TimeOpen.ToString() + " / " + vTimeQuestMax.ToString();
            mUserQuestion_Display vUserQuest = new mUserQuestion_Display();
            vUserQuest._ID = vTimeOpenQuests[vCurrentIndexList01].ID;
            vUserQuest._TimeOpen = vTimeOpenQuests[vCurrentIndexList01].TimeOpen;
            aSyncPostPutUserQuestion(vUserQuest,false);

        }

        private async void aSyncPutIsQuestOpen(bool pTrue = true)
        {
            if (Program.currentUser.tUserID > 0)
            {
                HttpResponseMessage responseDel;
                if (pTrue)
                {
                    responseDel = await Program.client.PutAsJsonAsync($"api/User/putIsQuestOpenTrue/{Program.currentUser.tUserID}",true);
                }
                else
                {
                    responseDel = await Program.client.PutAsJsonAsync($"api/User/putIsQuestOpenFalse/{Program.currentUser.tUserID}",false);
                }
            }
        }
                
        public async void aSyncPostPutUserQuestion(mUserQuestion_Display pUserQuest, bool pPost = true)
        {
            if (pPost)
            {
                HttpResponseMessage responseAdd = Program.client.PostAsJsonAsync(
                                $"api/UserQuestion/postUserQuestion/{Program.currentUser.tUserID.Value}", pUserQuest).Result;
            }
            else
            {
                HttpResponseMessage responseAdd = await Program.client.PutAsJsonAsync(
                                $"api/UserQuestion/putUserQuestion/{Program.currentUser.tUserID.Value}", pUserQuest);
            }


        }

        public async void aSyncPostPutUserAnswer(mUserAnswer_Display pUserAnswer, bool pPost = true)
        {
            if (pPost)
            {
                HttpResponseMessage responseAdd = await Program.client.PostAsJsonAsync(
                                $"api/UserAnswer/postAnswer/{Program.currentUser.tUserID.Value}", pUserAnswer);
            }
            else
            {
                HttpResponseMessage responseAdd = await Program.client.PutAsJsonAsync(
                                $"api/UserAnswer/putAnswer/{Program.currentUser.tUserID.Value}", pUserAnswer);
            }


        }

        public async void aSyncPostPutParamLog(mParamLog_Display pParamLog, bool pPost = true)
        {
            if (pPost)
            {
                HttpResponseMessage responseAdd = await Program.client.PostAsJsonAsync(
                                $"api/ParamLog/postParamLog/{Program.currentUser.tUserID.Value}", pParamLog);

            }
            else
            {
                HttpResponseMessage responseAdd = await Program.client.PutAsJsonAsync(
                                $"api/ParamLog/putParamLog/{Program.currentUser.tUserID.Value}", pParamLog);
            }


        }
        public async void aSyncDelParamLog()
        {
            HttpResponseMessage responseDel = await Program.client.DeleteAsync("api/ParamLog/delParamLog?" +
                $"pNameTypLog={Program.cNmTypLogIsQuestOpenUser}&ptUserID={Program.currentUser.tUserID}");
        }

        private void initAnsw()
        {
            Cbx1.Visibility = Visibility.Hidden; Cbx2.Visibility = Visibility.Hidden; Cbx3.Visibility = Visibility.Hidden; Cbx4.Visibility = Visibility.Hidden;
            Cbx5.Visibility = Visibility.Hidden; Cbx6.Visibility = Visibility.Hidden; Cbx7.Visibility = Visibility.Hidden; Cbx8.Visibility = Visibility.Hidden;
            Cbx9.Visibility = Visibility.Hidden;
        }

        private void initVal()
        {
            Cbx1.IsChecked = false; Cbx2.IsChecked = false; Cbx3.IsChecked = false; Cbx4.IsChecked = false;
            Cbx5.IsChecked = false; Cbx6.IsChecked = false; Cbx7.IsChecked = false; Cbx8.IsChecked = false;
            Cbx9.IsChecked = false;
        }

        private void EnabledAnsw(bool pEnabled = false)
        {
            Cbx1.IsEnabled = pEnabled; Cbx2.IsEnabled = pEnabled; Cbx3.IsEnabled = pEnabled; Cbx4.IsEnabled = pEnabled; Cbx5.IsEnabled = pEnabled;
            Cbx6.IsEnabled = pEnabled; Cbx7.IsEnabled = pEnabled; Cbx8.IsEnabled = pEnabled; Cbx9.IsEnabled = pEnabled;
        }

        private int displayQuestAnsw(string pID = "", bool pDown = false)
        {
            int vValReturn = cNothingDetected;
            mExamQuestionnaire_Question_Display oCurrentQuestForLog;


            HttpResponseMessage response = Program.client.GetAsync(
                //$"api/ExamQuestion/getQuestion_IdQuestionaire/{Program.currentQuestionnaire._ID}").Result;
                $"api/ExamQuestionnaire_Question/getQuestionnaire_Question_QuestionnaireID/{Program.currentQuestionnaire._ID}").Result;
            var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamQuestionnaire_Question_Display>>().Result;
            if (vList.Count()!=0)
            {
                //var vList = response.Content.ReadFromJsonAsync<IEnumerable<mExamQuestion_Display>>().Result;
                //oCurrentQuest = new mExamQuestion_Display();
                oCurrentQuest = new mExamQuestionnaire_Question_Display();
                // Si pas d'id recherche on se possitionne sur le premier
                if (pID == "")
                {
                    oCurrentQuest = vList.OrderBy(b => b._ID_Question).ElementAt(0); //._ID
                }
                // Sinon
                else
                {
                    // Si on descend vers l'enregirstrement précédent
                    if (pDown)
                    {
                        if (vList.Where(b => b._ID_Question < Convert.ToInt32(pID)).Count() == 0) //._ID
                        {
                            // Si il n'y a pas d'enregistrement avant, on va vers le dernier
                            oCurrentQuest = vList.OrderByDescending(b => b._ID_Question).ElementAt(0); //._ID
                        }
                        else
                        {
                            oCurrentQuest = vList.Where(b => b._ID_Question < Convert.ToInt32(pID)).OrderByDescending(b => b._ID_Question).ElementAt(0); //._ID   ._ID
                        }
                    }
                    // Sinon on remonte vers l'enregirstrement suivant
                    else
                    {
                        if (vList.Where(b => b._ID_Question > Convert.ToInt32(pID)).Count() == 0)  //._ID 
                        {
                            // Si il n'y a pas d'enregistrement après, on revient vers le premier
                            // oCurrentQuest = vList.OrderBy(b => b._ID_Question).ElementAt(0);  //._ID 
                            vValReturn = cLastQuest;
                            return vValReturn;
                            
                        }
                        else
                        {
                            oCurrentQuest = vList.Where(b => b._ID_Question >= Convert.ToInt32(pID)).OrderBy(b => b._ID_Question).ElementAt(1); //._ID   ._ID
                        }
                    }
                }
                //TbxQuest.Text = oCurrentQuest._Description; Program.currentTest_Questionnaire
                TbxQuest.Text = oCurrentQuest._Question;
                //LabNumQuest.Content = oCurrentQuest._ID.ToString();
                LabNumQuest.Content = oCurrentQuest._ID_Question.ToString();
                //vTimeQuestMax = Convert.ToInt32(oCurrentQuest._Time);
                vTimeQuestMax = Convert.ToInt32(oCurrentQuest._QuestionTime);
                //TimeOpenQuest vTimeOpenQuest = vTimeOpenQuests.Find(a => a.tQuestionID == oCurrentQuest._ID);
                TimeOpenQuest vTimeOpenQuest = vTimeOpenQuests.Find(a => a.tQuestionID == oCurrentQuest._ID_Question);
                vCurrentIndexList01 = vTimeOpenQuests.IndexOf(vTimeOpenQuest);
                int vSumTimeOpen = vTimeOpenQuests.Sum(p => p.TimeOpen);
                TbxTime.Text = vSumTimeOpen.ToString() + " / " + vTimeMax.ToString() ;
                TbxTimeQuest.Text = vTimeOpenQuest.TimeOpen.ToString() + " / " + vTimeQuestMax.ToString();

                initAnsw();
                //HttpResponseMessage respAswers = Program.client.GetAsync($"api/ExamQuestion_Answer/getQuestion_Answer_QuestionID/{oCurrentQuest._ID.ToString()}").Result;
                HttpResponseMessage respAswers = Program.client.GetAsync($"api/ExamQuestion_Answer/getQuestion_Answer_QuestionID/{oCurrentQuest._ID_Question.ToString()}").Result;
                var vListAnswers = respAswers.Content.ReadFromJsonAsync<IEnumerable<mExamQuestion_Answer_Display>>().Result;
                if (vListAnswers.Count()!=0)
                {
                    int i = 0;
                    foreach (mExamQuestion_Answer_Display vAnsw in vListAnswers)
                    {
                        i++;
                        string nomDeBase = "Cbx";
                        string nomComplet = nomDeBase + i.ToString();
                        CheckBox cbxCurrent = GridCbxs.FindName(nomComplet) as CheckBox;
                        cbxCurrent.Visibility = Visibility.Visible;
                        cbxCurrent.Content = i + ". " + vAnsw._Answer.ToString();
                    }
                }

                //Création ou mise à jour du Log
                HttpResponseMessage vRespLog = Program.client.GetAsync(
                    $"api/ParamLog/getParamLogID?ptUserID={Program.currentUser.tUserID}&pNameTypLog={Program.cNmTypLogIsQuestOpenUser}").Result;
                    mParamLog_Display[] vTmpParmaLog = vRespLog.Content.ReadFromJsonAsync<mParamLog_Display[]>().Result;

                if (vList.Where(b => b._ID_Question > Convert.ToInt32(oCurrentQuest._ID_Question)).Count() == 0)  //._ID 
                {
                    // Si il n'y a pas d'enregistrement après, on revient vers le premier
                    oCurrentQuestForLog = vList.OrderBy(b => b._ID_Question).ElementAt(0);  //._ID 

                }
                else
                {
                    oCurrentQuestForLog = vList.Where(b => b._ID_Question >= Convert.ToInt32(oCurrentQuest._ID_Question)).OrderBy(b => b._ID_Question).ElementAt(1); //._ID   ._ID
                }


                if (vTmpParmaLog.Count() != 0)
                {

                    vTmpParmaLog[0]._Info01 = Program.currentTest_Questionnaire._ID_Test.ToString();
                    vTmpParmaLog[0]._Info02 = Program.currentQuestionnaire._ID.ToString();
                    vTmpParmaLog[0]._Info03 = oCurrentQuestForLog._ID_Question.ToString();
                    aSyncPostPutParamLog(vTmpParmaLog[0], false);
                }
                else
                {

                    mParamLog_Display oParamLogToAdd = new mParamLog_Display();
                    HttpResponseMessage vRespGetTypLogID = Program.client.GetAsync($"api/ParamLog/getTypLogID/{Program.cNmTypLogIsQuestOpenUser}").Result;
                    int[] vGetTypLogID = vRespGetTypLogID.Content.ReadFromJsonAsync<int[]>().Result;

                    oParamLogToAdd._tTypLogID = vGetTypLogID[0];
                    oParamLogToAdd._Info01 = Program.currentTest_Questionnaire._ID_Test.ToString();
                    oParamLogToAdd._Info02 = Program.currentQuestionnaire._ID.ToString();
                    oParamLogToAdd._Info03 = oCurrentQuestForLog._ID_Question.ToString();
                    aSyncPostPutParamLog(oParamLogToAdd);
                }

            }
            return vValReturn;

        }

        private void BtnPrevQuest_Click(object sender, RoutedEventArgs e)
        {
            displayQuestAnsw(LabNumQuest.Content.ToString(),true);
        }

        private void BtnNextQuest_Click(object sender, RoutedEventArgs e)
        {

            //HttpResponseMessage respAswers = Program.client.GetAsync($"api/ExamQuestion_Answer/getQuestion_Answer_QuestionID/{oCurrentQuest._ID.ToString()}").Result;
            HttpResponseMessage respAswers = Program.client.GetAsync($"api/ExamQuestion_Answer/getQuestion_Answer_QuestionID/{oCurrentQuest._ID_Question.ToString()}").Result;
            var vListAnswers = respAswers.Content.ReadFromJsonAsync<IEnumerable<mExamQuestion_Answer_Display>>().Result;
            if (vListAnswers.Count()!=0)
            {
                int i = 0;
                foreach (mExamQuestion_Answer_Display vAnsw in vListAnswers)
                {
                    if (respAswers.IsSuccessStatusCode)
                    {
                        i++;
                        string nomDeBase = "Cbx";
                        string nomComplet = nomDeBase + i.ToString();
                        CheckBox cbxCurrent = GridCbxs.FindName(nomComplet) as CheckBox;

                        mUserAnswer_Display oUserAnswerToAdd = new mUserAnswer_Display();
                        oUserAnswerToAdd._Description = vAnsw._Answer;
                        oUserAnswerToAdd._Comment = "";
                        oUserAnswerToAdd._IsSelectByUser = cbxCurrent.IsChecked;
                        oUserAnswerToAdd._tUserExamID = Program.currentUserExam._ID;
                        oUserAnswerToAdd._tExamTest_QuestionnaireID = Program.currentTest_Questionnaire._ID;
                        oUserAnswerToAdd._tExamQuestionnaire_QuestionID = oCurrentQuest._ID;
                        oUserAnswerToAdd._tExamAnswerID = vAnsw._ID;
                        aSyncPostPutUserAnswer(oUserAnswerToAdd);
                    }
                }
            }
            int vRes = displayQuestAnsw(LabNumQuest.Content.ToString());
            if (vRes == cLastQuest)
            {
                if (MessageBox.Show("Ceci était la dernière question, voulez vous mettre fin au questionnaire ?", "",
                            MessageBoxButton.YesNoCancel, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    aSyncPutIsQuestOpen(false);
                    aSyncDelParamLog();
                    Uri uri = new Uri("pagesUser/PgeExamUser.xaml", UriKind.Relative);
                    this.NavigationService.Navigate(uri);
                }
            }
            else
            {
                initVal();
            }
        }

        private void BtnNextNoAnsw_Click(object sender, RoutedEventArgs e)
        {
            displayQuestAnsw(LabNumQuest.Content.ToString());
        }

        private void BtnCorrQuest_Click(object sender, RoutedEventArgs e)
        {
            vCorr = vCorr - 1;
            BtnCorrQuest.Content = "Corriger question (" + vCorr + ")";
            EnabledAnsw(true);
        }
    }
}

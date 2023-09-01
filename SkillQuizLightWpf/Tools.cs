using SkillQuizLight;
using System;
using System.Collections.Generic;
using System.Linq;
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
                if (Program.currentUser.ParamLangID == 1)
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
    }
}

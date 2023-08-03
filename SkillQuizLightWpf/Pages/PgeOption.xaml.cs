using SkillQuizLight;
using SkillQuizLight.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
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

namespace SkillQuizLightWpf.Pages
{
    /// <summary>
    /// Interaction logic for PgeOptionLanguage.xaml
    /// </summary>
    public partial class PgeOption : Page
    {
        bool isStarting = true;

        public PgeOption()
        {
            InitializeComponent();
            isStarting = true;
            cbxLang.SelectedIndex = Program.currentUser.ParamLangID;
            isStarting = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri("Pages/PageHome.xaml", UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private async void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isStarting)
            {
                Program.currentUser.ParamLangID = cbxLang.SelectedIndex;

                mUser userTmpUpd = new mUser(
                        Convert.ToInt32(Program.currentUser.tUserID),
                        null,null,null,null,null,
                        Convert.ToInt32(cbxLang.SelectedIndex));
                HttpResponseMessage responseUpd = await Program.client.PutAsJsonAsync("api/User/putUser", userTmpUpd);
                Tools.langManagement();
            }
        }
    }
}

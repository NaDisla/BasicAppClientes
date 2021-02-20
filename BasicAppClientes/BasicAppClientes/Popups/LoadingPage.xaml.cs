using Rg.Plugins.Popup.Pages;
using Xamarin.Forms.Xaml;

namespace BasicAppClientes.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : PopupPage
    {
        public LoadingPage(string detail)
        {
            InitializeComponent();
            lblLoadingDetail.Text = detail;
        }
    }
}
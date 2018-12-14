using Lands.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lands.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        LoginViewModel _viewModel;
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new LoginViewModel();
        }
    }
}
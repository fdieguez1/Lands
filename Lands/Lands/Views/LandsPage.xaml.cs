using Lands.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lands.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LandsPage : ContentPage
	{
        LandsViewModel _viewModel;
		public LandsPage ()
		{
			InitializeComponent ();
            BindingContext = _viewModel = new LandsViewModel();
		}
	}
}
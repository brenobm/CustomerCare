using CustomerCare.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomerCare.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
    {
        private LoginViewModel viewModel;

        public LoginPage ()
		{
			InitializeComponent ();

            if (!(BindingContext is LoginViewModel))
            {
                BindingContext = viewModel = new LoginViewModel();
            }
        }
    }
}
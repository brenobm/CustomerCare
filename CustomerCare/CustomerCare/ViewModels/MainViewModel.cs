using CustomerCare.Services;
using CustomerCare.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CustomerCare.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        private IAuthenticationService authenticationService;

        public Command LogoutCommand { get; set; }

        public MainViewModel()
        {
            authenticationService = DependencyService.Get<IAuthenticationService>();

            LogoutCommand = new Command(() => ExecuteLogoutCommand());
        }

        private void ExecuteLogoutCommand()
        {
            authenticationService.Logout();

            Page page = new LoginPage
            {
                BindingContext = new LoginViewModel()
            };

            Application.Current.MainPage = page;
        }
    }
}

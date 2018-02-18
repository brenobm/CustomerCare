using CustomerCare.Services;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomerCare.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {
        private IAuthenticationService authServer;

        public LoginViewModel()
        {
            Initialize();
        }

        private async Task ExecutLoginCommand()
        {
            if (await authServer.Login())
            {
                ChangeMainPage<MainViewModel>(null);
            }
            else
            {
                await MessageService.ShowAsync("Atenção!", "Usuário / senha fornecidos incorretos!");
            }
        }

        private void Initialize()
        {
            authServer = DependencyService.Get<IAuthenticationService>();

            LoginCommand = new Command(async () => await ExecutLoginCommand());
        }

        public Command LoginCommand { get; set; }
    }
}

using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomerCare.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
    {
        private AuthenticationResult ar;

        public LoginPage ()
		{
			InitializeComponent ();

            LoginButton.Clicked += LoginButton_Clicked;
        }

        protected override async void OnAppearing()
        {

            try
            {
                AuthenticationResult ar =
                        await App.PCA.AcquireTokenSilentAsync(App.Scopes, App.PCA.Users.FirstOrDefault());

                WelcomeText.Text = $"Welcome {ar.User.Name}";
            }
            catch
            {

            }

            base.OnAppearing();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                AuthenticationResult ar = await App.PCA.AcquireTokenAsync(App.Scopes, App.UiParent);

                var name = ar.User.Name;

                WelcomeText.Text = $"Welcome {ar.User.Name}";

            }
            catch (MsalException ex)
            {
                WelcomeText.Text = ex.Message;
            }
        }
    }
}
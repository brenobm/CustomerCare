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
        public IPlatformParameters PlatformParameters { get; set; }

        public LoginPage ()
		{
			InitializeComponent ();

            LoginButton.Clicked += LoginButton_Clicked;
        }

        protected override void OnAppearing()
        {
            App.ClientApplication.PlatformParameters = PlatformParameters;
            base.OnAppearing();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                AuthenticationResult ar = await App.ClientApplication.AcquireTokenAsync(App.Scopes);
                WelcomeText.Text = $"Welcome {ar.User.Name}";
            }
            catch (MsalException ex)
            {
                WelcomeText.Text = ex.Message;
            }
        }
    }
}
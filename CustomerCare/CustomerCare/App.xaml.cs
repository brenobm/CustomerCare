using System;

using CustomerCare.Views;
using CustomerCare.Services;
using Xamarin.Forms;
using Microsoft.Identity.Client;

namespace CustomerCare
{
	public partial class App : Application
	{
        public static PublicClientApplication PCA = null;
        public static string ClientID = "105c8c48-4977-4c63-974e-82424cb3539c";
        public static string[] Scopes = {
            "User.Read",
            "Calendars.Read", "Calendars.Read.Shared",
            "Calendars.ReadWrite", "Calendars.ReadWrite.Shared",
            "Contacts.Read", "Contacts.Read.Shared",
            "Contacts.ReadWrite", "Contacts.ReadWrite.Shared"
        };

        public static string Username = string.Empty;

        public static UIParent UiParent = null;

        public App ()
		{
			InitializeComponent();

            PCA = new PublicClientApplication(ClientID);

            IAuthenticationService authenticationService = DependencyService.Get<IAuthenticationService>();

            Page mainPage = null;

            if (authenticationService.CurrentLogged().Result)
            {
                mainPage = new MainPage();
            }
            else
            {
                mainPage = new LoginPage();
            }

            MainPage = mainPage;
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

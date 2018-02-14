using System;

using CustomerCare.Views;
using CustomerCare.Services;
using Xamarin.Forms;
using Microsoft.Identity.Client;

namespace CustomerCare
{
	public partial class App : Application
	{
		public static bool UseMockDataStore = true;
		public static string AzureMobileAppUrl = "https://[CONFIGURE-THIS-URL].azurewebsites.net";

        public static PublicClientApplication ClientApplication { get; set; }
        public static string[] Scopes = { "User.Read" };

        public App ()
		{
			InitializeComponent();

			if (UseMockDataStore)
				DependencyService.Register<MockDataStore>();
			else
				DependencyService.Register<AzureDataStore>();

            ClientApplication = new PublicClientApplication("105c8c48-4977-4c63-974e-82424cb3539c");

            MainPage = new LoginPage();
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

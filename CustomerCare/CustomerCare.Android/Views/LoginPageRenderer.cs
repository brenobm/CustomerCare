using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CustomerCare.Views;
using Microsoft.Identity.Client;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LoginPage), typeof(CustomerCare.Droid.Views.LoginPageRenderer))]
namespace CustomerCare.Droid.Views
{
    public class LoginPageRenderer : PageRenderer
    {
        private LoginPage _page;

        public LoginPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            _page = e.NewElement as LoginPage;
            var activity = this.Context as Activity;
        }
    }
}
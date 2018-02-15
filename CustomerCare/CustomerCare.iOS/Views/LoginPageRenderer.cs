using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerCare.Views;
using Foundation;
using Microsoft.Identity.Client;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace CustomerCare.iOS.Views
{
    class LoginPageRenderer : PageRenderer
    {
        LoginPage _page;
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            _page = e.NewElement as LoginPage;
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
        }
    }
}
using CustomerCare.ViewModels;
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
	public partial class NewClientPage : ContentPage
    {
        private NewClientViewModel viewModel;

        public NewClientPage ()
		{
			InitializeComponent ();

            if (!(BindingContext is NewClientViewModel))
            {
                BindingContext = viewModel = new NewClientViewModel();
            }
        }
	}
}
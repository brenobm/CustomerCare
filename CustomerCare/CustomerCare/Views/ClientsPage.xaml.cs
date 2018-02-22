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
	public partial class ClientsPage : ContentPage
	{
        private ClientsViewModel viewModel;

        public ClientsPage ()
		{
			InitializeComponent ();

            if (!(BindingContext is ClientsViewModel))
            {
                BindingContext = viewModel = new ClientsViewModel();
            }
        }
	}
}
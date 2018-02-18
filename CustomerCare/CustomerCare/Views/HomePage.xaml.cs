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
    public partial class HomePage : ContentPage
    {
        private HomeViewModel viewModel;

        public HomePage()
        {
            InitializeComponent();

            if (!(BindingContext is HomeViewModel))
            {
                BindingContext = viewModel = new HomeViewModel();
            }
        }
    }
}
using CustomerCare.Helpers;
using CustomerCare.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CustomerCare.ViewModels
{
    public class MenuViewModel: ViewModelBase
    {
        public ObservableCollection<MasterPageMenuItem> MenuItems { get; set; }

        public string UserName
        {
            get
            {
                return ConstantsHelper.UserName;
            }
        }

        public MenuViewModel()
        {
            MenuItems = new ObservableCollection<MasterPageMenuItem>(new[]
                {
                    new MasterPageMenuItem { Id = 0, Title = "Sair", TargetType = typeof(LogoutMenu) },
                });
        }
    }
}

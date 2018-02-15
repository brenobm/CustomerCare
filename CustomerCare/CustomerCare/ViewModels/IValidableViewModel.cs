using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerCare.ViewModels
{
    public interface IValidableViewModel
    {
        void AddValidations();
        bool Validate();
        string GetErrorMessages();

    }
}

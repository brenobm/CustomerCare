using Xamarin.Forms;

namespace CustomerCare.Controls
{
    public class ValidablePicker: Picker
    {
        public static readonly BindableProperty ValidProperty = BindableProperty.Create(
            propertyName: "Valid",
            returnType: typeof(bool),
            declaringType: typeof(ValidablePicker),
            defaultValue: true);

        public bool Valid
        {
            get
            {
                return (bool)GetValue(ValidProperty);
            }
            set
            {
                SetValue(ValidProperty, value);
            }
        }
    }
}

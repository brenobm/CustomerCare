using Xamarin.Forms;

namespace CustomerCare.Controls
{
    public class ValidableEntry: Entry
    {
        public static readonly BindableProperty ValidProperty = BindableProperty.Create(
            propertyName: "Valid",
            returnType: typeof(bool),
            declaringType: typeof(ValidableEntry),
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

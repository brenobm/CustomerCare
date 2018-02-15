using System;
using Xamarin.Forms;

namespace CustomerCare.Controls
{
    public class NullableDatePicker: ValidableDatePicker
    {
        public static readonly BindableProperty NullableDateProperty = BindableProperty.Create(
            propertyName: "NullableDate",
            returnType: typeof(DateTime?),
            declaringType: typeof(NullableDatePicker),
            defaultValue: null);

        public NullableDatePicker()
            : base()
        {
        }

        public DateTime? NullableDate
        {
            get { return (DateTime?)GetValue(NullableDateProperty); }
            set { SetValue(NullableDateProperty, value); UpdateDate(); }
        }

        private void UpdateDate()
        {
            if (NullableDate.HasValue)
            {
                Date = NullableDate.Value;
            }
        }
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            UpdateDate();
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == "Date")
                NullableDate = Date;
        }

    }
}

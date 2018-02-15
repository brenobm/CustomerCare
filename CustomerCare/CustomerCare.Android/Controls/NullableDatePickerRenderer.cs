using Android.Content;
using CustomerCare.Controls;
using CustomerCare.Droid.Controls;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(NullableDatePicker), typeof(NullableDatePickerRenderer))]
namespace CustomerCare.Droid.Controls
{
    public class NullableDatePickerRenderer: ValidableDatePickerRenderer
    {
        public NullableDatePickerRenderer() : base()
        {
        }

        public NullableDatePickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            var view = Element as NullableDatePicker;

            if (view != null)
            {
                SetNullableText(view);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var view = (NullableDatePicker)Element;

            if (e.PropertyName == NullableDatePicker.NullableDateProperty.PropertyName)
                SetNullableText(view);
        }

        private void SetNullableText(NullableDatePicker view)
        {
            if (view.NullableDate == null)
                Control.Text = string.Empty;
        }

    }
}
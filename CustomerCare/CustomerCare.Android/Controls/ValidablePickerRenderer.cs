using Android.Content;
using Android.Graphics.Drawables;
using CustomerCare.Controls;
using CustomerCare.Droid.Controls;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ValidablePicker), typeof(ValidablePickerRenderer))]
namespace CustomerCare.Droid.Controls
{
    public class ValidablePickerRenderer : PickerRenderer
    {
        private ValidablePicker validablePicker;
        private Android.Graphics.Color colorOrigin;

        public ValidablePickerRenderer()
#pragma warning disable CS0618 // Type or member is obsolete
            : base()
#pragma warning restore CS0618 // Type or member is obsolete
        {
            if (Control != null)
            {
                if (Control.Background is ColorDrawable)
                {
                    colorOrigin = (Control.Background as ColorDrawable).Color;
                }
            }
        }

        public ValidablePickerRenderer(Context context) : base(context)
        {
            if (Control != null)
            {
                if (Control.Background is ColorDrawable)
                {
                    colorOrigin = (Control.Background as ColorDrawable).Color;
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            ChangeColor();
        }

        private void ChangeColor()
        {
            if (Control != null)
            {
                if (!validablePicker.Valid)
                {
                    Control.SetBackgroundColor(new global::Android.Graphics.Color(245, 222, 222));
                }
                else
                {
                    Control.SetBackgroundColor(colorOrigin);
                }
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            validablePicker = e.NewElement as ValidablePicker;

            ChangeColor();
        }
    }
}
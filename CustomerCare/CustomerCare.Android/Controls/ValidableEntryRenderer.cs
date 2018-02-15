using Android.Content;
using Android.Graphics.Drawables;
using CustomerCare.Controls;
using CustomerCare.Droid.Controls;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ValidableEntry), typeof(ValidableEntryRenderer))]
namespace CustomerCare.Droid.Controls
{
    public class ValidableEntryRenderer : EntryRenderer
    {
        private ValidableEntry validableEntry;
        private Android.Graphics.Color colorOrigin;

#pragma warning disable CS0618 // Type or member is obsolete
        public ValidableEntryRenderer() : base()
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

        public ValidableEntryRenderer(Context context) : base(context)
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
                if (!validableEntry.Valid)
                {
                    Control.SetBackgroundColor(new global::Android.Graphics.Color(245, 222, 222));
                }
                else
                {
                    Control.SetBackgroundColor(colorOrigin);
                }
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            validableEntry = e.NewElement as ValidableEntry;

            ChangeColor();
        }
    }
}
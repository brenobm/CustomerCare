namespace CustomerCare.Helpers
{
    public static class ConstantsHelper
    {
        public static string UserName
        { 
            get
            {
                return App.Current.Properties["userName"]?.ToString();
            }
        }
    }
}

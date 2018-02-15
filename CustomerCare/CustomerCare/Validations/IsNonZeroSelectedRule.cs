namespace CustomerCare.Validations
{
    public class IsNonZeroSelectedRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value.ToString();
            double result;
            return double.TryParse(str, out result) && result > 0;
        }
    }
}

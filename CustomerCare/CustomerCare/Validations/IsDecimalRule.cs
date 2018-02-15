namespace CustomerCare.Validations
{
    public class IsDecimalRule<T> : IValidationRule<T>
    {
        public string ValidationMessage { get; set; }

        public bool Check(T value)
        {
            if (value == null)
            {
                return false;
            }

            var str = value.ToString();
            var converted = decimal.TryParse(str, out decimal result);

            return converted;
        }
    }
}

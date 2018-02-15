using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CustomerCare.Validations
{
    public class ValidatableObject<T> : INotifyPropertyChanged, IValidity
    {
        private readonly List<IValidationRule<T>> _validations;
        private readonly ObservableCollection<string> _errors;
        private T _value;
        private bool _isValid;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<IValidationRule<T>> Validations => _validations;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual bool SetProperty<T2>(ref T2 storage, T2 value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T2>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public ObservableCollection<string> Errors => _errors;

        public T Value
        {
            get
            {
                return _value;
            }

            set
            {
                SetProperty(ref _value, value);
            }
        }

        public bool IsValid
        {
            get
            {
                return _isValid;
            }

            set
            {
                _errors.Clear();
                SetProperty(ref _isValid, value);
            }
        }

        public ValidatableObject()
        {
            _isValid = true;
            _errors = new ObservableCollection<string>();
            _validations = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = _validations.Where(v => !v.Check(Value))
                                                     .Select(v => v.ValidationMessage);

            IsValid = !errors.Any();

            foreach (var error in errors)
            {
                Errors.Add(error);
            }

            return this.IsValid;
        }
    }

}

using CustomerCare.Models.ClientsDomain;
using CustomerCare.Services;
using CustomerCare.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomerCare.ViewModels
{
    public class NewClientViewModel: ViewModelBase, IValidableViewModel
    {
        private Client _clientModel;

        private IDataStore<Client> clientDS;

        private ValidatableObject<string> _name;

        public ValidatableObject<string> Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public Command CadastreCommand { get; set; }
        public Command ClearFieldsCommand { get; set; }
        public Command BackCommand { get; set; }
        public Command DeleteCommand { get; set; }

        public NewClientViewModel() : this(null)
        {
            Name = new ValidatableObject<string>();

            AddValidations();

            CadastreCommand = new Command(async () => await ExecuteCadastreCommand());
            ClearFieldsCommand = new Command(() => ClearFields());
            BackCommand = new Command(async () => await ExecuteBackCommand());
            DeleteCommand = new Command(async () => await ExecuteDeleteCommand());

            Initialize();

        }

        public NewClientViewModel(Client client)
        {
            _clientModel = client;

            if (client == null)
            {
                Title = "Cadastrar Cliente";
            }
            else
            {
                Title = "Editar Cliente";
            }
        }

        public void AddValidations()
        {
            _name.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Você deve preencher o nome." });
        }

        public bool Validate()
        {
            return _name.Validate();
        }

        public string GetErrorMessages()
        {
            return string.Join("\n",
                    _name.Errors);
        }

        private void Initialize()
        {
            clientDS = DependencyService.Get<IDataStore<Client>>();

            if (this._clientModel != null)
            {
                _name.Value = _clientModel.Name;
            }
        }

        private async Task ExecuteDeleteCommand()
        {
            try
            {
                clientDS.Delete(_clientModel);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(1);

                Debug.Write($"{this.GetType().FullName} - {sf.GetMethod().Name} - {ex.Message}");
            }

            await MessageService.ShowAsync("Sucesso", "Cliente excluído com Sucesso!");
            await BackPage();
        }

        private async Task ExecuteBackCommand()
        {
            await this.BackPage();
        }

        private async Task ExecuteCadastreCommand()
        {
            if (Validate())
            {
                Client client = new Client
                {
                    Name = _name.Value
                };

                if (_clientModel != null)
                {
                    client.Id = _clientModel.Id;

                    client.Name = _clientModel.Name;

                    try
                    {
                        clientDS.Update(client);
                        
                    }
                    catch (Exception ex)
                    {
                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(1);

                        Debug.Write($"{this.GetType().FullName} - {sf.GetMethod().Name} - {ex.Message}");
                    }


                    await MessageService.ShowAsync("Sucesso", "Cliente alterado com Sucesso!");
                    await BackPage();

                }
                else
                {
                    try
                    {
                        clientDS.Update(client);
                    }
                    catch (Exception ex)
                    {
                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(1);

                        Debug.Write($"{this.GetType().FullName} - {sf.GetMethod().Name} - {ex.Message}");
                    }

                    await MessageService.ShowAsync("Sucesso", "Cliente cadastrado com Sucesso!");
                }

                ClearFields();

            }
            else
            {
                await MessageService.ShowAsync("Erro", GetErrorMessages());
            }
        }

        private void ClearFields()
        {
            this.Name.Value = string.Empty;
        }
    }
}

using VisualizaClientes.Model;

namespace VisualizaClientes.ViewModel
{
    public class ClienteViewModel : ViewModelBase
    {
        public ClienteViewModel(Cliente cli)
        {
            Cliente = cli;
        }

        public Cliente Cliente { get; }


        public string CustomerId
        {
            get => Cliente.CustomerId;
            set
            {
                Cliente.CustomerId = value;
                RaisePropertyChanged("CustomerId");
            }
        }

        public string CompanyName
        {
            get => Cliente.CompanyName;
            set
            {
                Cliente.CompanyName = value;
                RaisePropertyChanged("CompanyName");
            }
        }

        public string ContactName
        {
            get => Cliente.ContactName;
            set
            {
                Cliente.ContactName = value;
                RaisePropertyChanged("ContactName");
            }
        }

        public string ContactTitle
        {
            get => Cliente.ContactTitle;
            set
            {
                Cliente.ContactTitle = value;
                RaisePropertyChanged("ContactTitle");
            }
        }

        public string Address
        {
            get => Cliente.Address;
            set
            {
                Cliente.Address = value;
                RaisePropertyChanged("Address");
            }
        }

        public string City
        {
            get => Cliente.City;
            set
            {
                Cliente.City = value;
                RaisePropertyChanged("City");
            }
        }

        public string Country
        {
            get => Cliente.Country;
            set
            {
                Cliente.Country = value;
                RaisePropertyChanged("Country");
            }
        }

        public string PostalCode
        {
            get => Cliente.PostalCode;
            set
            {
                Cliente.PostalCode = value;
                RaisePropertyChanged("PostalCode");
            }
        }

        public string Phone
        {
            get => Cliente.Phone;
            set
            {
                Cliente.Phone = value;
                RaisePropertyChanged("Phone");
            }
        }

        public string Fax
        {
            get => Cliente.Fax;
            set
            {
                Cliente.Fax = value;
                RaisePropertyChanged("Fax");
            }
        }
    }
}
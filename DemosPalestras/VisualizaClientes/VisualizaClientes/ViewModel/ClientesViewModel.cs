using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using VisualizaClientes.Model;
using VisualizaClientes.Repositorio;

namespace VisualizaClientes.ViewModel
{
    public class ClientesViewModel : ViewModelBase
    {
        private readonly IEnumerable<ClienteViewModel> clienteViewModels;
        private readonly RepositorioClientes repositorioClientes = new RepositorioClientes();

        private ICommand addCommand;
        private ObservableCollection<ClienteViewModel> clientes;

        private ICommand removeCommand;

        private ICommand saveCommand;

        private ICommand searchCommand;

        private string searchText;

        private ClienteViewModel selectedCliente;

        public ClientesViewModel()
        {
            clienteViewModels = repositorioClientes.Clientes.Select(c => new ClienteViewModel(c));
            clientes = new ObservableCollection<ClienteViewModel>(clienteViewModels);
        }

        public ClienteViewModel SelectedCliente
        {
            get => selectedCliente;
            set
            {
                selectedCliente = value;
                RaisePropertyChanged("SelectedCliente");
            }
        }

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                RaisePropertyChanged("SearchText");
            }
        }

        public ObservableCollection<ClienteViewModel> Clientes
        {
            get => clientes;
            private set
            {
                clientes = value;
                RaisePropertyChanged("Clientes");
            }
        }

        public ICommand AddCommand => addCommand ??= new RelayCommand(Addcliente, null);

        public ICommand RemoveCommand => removeCommand ??= new RelayCommand(Removecliente, c => SelectedCliente != null);

        public ICommand SaveCommand => saveCommand ??= new RelayCommand(SaveData, null);

        public ICommand SearchCommand => searchCommand ??= new RelayCommand(SearchData, null);

        private void Addcliente(object obj)
        {
            var cliente = new Cliente();
            var clienteViewModel = new ClienteViewModel(cliente);
            clientes.Add(clienteViewModel);
            repositorioClientes.Add(cliente);
            SelectedCliente = clienteViewModel;
        }

        private void Removecliente(object obj)
        {
            repositorioClientes.Remove(SelectedCliente.Cliente);
            clientes.Remove(SelectedCliente);
            SelectedCliente = null;
        }

        private void SaveData(object obj)
        {
            repositorioClientes.Commit();
        }

        private void SearchData(object obj)
        {
            Clientes = new ObservableCollection<ClienteViewModel>(
                !string.IsNullOrWhiteSpace(SearchText)
                    ? clienteViewModels.Where(c => c.Country.ToLower().Contains(SearchText.ToLower()))
                    : clienteViewModels);
        }
    }
}
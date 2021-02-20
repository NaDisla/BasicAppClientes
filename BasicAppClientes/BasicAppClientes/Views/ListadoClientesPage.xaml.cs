using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using BasicAppClientes.Popups;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;
using BasicAppClientes.Models;

namespace BasicAppClientes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListadoClientesPage : ContentPage
    {
        HttpClient client = new HttpClient();
        string contentApi;
        const string urlApi = "https://basicclientsapi.conveyor.cloud/clientes";
        ObservableCollection<Cliente> listPersons;
        const string detailLoading = "Cargando clientes...";

        public ListadoClientesPage()
        {
            InitializeComponent();
        }

        [Obsolete]
#pragma warning disable CS0809
        protected override void OnAppearing()
#pragma warning restore CS0809
        {
            base.OnAppearing();
            GetClientes();
        }

        [Obsolete]
        async void GetClientes()
        {
            try
            {
                LoadingPage loading = new LoadingPage(detailLoading);
                await PopupNavigation.PushAsync(loading);
                await Task.Delay(2000);
                contentApi = await client.GetStringAsync(urlApi);
                await PopupNavigation.RemovePageAsync(loading);

                if(string.IsNullOrEmpty(contentApi))
                {
                    await DisplayAlert("Listado vacío", "No hay clientes registrados.", "OK");
                    await Navigation.PushAsync(new MainControlPage());
                }
                else
                {
                    List<Cliente> getClients = JsonConvert.DeserializeObject<List<Cliente>>(contentApi);
                    listPersons = new ObservableCollection<Cliente>(getClients);
                    listaFrontPersonas.ItemsSource = listPersons;
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "No se ha podido obtener el listado de clientes.", "OK");
            }
        }
    }
}
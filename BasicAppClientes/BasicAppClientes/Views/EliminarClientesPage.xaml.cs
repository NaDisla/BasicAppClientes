using BasicAppClientes.Models;
using BasicAppClientes.Popups;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BasicAppClientes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EliminarClientesPage : ContentPage
    {
        HttpClient client = new HttpClient();
        const string urlApi = "https://basicclientsapi.conveyor.cloud/clientes/";
        const string detailLoading = "Buscando cliente...";
        const string detailDeleteLoading = "Eliminando cliente...";
        string searchClient, contentClient;

        public EliminarClientesPage()
        {
            InitializeComponent();
        }

        [Obsolete]
        private async void btnConsultaCliente_Clicked(object sender, EventArgs e)
        {
            searchClient = $"{urlApi}{int.Parse(txtIDCliente.Text)}";
            LoadingPage loading = new LoadingPage(detailLoading);
            await PopupNavigation.PushAsync(loading);
            await Task.Delay(2000);
            contentClient = await client.GetStringAsync(searchClient);
            var cliente = JsonConvert.DeserializeObject<Cliente>(contentClient);
            await PopupNavigation.RemovePageAsync(loading);

            try
            {
                if (cliente != null)
                {
                    layoutDelete.IsVisible = true;
                    txtNombreCliente.Text = cliente.ClienteNombre;
                    txtTelefonoCliente.Text = cliente.ClienteTelefono;
                    txtCorreoCliente.Text = cliente.ClienteCorreo;
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Error", $"No se ha encontrado un cliente con el código {int.Parse(txtIDCliente.Text)}.", "OK");
            }
        }

        [Obsolete]
        private async void btnDeleteCliente_Clicked(object sender, EventArgs e)
        {
            try
            {
                LoadingPage loading = new LoadingPage(detailDeleteLoading);
                await PopupNavigation.PushAsync(loading);
                await Task.Delay(2000);
                await client.DeleteAsync($"{urlApi}{int.Parse(txtIDCliente.Text)}");
                await PopupNavigation.RemovePageAsync(loading);
                await DisplayAlert("Cliente eliminado", "Se ha borrado el cliente correctamente.", "OK");
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "No se ha podido eliminar el cliente.", "OK");
            }
        }
    }
}
using System;
using System.Net.Http;
using System.Threading.Tasks;
using BasicAppClientes.Models;
using BasicAppClientes.Popups;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BasicAppClientes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActualizarClientesPage : ContentPage
    {
        HttpClient client = new HttpClient();
        const string urlApi = "https://basicclientsapi.conveyor.cloud/clientes/";
        const string detailLoading = "Buscando cliente...";
        const string detailUpdateLoading = "Actualizando datos...";
        string searchClient, contentClient;

        public ActualizarClientesPage()
        {
            InitializeComponent();
        }

        [Obsolete]
        private async void btnUpdateCliente_Clicked(object sender, EventArgs e)
        {
            var clienteUpdate = new Cliente()
            {
                ClienteID = int.Parse(txtIDCliente.Text),
                ClienteNombre = txtNombreCliente.Text,
                ClienteCorreo = txtCorreoCliente.Text,
                ClienteTelefono = txtTelefonoCliente.Text
            };

            try
            {
                var json = JsonConvert.SerializeObject(clienteUpdate);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                LoadingPage loading = new LoadingPage(detailUpdateLoading);
                await PopupNavigation.PushAsync(loading);
                await Task.Delay(2000);
                await client.PutAsync($"{urlApi}{int.Parse(txtIDCliente.Text)}", content);
                await PopupNavigation.RemovePageAsync(loading);
                await DisplayAlert("Datos actualizados", "Se han actualizado los datos correctamente.", "OK");
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "No se han podido actualizar los datos.", "OK");
            }
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
                    layoutUpdate.IsVisible = true;
                    txtNombreCliente.Text = cliente.ClienteNombre;
                    txtTelefonoCliente.Text = cliente.ClienteTelefono;
                    txtCorreoCliente.Text = cliente.ClienteCorreo;
                }
                else
                {
                    await DisplayAlert("Error", $"No se ha encontrado un cliente con el código {int.Parse(txtIDCliente.Text)}.", "OK");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Error", $"No se ha encontrado un cliente con el código {int.Parse(txtIDCliente.Text)}.", "OK");
            }
        }
    }
}
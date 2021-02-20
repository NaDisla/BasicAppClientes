using BasicAppClientes.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BasicAppClientes.Popups;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Services;

namespace BasicAppClientes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroClientesPage : ContentPage
    {
        HttpClient client = new HttpClient();
        const string urlApi = "https://basicclientsapi.conveyor.cloud/clientes";
        const string detailLoading = "Procesando registro...";

        public RegistroClientesPage()
        {
            InitializeComponent();
        }

        [Obsolete]
        private async void btnRegistrarCliente_Clicked(object sender, EventArgs e)
        {
            var cliente = new Cliente()
            {
                ClienteNombre = txtNombre.Text,
                ClienteTelefono = txtTelefono.Text,
                ClienteCorreo = txtCorreo.Text
            };

            try
            {
                var json = JsonConvert.SerializeObject(cliente);
                HttpContent content = new StringContent(json);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                LoadingPage loading = new LoadingPage(detailLoading);
                await PopupNavigation.PushAsync(loading);
                await Task.Delay(2000);
                await client.PostAsync(urlApi, content);
                await PopupNavigation.RemovePageAsync(loading);
                await DisplayAlert("Registro correcto", "Cliente registrado correctamente.", "OK");
            }
            catch (Exception)
            {
                await DisplayAlert("Error", "Ha ocurrido un error en la inserción.", "OK");
            }
        }
    }
}
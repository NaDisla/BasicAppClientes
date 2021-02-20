using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BasicAppClientes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainControlPage : ContentPage
    {
        public MainControlPage()
        {
            InitializeComponent();
        }

        private async void btnListado_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListadoClientesPage());
        }

        private async void btnRegistro_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistroClientesPage());
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActualizarClientesPage());
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EliminarClientesPage());
        }
    }
}
using BasicAppClientes.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BasicAppClientes
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainControlPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

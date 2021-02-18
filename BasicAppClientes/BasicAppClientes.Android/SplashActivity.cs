using Android.App;
using Android.Content;
using Android.OS;

namespace BasicAppClientes.Droid
{
    [Activity(Label = "BasicAppClientes", MainLauncher = true, Theme = "@style/SplashTheme", NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}
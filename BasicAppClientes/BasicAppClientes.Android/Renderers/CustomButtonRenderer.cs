using BasicAppClientes.Droid.Renderers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

#pragma warning disable CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRenderer))]
#pragma warning restore CS0612 // Type or member is obsolete
namespace BasicAppClientes.Droid.Renderers
{
    [Obsolete]
    public class CustomButtonRenderer : ButtonRenderer
    {
        public CustomButtonRenderer()
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            Control.SetAllCaps(false);
        }
    }
}
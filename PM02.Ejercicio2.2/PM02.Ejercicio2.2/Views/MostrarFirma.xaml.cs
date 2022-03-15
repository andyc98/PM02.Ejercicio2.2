using PM02.Ejercicio2._2.Features;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM02.Ejercicio2._2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class MostrarFirma : ContentPage
{
    public MostrarFirma(Firmas firmas)
    {
        InitializeComponent();
            name.Text = firmas.nombre;
            description.Text = firmas.description;
            imageSignature.Source = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(firmas.image)));
        }
}
}
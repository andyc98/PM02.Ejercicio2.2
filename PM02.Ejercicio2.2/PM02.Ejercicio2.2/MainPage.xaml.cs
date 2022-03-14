using PM02.Ejercicio2._2.Features;
using PM02.Ejercicio2._2.Views;
using SignaturePad.Forms;
using System;
using System.IO;
using Xamarin.Forms;

namespace PM02.Ejercicio2._2
{
    public partial class MainPage : ContentPage
    {
        string valueBase64;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            Stream image = await Firma.GetImageStreamAsync(SignatureImageFormat.Png);
           
            var mStream = (MemoryStream)image;
            byte[] data = mStream.ToArray();
            valueBase64 = Convert.ToBase64String(data);


            if (String.IsNullOrWhiteSpace(txt_nombre.Text) || String.IsNullOrWhiteSpace(txt_descripcion.Text))
            {
                await DisplayAlert("ERROR", "SE DEBEN DE LLENAR LOS DATOS DE NOMBRE Y DESCRIPCION PARA GUARDAR", "ACEPTAR");
            }

            var signatureToSave = new Firmas
            {
                image = valueBase64,
                nombre = txt_nombre.Text,
                description = txt_descripcion.Text
            };

            var result = await App.BaseDatos.guardarfirma(signatureToSave);

            if (result != 1)
            {
                await DisplayAlert("ERROR", "OCURRIO UN ERROR, INTENTE DE NUEVO", "ACEPTAR");
            }

            await DisplayAlert("AVISO", "GUARDADO CORRECTAMENTE", "ACEPTAR");
        }

        private async void ViewSignaturesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaFirmas());
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            Firma.Clear();
        }
    }
}

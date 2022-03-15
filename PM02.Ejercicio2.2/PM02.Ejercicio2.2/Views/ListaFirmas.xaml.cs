using PM02.Ejercicio2._2.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM02.Ejercicio2._2.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class ListaFirmas : ContentPage
{
    public ListaFirmas()
    {
        InitializeComponent();
    }


     protected override void OnAppearing()
        {

            base.OnAppearing();
            LoadCollectionView();
        }

        private async void LoadCollectionView()
        {
            listafirmas.ItemsSource = await App.BaseDatos.GetListFirmas();
        }

        private async void listSignatures_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelected = (Firmas)e.SelectedItem;

            var signatureObtained = await App.BaseDatos.GetFirmaPorId(itemSelected.id);

            var showSignatureInformationPage = new MostrarFirma(signatureObtained);

            await Navigation.PushAsync(showSignatureInformationPage);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProiectMobil.Data;
using ProiectMobil.Models;


namespace ProiectMobil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstPage : ContentPage
    {
        public FirstPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Confirmare", "Doriti sa confirmati rezervarea?", "OK");
            var programare = (Programari)BindingContext;
            //await DisplayAlert("Info", programare.Nume_client, "OK");
            programare.Id_salon = 1;
            await App.Database.SaveProgramareAsync(programare);
            listView.ItemsSource = await App.Database.GetProgramariAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var programare = (Programari)BindingContext;
            await App.Database.DeleteProgramareAsync(programare);
            listView.ItemsSource = await App.Database.GetProgramariAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new Programari();
            //listView.ItemsSource = await App.Database.GetProgramariAsync();
        }
        async void OnProgramareClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FirstPage
            {
                BindingContext = new Programari()
            });
        }

        async void OnAngajatiClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AngajatiPage
            {
                BindingContext = new Angajati()
            });
        }
    }
}
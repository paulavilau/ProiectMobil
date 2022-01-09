using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ProiectMobil.Models;
using ProiectMobil.Data;

namespace ProiectMobil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AngajatiPage : ContentPage
    {
        public AngajatiPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var angajat = (Angajati)BindingContext;
            //await DisplayAlert("Info", programare.Nume_client, "OK");
            await App.Database.SaveAngAsync(angajat);
            listView.ItemsSource = await App.Database.GetAngsAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var angajat = (Angajati)BindingContext;
            await App.Database.DeleteAngAsync(angajat);
            listView.ItemsSource = await App.Database.GetAngsAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new Angajati();
            listView.ItemsSource = await App.Database.GetAngsAsync();
        }

        async void OnAngajatiClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AngajatiPage
            {
                BindingContext = new Angajati()
            });
        }

        async void OnProgramareClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FirstPage
            {
                BindingContext = new Programari()
            });
        }
    }
}

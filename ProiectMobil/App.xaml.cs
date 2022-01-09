using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using ProiectMobil.Data;

namespace ProiectMobil
{
    public partial class App : Application
    {

        static SalonDB database;
        public static SalonDB Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   SalonDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "Programari.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FirstPage());
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

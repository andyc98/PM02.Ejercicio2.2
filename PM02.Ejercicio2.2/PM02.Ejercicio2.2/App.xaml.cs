using PM02.Ejercicio2._2.DataContext;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM02.Ejercicio2._2
{
    public partial class App : Application
    {

        static Context database;

        public static Context BaseDatos
        {
            get
            {
                if (database == null)
                {
                    database = new Context(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PM02Ejercicio2.2.db3"));
                }

                return database;
            }

        }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
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

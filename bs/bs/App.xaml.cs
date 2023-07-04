using bs.Services;
using bs.ViewModels;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bs
{
    public partial class App : Application
    {
        private static DatabaseHelper db;

        public static DatabaseHelper MyDatabase
        {
            get
            {
                if (db == null)
                {
                    db = new DatabaseHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyStore.db3"));
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new Page1();
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

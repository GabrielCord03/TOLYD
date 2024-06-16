using System;
using TOLYD.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace TOLYD
{
    public partial class App : Application
    {
        static Conexao database;
        public static Conexao Database
        {
            get
            {
                if (database == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TOLYD.db3");
                    database = new Conexao(dbPath);
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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

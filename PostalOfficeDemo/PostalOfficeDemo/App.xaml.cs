using PostalOfficeDemo.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PostalOfficeDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ItemListPage();
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

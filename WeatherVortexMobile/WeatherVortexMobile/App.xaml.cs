namespace WeatherVortexMobile
{
    using System;

    using WeatherVortexMobile.Services;
    using WeatherVortexMobile.Views;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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

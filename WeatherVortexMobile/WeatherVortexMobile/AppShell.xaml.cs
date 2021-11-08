namespace WeatherVortexMobile
{
    using System;
    using System.Diagnostics;

    using WeatherVortexMobile.Services;
    using WeatherVortexMobile.Views;

    using Xamarin.Essentials;
    using Xamarin.Forms;

    /// <summary>
    /// Shell navigation class.
    /// </summary>
    public partial class AppShell : Shell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppShell"/> class.
        /// </summary>
        public AppShell()
        {
            this.InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            var store = DependencyService.Get<ForecastsDataStore>();
            if (store != null)
            {
                try
                {
                    var res = await store.LogoutAsync();
                    if (res)
                    {
                        await Shell.Current.GoToAsync("//LoginPage");
                    }
                    else
                    {
                        await MainThread.InvokeOnMainThreadAsync(async () =>
                        await Application.Current.MainPage.DisplayAlert("Logout error", "Logout error", "Bad..."));
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Logout exception:", ex.Message);
                }
            }
        }
    }
}

namespace WeatherVortexMobile.ViewModels
{
    using System;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using MvvmHelpers;

    using WeatherVortexMobile.Services;

    using Xamarin.Essentials;
    using Xamarin.Forms;

    public class AboutViewModel : BaseViewModel
    {
        ForecastsDataStore store = DependencyService.Get<ForecastsDataStore>();

        private string _serviceStatus;
        public string ServiceStatus
        {
            get => _serviceStatus;
            set => SetProperty(ref this._serviceStatus, value);
        }

        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
            Task.Run(async () =>
            {
                var info = await store.GetInfoAsync();
                ServiceStatus = info.Result;
            });
        }

        public ICommand OpenWebCommand { get; }
    }
}
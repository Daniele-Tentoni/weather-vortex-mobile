namespace WeatherVortexMobile.ViewModels
{
    using System;
    using System.Diagnostics;

    using MvvmHelpers;

    using WeatherVortexMobile.Services;
    using WeatherVortexMobile.Views;

    using Xamarin.Essentials;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {
        private readonly ForecastsDataStore store = DependencyService.Get<ForecastsDataStore>();
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }
        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {
                var res = await store.LoginAsync(Email, Password);
                if (!res.IsAuth)
                {
                    await MainThread.InvokeOnMainThreadAsync(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert("Login failed", "Failed to login", "Bad...");
                    });
                    return;
                }
                // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception: {e.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnRegisterClicked(object obj)
        {
            if (IsBusy) return;
            IsBusy = true;

            try
            {
                var res = store.RegisterAsync(Email, Password);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Exception: {e.Message}");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}

namespace WeatherVortexMobile.ViewModels
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    using MvvmHelpers;

    using WeatherVortexMobile.Services;

    using Xamarin.Essentials;
    using Xamarin.Forms;

    class ProfileViewModel : BaseViewModel
    {
        private User user;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfileViewModel"/> class.
        /// </summary>
        public ProfileViewModel()
        {
            this.Title = "User Profile";
            this.LoadUserCommand = new Command(async () => await this.ExecuteLoadUser());
        }

        /// <summary>
        /// Gets or sets profile value.
        /// </summary>
        public User User { get => this.user; set => this.SetProperty(ref this.user, value); }

        public Command LoadUserCommand { get; }

        private async Task ExecuteLoadUser()
        {
            if (this.IsBusy)
            {
                return;
            }

            this.IsBusy = true;
            try
            {
                var profile = await DependencyService.Get<ForecastsDataStore>().GetProfileAsync();
                if (profile == null)
                {
                    await MainThread.InvokeOnMainThreadAsync(async () => await Application.Current.MainPage.DisplayAlert("Error", "Error", "Bad..."));
                    return;
                }

                this.User = profile;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception:", e.Message);
            }
            finally
            {
                this.IsBusy = false;
            }
        }
    }
}

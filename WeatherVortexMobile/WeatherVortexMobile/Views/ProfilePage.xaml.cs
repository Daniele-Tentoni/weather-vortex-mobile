namespace WeatherVortexMobile.Views
{
    using WeatherVortexMobile.ViewModels;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// User profile page.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private readonly ProfileViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProfilePage"/> class.
        /// </summary>
        public ProfilePage()
        {
            this.InitializeComponent();
            this.BindingContext = this.viewModel = new ProfileViewModel();
        }

        /// <inheritdoc/>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (this.viewModel?.User == null)
            {
                this.viewModel?.LoadUserCommand?.Execute(null);
            }
        }
    }
}
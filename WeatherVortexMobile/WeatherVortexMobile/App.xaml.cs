namespace WeatherVortexMobile
{
    using WeatherVortexMobile.Services;

    using Xamarin.Forms;

    public partial class App : Application
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="App"/> class.
        /// </summary>
        public App()
        {
            InitializeComponent();

            DependencyService.Register<ForecastsDataStore>();
            this.MainPage = new AppShell();
        }

        /// <inheritdoc/>
        protected override void OnStart()
        {
        }

        /// <inheritdoc/>
        protected override void OnSleep()
        {
        }

        /// <inheritdoc/>
        protected override void OnResume()
        {
        }
    }
}

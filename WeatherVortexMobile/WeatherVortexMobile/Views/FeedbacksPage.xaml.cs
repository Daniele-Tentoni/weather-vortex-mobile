namespace WeatherVortexMobile.Views
{
    using WeatherVortexMobile.ViewModels;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// Code behind of FeedbacksPage.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeedbacksPage : ContentPage
    {
        private readonly FeedbacksViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedbacksPage"/> class.
        /// </summary>
        public FeedbacksPage()
        {
            this.InitializeComponent();
            this.BindingContext = this.viewModel = new FeedbacksViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (this.viewModel?.Feedbacks?.Count == 0)
            {
                this.viewModel?.LoadFeedbacksCommand.Execute(null);
            }
        }
    }
}
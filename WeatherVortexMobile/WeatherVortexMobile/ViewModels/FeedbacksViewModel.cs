namespace WeatherVortexMobile.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using MvvmHelpers;

    using WeatherVortexMobile.Models;
    using WeatherVortexMobile.Services;

    using Xamarin.Forms;

    /// <summary>
    /// ViewModel for Feedbacks page.
    /// </summary>
    public class FeedbacksViewModel : BaseViewModel
    {
        private Feedback selectedItem;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedbacksViewModel"/> class.
        /// </summary>
        public FeedbacksViewModel()
        {
            this.Title = "Feedbacks";
            this.Feedbacks = new ObservableCollection<Feedback>();
            this.LoadFeedbacksCommand = new Command(async () => await this.ExecuteLoadFeedbacksCommand());
        }

        public ObservableCollection<Feedback> Feedbacks { get; }

        public Command LoadFeedbacksCommand { get; }

        private async Task ExecuteLoadFeedbacksCommand()
        {
            if (this.IsBusy)
            {
                return;
            }

            this.IsBusy = true;
            try
            {
                this.Feedbacks.Clear();
                var feedbacks = await DependencyService.Get<ForecastsDataStore>().GetFeedbacksAsync();
                feedbacks.Results?
                    .ToList()
                    .ForEach(elem
                    => elem.Feedbacks?
                        .ToList()
                        .ForEach(each
                        => this.Feedbacks
                            .Add(each)
                        )
                    );
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception:", e);
            }
            finally
            {
                this.IsBusy = false;
            }
        }
    }
}

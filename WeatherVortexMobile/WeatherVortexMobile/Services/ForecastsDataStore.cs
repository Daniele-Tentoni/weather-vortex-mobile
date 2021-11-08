namespace WeatherVortexMobile.Services
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Refit;

    using WeatherVortexMobile.Models;

    /// <summary>
    /// Remote data store of weather vortex data.
    /// </summary>
    internal class ForecastsDataStore
    {
        private readonly string url = "https://weather-vortex-server.herokuapp.com/";
        private readonly Uri uri;
        private readonly IWeatherVortex api;
        private readonly CookieContainer container;
        private string  auth;

        /// <summary>
        /// Initializes a new instance of the <see cref="ForecastsDataStore"/> class.
        /// </summary>
        public ForecastsDataStore()
        {
            uri = new Uri(url);
            container = new CookieContainer();
            var handler = new HttpClientHandler()
            {
                UseCookies = true,
                CookieContainer = container,
            };
            var client = new HttpClient(handler)
            {
                BaseAddress = uri,
            };
            this.api = RestService.For<IWeatherVortex>(client);
        }

        /// <summary>
        /// Retrieve service info from remote server.
        /// </summary>
        /// <returns>A <see cref="Task{Info}"/> representing the result of the asynchronous operation.</returns>
        public async Task<Info> GetInfoAsync()
        {
            var res = await this.api.GetInfoAsync();
            return res;
        }

        public async Task<Login> LoginAsync(string email, string password)
        {
            var res = await this.api.LoginAsync(new Credentials
            {
                Email = email,
                Password = password,
            });
            var cookies = res.Content;
            var coo = container.GetCookies(uri);
            var cook = coo["auth"];
            this.auth = cook.Value;
            return cookies;
        }

        public async Task<bool> LogoutAsync()
        {
            if (string.IsNullOrWhiteSpace(this.auth))
            {
                return true;
            }

            await this.api.LogoutAsync(this.auth);
            return true;
        }

        public async Task<Registered> RegisterAsync(string email, string password)
        {
            var res = await this.api.RegisterUserAsync(new RegisterData
            {
                Email = email,
                Password = password,
            });
            return res;
        }

        public async Task<User> GetProfileAsync()
        {
            var res = await this.api.GetUserDataAsync(this.auth);
            return res;
        }

        public async Task<Feedbacks> GetFeedbacksAsync()
        {
            var res = await this.api.GetFeedbacksAsync();
            return res;
        }
    }
}
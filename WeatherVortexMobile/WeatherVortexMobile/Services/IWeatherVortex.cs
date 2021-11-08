namespace WeatherVortexMobile.Services
{
    using System.Runtime.Serialization;
    using System.Threading.Tasks;

    using Refit;

    using WeatherVortexMobile.Models;

    public interface IWeatherVortex
    {
        /// <summary>
        /// Get service info from remote server.
        /// </summary>
        /// <returns>A <see cref="Task{Info}"/> representing the result of the asynchronous operation.</returns>
        [Get("/")]
        Task<Info> GetInfoAsync();

        /// <summary>
        /// Register a new user to weather vortex.
        /// </summary>
        /// <param name="registerData">Registration data to use.</param>
        /// <returns>Registered data received.</returns>
        [Post("/auth/register")]
        Task<Registered> RegisterUserAsync([Body] RegisterData registerData);

        /// <summary>
        /// Login a user to weather vortex.
        /// </summary>
        /// <param name="credentials">Credentials to provide.</param>
        /// <returns>Login result.</returns>
        [Post("/auth/login")]
        Task<ApiResponse<Login>> LoginAsync([Body] Credentials credentials);

        /// <summary>
        /// Execute the logout from the server.
        /// </summary>
        /// <param name="auth">Authentication token.</param>
        /// <returns>Logout result.</returns>
        [Get("/auth/logout")]
        Task LogoutAsync([Header("Cookie")] string auth);

        /// <summary>
        /// Get profile information.
        /// </summary>
        /// <param name="auth">Authentication token.</param>
        /// <returns>Profile information.</returns>
        [Get("/auth/profile")]
        Task<User> GetUserDataAsync([Header("Cookie")] string auth);

        [Get("/feedbacks")]
        Task<Feedbacks> GetFeedbacksAsync();
    }
}
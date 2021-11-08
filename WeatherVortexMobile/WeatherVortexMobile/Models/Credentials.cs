namespace WeatherVortexMobile.Models
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Users credentials.
    /// </summary>
    public class Credentials
    {
        /// <summary>
        /// Gets or sets user email.
        /// </summary>
        [DataMember(Name = "email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets user password.
        /// </summary>
        [DataMember(Name = "password")]
        public string Password { get; set; }
    }
}
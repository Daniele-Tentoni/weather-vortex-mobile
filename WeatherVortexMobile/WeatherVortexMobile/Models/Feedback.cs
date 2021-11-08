namespace WeatherVortexMobile.Models
{
    using System.Runtime.Serialization;

    using WeatherVortexMobile.Services;

    /// <summary>
    /// User's feedback.
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// Gets or sets feedback rating from 0 to 5.
        /// </summary>
        [DataMember(Name = "rating")]
        public int Rating { get; set; }

        /// <summary>
        /// Gets or sets userId of the feedback Giver.
        /// </summary>
        [DataMember(Name = "user")]
        public User User { get; set; }

        /// <summary>
        /// Gets or sets (Optional) additional description by the user.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}
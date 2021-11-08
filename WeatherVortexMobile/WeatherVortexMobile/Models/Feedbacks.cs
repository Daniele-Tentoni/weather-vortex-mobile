namespace WeatherVortexMobile.Models
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using WeatherVortexMobile.Services;

    /// <summary>
    /// Feedbacks results.
    /// </summary>
    public class Feedbacks
    {
        /// <summary>
        /// Gets or sets results.
        /// </summary>
        [DataMember(Name = "results")]
        public IEnumerable<Provider> Results { get; set; }
    }
}
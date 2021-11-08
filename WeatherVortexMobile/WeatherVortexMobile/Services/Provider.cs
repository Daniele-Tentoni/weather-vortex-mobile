namespace WeatherVortexMobile.Services
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;

    using Refit;

    using WeatherVortexMobile.Models;

    public class Provider
    {
        /// <summary>
        /// Provider name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "feedbacks")]
        public IEnumerable<Feedback> Feedbacks { get; set; }
    }
}
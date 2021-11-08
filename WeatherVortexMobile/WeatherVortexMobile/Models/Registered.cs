namespace WeatherVortexMobile.Services
{
    using System.Runtime.Serialization;

    public class Registered
    {
        [DataMember(Name = "success")]
        public bool Success { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "user")]
        public User User { get; set; }
    }
}
namespace WeatherVortexMobile.Services
{
    using System.Runtime.Serialization;

    public class Login
    {
        [DataMember(Name = "isAuth")]
        public bool IsAuth { get; set; }

        [DataMember(Name = "user")]
        public User User { get; set; }
    }
}
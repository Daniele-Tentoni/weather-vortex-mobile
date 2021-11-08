namespace WeatherVortexMobile.Services
{
    using System.Runtime.Serialization;

    public class Info
    {
        [DataMember(Name = "result")]
        public string Result { get; set; }
    }
}
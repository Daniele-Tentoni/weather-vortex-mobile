namespace WeatherVortexMobile.Services
{
    using System.Runtime.Serialization;

    public class User
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        public string FullName { get => $"{this.FirstName} {this.LastName}"; }
    }
}
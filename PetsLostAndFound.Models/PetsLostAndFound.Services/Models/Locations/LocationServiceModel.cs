namespace PetsLostAndFound.Services.Models.Locations
{
    using PetsLostAndFound.Common.Mapping;
    using PetsLostAndFound.Db.Models;

    public class LocationServiceModel : IMapFrom<Location>
    {
        public string Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; } 
    }
}

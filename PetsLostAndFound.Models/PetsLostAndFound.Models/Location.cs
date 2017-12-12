using  System.Device.Location;

namespace PetsLostAndFound.Models
{
    
    public class Location
    {
        public int Id { get; set; }

        public GeoCoordinate GeoCoordinate { get; set; }
    }
}
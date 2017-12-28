namespace PetsLostAndFound.Data.Models
{
    using System.Device.Location;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Location
    {
        public Location()
        {
            this.Reports = new List<Report>();
        }

        public int Id { get; set; }
        
        [NotMapped]
        public GeoCoordinate GeoCoordinate { get; set; }

        public string Town { get; set; }

        public ICollection<Report> Reports { get; set; }
    }
}
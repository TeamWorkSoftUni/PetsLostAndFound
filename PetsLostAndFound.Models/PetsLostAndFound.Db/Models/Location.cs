namespace PetsLostAndFound.Db.Models
{
    using System.Collections.Generic;

    public class Location
    {
        public Location()
        {
            this.Reports = new List<Report>();
        }

        public int Id { get; set; }

        public string Town { get; set; }

        public ICollection<Report> Reports { get; set; }
    }
}
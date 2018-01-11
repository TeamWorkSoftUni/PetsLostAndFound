namespace PetsLostAndFound.Services.Implementations
{
    using PetsLostAndFound.Db;
    using PetsLostAndFound.Db.Models;

    public class LocationSevices : ILocationSevices
    {
        private readonly PetsDbContext db;

        public LocationSevices(PetsDbContext db)
        {
            this.db = db;
        }

        public int Create(string address, double latitude, double longitude)
        {
            var location = new Location
            {
                Address = address,
                Latitude = latitude,
                Longitude = longitude
            };

            this.db.Locations.Add(location);
            this.db.SaveChanges();

            return location.Id;
        }
    }
}

namespace PetsLostAndFound.Services
{

    public interface ILocationSevices
    {
        int Create( string address, double Latitude, double Longitude );
    }
}

namespace PetsLostAndFound.Common
{
    using PetsLostAndFound.Db.Models;

    public class ResponseMessage
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public string Content { get; set; }

        public Report Report { get; set; }
    }
}

namespace PetsLostAndFound.Web.Models.Reports
{
    using System;
    using System.Collections.Generic;
    using Db.Models;
    using Db.Models.Enums;

    public class PostCreateReportRequestModel
    {
        public string StatusType { get; set; }

        public DateTime LostFoundDate { get; set; }

        public string Content { get; set; }

        public string Rfid { get; set; }

        public double RewardSum { get; set; }

        public Location Location { get; set; }

        public string UserId { get; set; }

        public Pet TargetPet { get; set; }

        public IEnumerable<string> TargetPetImagesId { get; set; }
    }
}

//"location": {
//"locationAdress": "BG Shirke Rd, Magarpatta City, Hadapsar, Pune, Maharashtra, Индия",
//"latitude": 42.69761870000001,
//"longitude": 23.319110300000034
//}

//"targetPet": {
//"petType": "dog",
//"petName": "Chochko",
//"age": 1,
//"description": "Big fat mother fucker..."
//}
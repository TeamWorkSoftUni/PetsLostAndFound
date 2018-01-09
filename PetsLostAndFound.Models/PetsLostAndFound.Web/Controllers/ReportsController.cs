namespace PetsLostAndFound.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Models.Reports;
    using PetsLostAndFound.Services;

    public class ReportsController : BaseController
    {

        private readonly IReportService reports;

        public ReportsController(IReportService reports)
        {
            this.reports = reports;
        }

        [HttpGet]
        public IActionResult All()
        {
            return Ok(this.reports.AllListing());
        }

        [HttpPost]
        public IActionResult Create([FromBody] PostCreateReportRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            //TODO 
            //TargetPetImagesId is coming as IEnumerable but the service is expecting string

            //var result = this.reports.Create(
            //    model.StatusType,
            //    model.UserId,
            //    model.TargetPetImagesId,
            //    model.RewardSum,
            //    model.TargetPet,
            //    model.Content,
            //    model.UserId);

            return this.Ok(); //result
        }
    }
}

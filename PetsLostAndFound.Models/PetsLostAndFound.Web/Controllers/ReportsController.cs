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
            var allReports = this.reports.AllListing();
            return Ok(allReports);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PostCreateReportRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var message = this.reports.Create(
                model.StatusType,
                model.LostFoundDate,
                model.UserId,
                model.TargetPetImagesId,
                model.RewardSum,
                model.TargetPet,
                model.Content,
                model.Location             
                );

            return this.Ok(message);
                  }
    }
}

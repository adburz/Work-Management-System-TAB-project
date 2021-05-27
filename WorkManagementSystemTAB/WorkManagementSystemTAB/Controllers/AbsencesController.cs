using Microsoft.AspNetCore.Mvc;
using WorkManagementSystemTAB.Services.Absences;

namespace WorkManagementSystemTAB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsencesController : ControllerBase
    {
        private readonly IAbsencesService _absenceService;
        public AbsencesController(IAbsencesService absenceService) {
            this._absenceService = absenceService;
        }

        [HttpGet]
        public IActionResult GetAbsences() {
            var absences = _absenceService.GetAll();
            return Ok(absences);
        }
    }
}

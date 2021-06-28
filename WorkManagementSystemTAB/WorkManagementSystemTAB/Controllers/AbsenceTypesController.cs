using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagementSystemTAB.Services.AbsenceTypes;

namespace WorkManagementSystemTAB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbsenceTypesController : ControllerBase
    {
        private readonly IAbsenceTypesService _absenceTypesService;
        public AbsenceTypesController(IAbsenceTypesService absenceTypesService) {
            _absenceTypesService = absenceTypesService;
        }
        [HttpGet]
        public IActionResult GetAbsenceTypes() {
            var absenceTypes = _absenceTypesService.GetAll();
            return Ok(absenceTypes);
        }
    }
}

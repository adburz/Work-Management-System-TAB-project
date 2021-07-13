using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Services.Absences;

namespace WorkManagementSystemTAB.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AbsencesController : BaseAccessController
    {
        private readonly IAbsencesService _absenceService;
        public AbsencesController(IAbsencesService absenceService)
        {
            _absenceService = absenceService;
        }


        /// <summary>
        /// tutej mozna dac opis
        /// </summary>
        /// <remarks>
        /// a tu cos innego
        /// </remarks>
        [HttpGet]
        public IActionResult GetAbsences()
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var absences = _absenceService.GetAll();

            return Ok(absences);
        }

        [HttpGet("worker/{id}")]
        public IActionResult GetAllWorkerAbsences(Guid id)
        {
            if (!_absenceService.IsAuthor(id, LoggedUserEmail) && !IsManagerOrAbove())
                return Unauthorized();

            var allWorkerAbsences = _absenceService.GetAllWorkerAbsensces(id);

            if (allWorkerAbsences == null)
                return NotFound();

            return Ok(allWorkerAbsences);
        }

        [HttpGet("active")]
        public IActionResult GetAllActiveAbsences()
        {
            if (IsWorker())
                return Unauthorized();

            return Ok(_absenceService.GetAllActive());
        }

        [HttpGet("active/worker/{id}")]
        public IActionResult GetAllActiveWorkerAbsences(Guid id) //active == not confirmed
        {
            if (!_absenceService.IsAuthor(id, LoggedUserEmail) && !IsManagerOrAbove())
                return Unauthorized();

            var allActiveWorkerAbsences = _absenceService.GetAllActiveWorkerAbsences(id);

            if (allActiveWorkerAbsences == null)
                return NotFound();

            return Ok(allActiveWorkerAbsences);
        }

        [HttpGet("confirmed")]
        public IActionResult GetAllConfirmedAbsences()
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            return Ok(_absenceService.GetAllConfirmed());
        }

        [HttpGet("confirmed/worker/{id}")]
        public IActionResult GetAllConfirmedWorkerAbsences(Guid id) //active == not confirmed
        {
            if (!_absenceService.IsAuthor(id, LoggedUserEmail) && !IsManagerOrAbove())
                return Unauthorized();

            var allConfirmedWorkerAbsences = _absenceService.GetAllConfirmedeWorkerAbsences(id);

            if (allConfirmedWorkerAbsences == null)
                return NotFound();

            return Ok(allConfirmedWorkerAbsences);
        }


        [HttpGet("id/{id}")]
        public IActionResult GetAbsenceById(Guid id)
        {
            var absence = _absenceService.GetById(id);

            if (absence == null)
                return NotFound();

            if (!_absenceService.IsAuthor(absence, LoggedUserEmail) && !IsManagerOrAbove())
                return Unauthorized();

            return Ok(absence);
        }

        [HttpGet("approve/{id}")]
        public IActionResult ApproveAbsence(Guid id)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var result = _absenceService.Approve(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("find-replacement/{id}")]
        public IActionResult FindReplacemnt(Guid id)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var replacments = _absenceService.FindReplacment(id);
            if (replacments == null)
                return NotFound();

            return Ok(replacments);
        }

        [HttpPost]
        public IActionResult AddAbsence(AbsenceDTO absenceDTO)
        {
            var newAbsence = _absenceService.Add(absenceDTO);

            if (newAbsence == null)
                return BadRequest(new { Success = false, Error = "There was an error (multiple requests)" });

            return Ok(newAbsence);
        }

        [HttpPut]
        public IActionResult UpdateAbsence(Absence absence)
        {
            if (!_absenceService.IsAuthor(absence, LoggedUserEmail) && !IsManagerOrAbove())
                return Unauthorized();

            var result = _absenceService.Update(absence);
            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpDelete("id/{id}")]
        public IActionResult DeleteAbsence(Guid id)
        {
            var absence = _absenceService.GetById(id);

            if (absence == null)
                return NotFound();

            if (!_absenceService.IsAuthor(absence, LoggedUserEmail) && !IsManagerOrAbove())
                return Unauthorized();

            _absenceService.Delete(id);

            return Ok();
        }
    }
}

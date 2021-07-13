﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkManagementSystemTAB.DTO.Request;
using WorkManagementSystemTAB.Models;
using WorkManagementSystemTAB.Services.AbsenceTypes;

namespace WorkManagementSystemTAB.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AbsenceTypesController : BaseAccessController
    {
        private readonly IAbsenceTypesService _absenceTypesService;
        public AbsenceTypesController(IAbsenceTypesService absenceTypesService)
        {
            _absenceTypesService = absenceTypesService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAbsenceTypes()
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var absenceTypes = _absenceTypesService.GetAll();

            if (absenceTypes == null)
                return NotFound();

            return Ok(absenceTypes);
        }

        [HttpGet("id/{id}")]
        public IActionResult GetAbsenceTypeById(Guid id)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var result = _absenceTypesService.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetAbsenceTypeByName(string name)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var result = _absenceTypesService.GetByName(name);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddAbsenceType([FromBody] AbsenceTypeDTO absenceTypeRequest)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var result = _absenceTypesService.Add(absenceTypeRequest);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        public IActionResult ModifyAbsenceType([FromBody] AbsenceType absenceTypeRequest)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var result = _absenceTypesService.Update(absenceTypeRequest);
            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpDelete("id/{id}")]
        public IActionResult DeleteAbsenceType(Guid id)
        {
            if (!IsManagerOrAbove())
                return Unauthorized();

            var result = _absenceTypesService.GetById(id);

            if (result == null)
                return NotFound();

            _absenceTypesService.Delete(id);

            return Ok();
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace zadanie5
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitController : ControllerBase
    {
        private static List<Visit> _visits = new List<Visit>();

        [HttpGet("animal/{animalId}")]
        public ActionResult<IEnumerable<Visit>> GetVisitsByAnimalId(int animalId)
        {
            var visits = _visits.Where(v => v.AnimalId == animalId).ToList();
            return Ok(visits);
        }

        [HttpPost]
        public ActionResult<Visit> AddVisit(Visit visit)
        {
            visit.Id = _visits.Count + 1;
            _visits.Add(visit);
            return CreatedAtAction(nameof(GetVisitById), new { id = visit.Id }, visit);
        }

        [HttpGet("{id}")]
        public ActionResult<Visit> GetVisitById(int id)
        {
            var visit = _visits.FirstOrDefault(v => v.Id == id);
            if (visit == null)
            {
                return NotFound();
            }
            return Ok(visit);
        }
    }
}
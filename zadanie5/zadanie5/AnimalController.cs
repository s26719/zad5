using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace zadanie5
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private static List<Animal> _animals = new List<Animal>();

        [HttpGet]
        public ActionResult<IEnumerable<Animal>> GetAnimals()
        {
            return Ok(_animals);
        }

        [HttpGet("{id}")]
        public ActionResult<Animal> GetAnimalById(int id)
        {
            var animal = _animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return NotFound();
            }
            return Ok(animal);
        }

        [HttpPost]
        public ActionResult<Animal> AddAnimal(Animal animal)
        {
            animal.Id = _animals.Count + 1;
            _animals.Add(animal);
            return CreatedAtAction(nameof(GetAnimalById), new { id = animal.Id }, animal);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, Animal updatedAnimal)
        {
            var animal = _animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return NotFound();
            }
            animal.Name = updatedAnimal.Name;
            animal.Category = updatedAnimal.Category;
            animal.Weight = updatedAnimal.Weight;
            animal.Color = updatedAnimal.Color;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animal = _animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return NotFound();
            }
            _animals.Remove(animal);
            return NoContent();
        }
    }
}

using Animal.DTOs;
using Animal.Entities;
using Animal.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Animal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class AnimalController : ControllerBase
    {
        private readonly IAnimal _repo;
        public AnimalController(IAnimal repo)
        {
            _repo = repo;
        }

        //Get/api/Animal
        [HttpGet]
        [Route("")]
        public IActionResult GetAnimals()
        {
            var animals = _repo.GetAllAnimals().Select(a => new AnimalDTO
            {
                Id = a.Id,
                AnimalType = a.AnimalType,
                Name = a.Name,
            }).OrderByDescending(x => x.AnimalType);
            return Ok(animals);

        }

        //Get/api/Animal/:animalId
        [HttpGet]
        [Route("{animalId}")]
        public IActionResult GetAnimalById(int animalId)
        {
            var animal = _repo.GetAnimalById(animalId);
            if (animal == null)
            {
                return NotFound("could not find animal with id: " + animalId.ToString());
            }
            AnimalDTO animalDTO = MapAnimalToAnimallDTO(animal);
            return Ok(animalDTO);

        }

        
        [HttpDelete]
        [Route("{animalId}")]
        public IActionResult DeleteAnimal(int animalId)
        {
            _repo.DeleteAnimalById(animalId);
            return NoContent();

        }

        [HttpPost("")]
        public IActionResult CreateAnimal([FromBody] CreateAnimalDTO createAnimalDTO)
        {
            EAnimal createdAnimal = _repo.CreateEAnimal(createAnimalDTO);
            AnimalDTO animalDTO = MapAnimalToAnimallDTO(createdAnimal);
            return CreatedAtAction(nameof(GetAnimalById), new { animalId = animalDTO.Id }, animalDTO);
            
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal([FromBody] EAnimal animal, int id)
        {
            EAnimal updatedAnimal = _repo.UpdateEAnimal(animal, id);
            AnimalDTO animallDTO = MapAnimalToAnimallDTO(updatedAnimal);
            return Ok(animallDTO);
        }


        private AnimalDTO MapAnimalToAnimallDTO(EAnimal animal)
        {
            return new AnimalDTO
            {
                Id = animal.Id,
                AnimalType = animal.AnimalType,
                Name = animal.Name
            };
        }
    }
}

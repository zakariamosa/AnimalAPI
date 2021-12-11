using Animal.DTOs;
using Animal.Entities;

namespace Animal.Repo
{
    public class AnimalRepo : IAnimal
    {
        private List<EAnimal> _animals;
        public AnimalRepo()
        {
            _animals = populatedummydata();
        }
        public EAnimal CreateEAnimal(CreateAnimalDTO createAnimallDTO)
        {
            EAnimal animal = new EAnimal();

            
            animal.AnimalType = createAnimallDTO.AnimalType;
            animal.Name = createAnimallDTO.Name;
            animal.Id = _animals.Max(x => x.Id) + 1;
            _animals.Add(animal);

            return animal;
        }


        public void DeleteAnimalById(int id)
        {
            var deleteAnimal =_animals.Find(x => x.Id == id);
            _animals.Remove(deleteAnimal);
        }

        public List<EAnimal> GetAllAnimals()
        {
            return _animals;
        }

        public EAnimal GetAnimalById(int id)
        {
            return _animals.Find(a => a.Id == id);
        }

        public EAnimal UpdateEAnimal(EAnimal entityanimal, int id)
        {
            EAnimal existingAnimal = _animals.FirstOrDefault(x => x.Id == id);
            if (existingAnimal is not null)
            {
                existingAnimal.AnimalType = entityanimal.AnimalType;
                existingAnimal.Name = entityanimal.Name;
            }
           
            return existingAnimal;
        }

        private List<EAnimal> populatedummydata()
        {
            return _animals = new List<EAnimal>()
            {
                new EAnimal(){
                Id = 1,
                AnimalType = "vildadjur",
                Name = "Lion",
                },
                new EAnimal(){
                Id = 2,
                AnimalType = "husdjur",
                Name = "Cat",
                },
                new EAnimal(){
                Id = 3,
                AnimalType = "vildadjur",
                Name = "Tiger",
                },
                new EAnimal(){
                Id = 4,
                AnimalType = "vildadjur",
                Name = "elefant",
                },
                new EAnimal(){
                Id = 5,
                AnimalType = "husdjur",
                Name = "dog",}
            };
        }
    }
}

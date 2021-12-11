using Animal.DTOs;
using Animal.Entities;

namespace Animal.Repo
{
    public interface IAnimal
    {
        List<EAnimal> GetAllAnimals();

        EAnimal GetAnimalById(int id);
        EAnimal CreateEAnimal(CreateAnimalDTO createAnimallDTO);
        EAnimal UpdateEAnimal(EAnimal entityanimal, int id);
        void DeleteAnimalById(int id);
    }
}

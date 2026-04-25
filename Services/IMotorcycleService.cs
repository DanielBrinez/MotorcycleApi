using MotorcycleApi.Models;

namespace MotorcycleApi.Services
{
    public interface IMotorcycleService
    {
        List<Motorcycle> GetAll();
        Motorcycle? GetById(int Id);
        Motorcycle? GetPost(int Id, Motorcycle postMotorcycle);
        Motorcycle? GetPut(int Id, Motorcycle postMotorcycle);
        Motorcycle? GetDelete(int Id);

    }
}
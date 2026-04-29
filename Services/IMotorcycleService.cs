using MotorcycleApi.Models;

namespace MotorcycleApi.Services
{
    public interface IMotorcycleService
    {
        List<Motorcycle> GetAll();
        Motorcycle? GetById(int Id);
        Motorcycle? PostId (Motorcycle receivedMotorcycle);
        Motorcycle? PutId (int Id, Motorcycle updatedMotorcycle);
        Motorcycle? GetDelete(int Id);
    }
}
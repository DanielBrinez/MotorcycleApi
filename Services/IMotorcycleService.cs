using MotorcycleApi.Models;

namespace MotorcycleApi.Services
{
    public interface IMotorcycleService
    {
        Task<List<Motorcycle>> GetAll();
        Task <Motorcycle?> GetById(int Id);
        Task <Motorcycle?> GetPost(Motorcycle receivedesmotorcycles);
        Task <Motorcycle?> GetPut(int Id, Motorcycle UpdatedMotorcycle);
        Task <Motorcycle?> GetDelete(int Id);

    }
}
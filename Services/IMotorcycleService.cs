using MotorcycleApi.Models;

namespace MotorcycleApi.Services
{
    public interface IMotorcycleService
    {
        List<Motorcycle> SelectOrders();
        List<Motorcycle> GetAllPrice();
        List<Motorcycle> GetAll();
        List<Motorcycle> SelectOrders();
        Motorcycle? GetById(int Id);
        Motorcycle? GetPost (Motorcycle createdMotorcycle);
        Motorcycle? GetPut(int Id, Motorcycle createdMotorcycle);
        Motorcycle? GetDelete (int Id);
    }
}
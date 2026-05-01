using MotorcycleApi.Models;

namespace MotorcycleApi.Services
{
    public interface IMotorcycleService
    {
        List<object> SelectOrders();
        List<Motorcycle> GetAllPrice();
        List<Motorcycle> GetAll();
        List<Motorcycle> GetOrder();
        Motorcycle? GetById(int Id);
        Motorcycle? GetPost (Motorcycle createdMotorcycle);
        Motorcycle? GetPut(int Id, Motorcycle createdMotorcycle);
        Motorcycle? GetDelete (int Id);
    }
}
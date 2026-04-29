using MotorcycleApi.Models;
using MotorcycleApi.Data;

namespace MotorcycleApi.Services
{
    public class MotorcycleService : IMotorcycleService
    {
        private readonly MotorcycleContext _context;

    public MotorcycleService (MotorcycleContext context)
        {
            _context = context;
        }

    public List<Motorcycle> GetAll()
        {
            return _context.Motorcycles.ToList();
        }

    public Motorcycle? GetById(int Id)
        {
            return _context.Motorcycles.FirstOrDefault(t => t.Id == Id);
        }
    public Motorcycle? PostId(Motorcycle receivedMotorcycle)
        {
            receivedMotorcycle.Id = _context.Motorcycles.Count() + 1;
            _context.Motorcycles.Add(receivedMotorcycle);
            _context.SaveChanges();
            return(receivedMotorcycle);
        }
    public Motorcycle? PutId (int Id, Motorcycle updatedMotorcycle)
        {
            var updatePut = _context.Motorcycles.FirstOrDefault(u => u.Id == Id);
            if(updatePut == null)
            {
                return (null);
            }
            else
            {
                updatePut.Name = updatedMotorcycle.Name;
                updatePut.Stock = updatedMotorcycle.Stock;
                updatePut.Price = updatedMotorcycle.Price;
                _context.SaveChanges();
                return(updatePut);
            }
        }
    public Motorcycle? GetDelete (int Id)
        {
            var deleteProduct = _context.Motorcycles.FirstOrDefault(d => d.Id == Id);
            if(deleteProduct == null)
            {
                return (null);
            }
            else
            {
                _context.Motorcycles.Remove(deleteProduct);
                _context.SaveChanges();
                return(deleteProduct);
            }
        }
    }
}
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

    public List<Motorcycle> SelectOrders()
        {
            var selectProducts = _context.Motorcycles.Select(s => new { s.Name, s.Price });
            return(selectProducts);
        }


    public List<Motorcycle> GetOrder()
        {
            var allOrders = _context.Motorcycles.OrderBy(a => a.Price).ToList();
            return(allOrders);
        }
    public List<Motorcycle> GetAllPrice()
        {
            var findProduct = _context.Motorcycles.Where(f => f.Price <= 50000000).ToList();
            return(findProduct);
        }


    public List<Motorcycle> GetAll()
        {
            return (_context.Motorcycles.ToList());
        }

    public Motorcycle? GetById(int Id)
        {
            return _context.Motorcycles.FirstOrDefault(f => f.Id == Id);
        }

    public Motorcycle? GetPost (Motorcycle createdMotorcycle)
        {
            createdMotorcycle.Id = _context.Motorcycles.Count() + 1;
            _context.Motorcycles.Add(createdMotorcycle);
            _context.SaveChanges();
            return(createdMotorcycle);
        }

    public Motorcycle? GetPut(int Id, Motorcycle createdMotorcycle)
        {
            var tempPut = _context.Motorcycles.FirstOrDefault(f => f.Id == Id);
            if(tempPut == null)
            {
                return(null);
            }
            else
            {
                tempPut.Name = createdMotorcycle.Name;
                tempPut.Stock = createdMotorcycle.Stock;
                tempPut.Price = createdMotorcycle.Price;
                _context.SaveChanges();
                return(tempPut);
            }
        }
    
    public Motorcycle? GetDelete (int Id)
        {
            var deleteTemp = _context.Motorcycles.FirstOrDefault(f => f.Id == Id);
            
            if(deleteTemp == null)
            {
                return(null);
            }
            else
            {
                _context.Motorcycles.Remove(deleteTemp);
                _context.SaveChanges();
                return(deleteTemp);
            }
        }
    }
}

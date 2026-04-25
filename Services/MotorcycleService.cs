using MotorcycleApi.Models;

namespace MotorcycleApi.Services
{
        public class MotorcycleService : IMotorcycleService
        {
        private List<Motorcycle> allList = new List<Motorcycle> 

             {

          new Motorcycle {Name = "Ninja H2R", Id = 1, Price = 300000000, Stock = 2},
          new Motorcycle {Name = "Dominar 400", Id = 2, Price = 200000000, Stock = 2},
          new Motorcycle {Name = "Pulsar RS200", Id = 3, Price = 300000000, Stock = 2},
          new Motorcycle {Name = "Pulsar NS200", Id = 4, Price = 400000000, Stock = 2},
          new Motorcycle {Name = "Pulsar 180", Id = 5, Price = 10000000, Stock = 2},
          new Motorcycle {Name = "CFMOTO 450SR", Id = 6, Price = 30000000, Stock = 2},
          new Motorcycle {Name = "CFMOTO 250SR", Id = 7, Price = 30000000, Stock = 2},
          new Motorcycle {Name = "CFMOTO 675SR", Id = 8, Price = 30000000, Stock = 2},
          new Motorcycle {Name = "YAMAHA R3", Id = 9, Price = 30000000, Stock = 2},
          new Motorcycle {Name = "YAMAHA MT-03", Id = 10, Price = 30000000, Stock = 2},
          new Motorcycle {Name = "SUSUKI GIXER 250", Id = 11, Price = 30000000, Stock = 2},
          new Motorcycle {Name = "SUSUKI GIXER 150", Id = 12, Price = 40000000, Stock = 2},
          new Motorcycle {Name = "Benelli 301s", Id = 13, Price = 70000000, Stock = 2},
          new Motorcycle {Name = "Yamaha r15 V4", Id = 14, Price = 300000000, Stock = 2},
          new Motorcycle {Name = "Susuki gsxr 150", Id = 15, Price = 300000000, Stock = 2},
          new Motorcycle {Name = "Yamaha Fz150", Id = 16, Price = 300000000, Stock = 2},
          new Motorcycle {Name = "Yamaha Fz250", Id = 17, Price = 300000000, Stock = 2},
          new Motorcycle {Name = "Pulsar N250", Id = 18, Price = 300000000, Stock = 2},
          new Motorcycle {Name = "Pulsar NS400", Id = 19, Price = 300000000, Stock = 2},
          new Motorcycle {Name = "Yamaha MT-09", Id = 20, Price = 300000000, Stock = 2},
          new Motorcycle {Name = "BMW S1000RR", Id = 21, Price = 300000000, Stock = 2}

               };

        public List<Motorcycle> GetAll()
            {
                return(allList);
            }

        public Motorcycle? GetById(int Id)
            {
                var findId = allList.FirstOrDefault(f => f.Id == Id);
                return(findId);
            }

        public Motorcycle? GetPost(int Id, Motorcycle postMotorcycle)
            {
                postMotorcycle.Id = allList.Count + 1;
                allList.Add(postMotorcycle);
                return(postMotorcycle);     
            }
        public Motorcycle? GetPut(int Id, Motorcycle postMotorcycle)
            {
                var putId = allList.FirstOrDefault(p => p.Id == Id);
                if(putId == null)
                   {
                        return(null);
                   }
                else
                   {
                        putId.Name = postMotorcycle.Name;
                        putId.Stock = postMotorcycle.Stock;
                        putId.Price = postMotorcycle.Price;
                        return(putId);
                   }        
            }

        public Motorcycle? GetDelete(int Id)
            {
                var findDelete = allList.FirstOrDefault(f => f.Id == Id);

                if(findDelete == null)

                   {
                        return(null);
                   }
                else
                        {
                            allList.Remove(findDelete);
                            return(findDelete);
                        }
            }

        }
}

using Hotel01.DAL.Ef;
using Hotel01.DAL.Etities;
using Hotel01.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel01.DAL.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        ContextDB contextDB;
        public ServiceRepository(ContextDB contextDB)
        {
            this.contextDB = contextDB;
        }

        public void Create(service item)
        {
            contextDB.Services.Add(item);
        }

        public void Delete(Guid ID)
        {
            service result = new service();
            result = contextDB.Services.FirstOrDefault(B => B.ID == ID);
            if (result != null)
            {
                contextDB.Services.Remove(result);
            }
        }

        public IEnumerable<service> Find(Func<service, bool> predicate)
        {
            List<service> result = new List<service>();
            result = contextDB.Services.Where(predicate).ToList();
            foreach(var S in result)
            {
                contextDB.Entry(S).Collection(Ser => Ser.Categories).Load();
            }
            return result;
        }

        public service Get(Guid ID)
        {
            service result = new service();
            result = contextDB.Services.FirstOrDefault(B => B.ID == ID);
            contextDB.Entry(result).Collection(Ser => Ser.Categories).Load();
            return result;
        }

        public IEnumerable<service> GetAll()
        {
            List<service> result = new List<service>();
            result = contextDB.Services.ToList();
            foreach (var S in result)
            {
                contextDB.Entry(S).Collection(Ser => Ser.Categories).Load();
            }
            return result;
        }

        public void Update(service Item)
        {
            contextDB.Entry(Item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}

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
    public class CustomerRepository : ICustomerRepository
    {
        ContextDB contextDB;
        public CustomerRepository(ContextDB contextDB)
        {
            this.contextDB = contextDB;
        }

        public void Create(Customer item)
        {
            contextDB.Customers.Add(item);
        }

        public void Delete(Guid ID)
        {
            Customer result = new Customer();
            result = contextDB.Customers.FirstOrDefault(B => B.ID == ID);
            if (result != null)
            {
                contextDB.Customers.Remove(result);
            }
        }

        public IEnumerable<Customer> Find(Func<Customer, bool> predicate)
        {
            List<Customer> result = new List<Customer>();
            result = contextDB.Customers.Where(predicate).ToList();
            foreach(var Cus in result)
            {
                contextDB.Entry(Cus).Collection(C => C.BookingInfos).Load();
            }
            return result;
        }

        public Customer Get(Guid ID)
        {
            Customer result = new Customer();
            result = contextDB.Customers.FirstOrDefault(B => B.ID == ID);
            contextDB.Entry(result).Collection(C => C.BookingInfos).Load();
            return result;
        }

        public IEnumerable<Customer> GetAll()
        {
            List<Customer> result = new List<Customer>();
            result = contextDB.Customers.ToList();
            foreach (var Cus in result)
            {
                contextDB.Entry(Cus).Collection(C => C.BookingInfos).Load();
            }
            return result;
        }

        public void Update(Customer Item)
        {
            contextDB.Entry(Item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}

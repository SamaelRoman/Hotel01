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
    public class BookingInfoRepository : IBookingInfoRepository
    {
        ContextDB contextDB;
        public BookingInfoRepository(ContextDB contextDB)
        {
            this.contextDB = contextDB;   
        }
        public void Create(BookingInfo item)
        {
            contextDB.BookingInfos.Add(item);
        }

        public void Delete(Guid ID)
        {
            BookingInfo result = new BookingInfo();
            result = contextDB.BookingInfos.FirstOrDefault(B => B.ID == ID);
            if(result != null)
            {
                contextDB.BookingInfos.Remove(result);
            }
        }

        public IEnumerable<BookingInfo> Find(Func<BookingInfo, bool> predicate)
        {
            List<BookingInfo> result = new List<BookingInfo>();
            result = contextDB.BookingInfos.Where(predicate).ToList();
            return result;
        }

        public BookingInfo Get(Guid ID)
        {
            BookingInfo result = new BookingInfo();
            result = contextDB.BookingInfos.FirstOrDefault(B => B.ID == ID);
            return result;
        }

        public IEnumerable<BookingInfo> GetAll()
        {
            List<BookingInfo> result = new List<BookingInfo>();
            result = contextDB.BookingInfos.ToList();
            return result;
        }

        public void Update(BookingInfo Item)
        {
            contextDB.Entry(Item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}

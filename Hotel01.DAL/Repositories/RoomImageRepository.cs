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
    public class RoomImageRepository : IRoomImageRepository
    {
        ContextDB contextDB;
        public RoomImageRepository(ContextDB contextDB)
        {
            this.contextDB = contextDB;
        }

        public void Create(RoomImage item)
        { 
            contextDB.RoomImages.Add(item);
        }

        public void Delete(Guid ID)
        {
            RoomImage result = new RoomImage();
            result = contextDB.RoomImages.FirstOrDefault(B => B.ID == ID);
            if (result != null)
            {
                contextDB.RoomImages.Remove(result);
            }
        }

        public IEnumerable<RoomImage> Find(Func<RoomImage, bool> predicate)
        {
            List<RoomImage> result = new List<RoomImage>();
            result = contextDB.RoomImages.Where(predicate).ToList();
            return result;
        }

        public RoomImage Get(Guid ID)
        {
            RoomImage result = new RoomImage();
            result = contextDB.RoomImages.FirstOrDefault(B => B.ID == ID);
            return result;
        }

        public IEnumerable<RoomImage> GetAll()
        {
            List<RoomImage> result = new List<RoomImage>();
            result = contextDB.RoomImages.ToList();
            return result;
        }

        public void Update(RoomImage Item)
        {
            contextDB.Entry(Item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}

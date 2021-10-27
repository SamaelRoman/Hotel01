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
    public class RoomRepository : IRoomRepository
    {
        ContextDB contextDB;
        public RoomRepository(ContextDB contextDB)
        {
            this.contextDB = contextDB;
        }

        public void Create(Room item)
        {
            contextDB.Rooms.Add(item);
        }

        public void Delete(int ID)
        {
            Room result = new Room();
            result = contextDB.Rooms.FirstOrDefault(B => B.ID == ID);
            if (result != null)
            {
                contextDB.Rooms.Remove(result);
            }
        }

        public IEnumerable<Room> Find(Func<Room, bool> predicate)
        {
            List<Room> result = new List<Room>();
            result = contextDB.Rooms.Where(predicate).ToList();
            foreach(var CurrentRoom in result)
            {
                contextDB.Entry(CurrentRoom).Collection(R => R.BookingInfos).Load();
                contextDB.Entry(CurrentRoom).Collection(R => R.RoomImages).Load();
            }
            return result;
        }

        public Room Get(int ID)
        {
            Room result = new Room();
            result = contextDB.Rooms.FirstOrDefault(B => B.ID == ID);
            contextDB.Entry(result).Collection(R => R.BookingInfos).Load();
            contextDB.Entry(result).Collection(R => R.RoomImages).Load();
            return result;
        }

        public IEnumerable<Room> GetAll()
        {
            List<Room> result = new List<Room>();
            result = contextDB.Rooms.ToList();
            foreach (var CurrentRoom in result)
            {
                contextDB.Entry(CurrentRoom).Collection(R => R.BookingInfos).Load();
                contextDB.Entry(CurrentRoom).Collection(R => R.RoomImages).Load();
            }
            return result;
        }

        public void Update(Room Item)
        {
            contextDB.Entry(Item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}

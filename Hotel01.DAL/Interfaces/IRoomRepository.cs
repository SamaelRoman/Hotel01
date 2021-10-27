using Hotel01.DAL.Etities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel01.DAL.Interfaces
{
    public interface IRoomRepository : IRepository<Room,int>
    {
    }
}

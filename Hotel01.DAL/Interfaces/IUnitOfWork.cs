using Hotel01.DAL.Etities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel01.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBookingInfoRepository BookingInfoes { get; }
        ICategoryRepository Categories { get; }
        ICategoryInfoRepository CategoryInfoes { get;}
        ICustomerRepository Customers { get; }
        IRoomRepository Rooms { get; }
        IRoomImageRepository RoomImages { get; }
        IServiceRepository services { get; }
        void SaveChanges();
    }
}

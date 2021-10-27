using Hotel01.DAL.Ef;
using Hotel01.DAL.Infrastructure;
using Hotel01.DAL.Interfaces;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel01.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private bool Disposed = false; 
        ContextDB ContextDB;
        private IBookingInfoRepository _BookingInfoRepository { get; set; }
        private ICategoryRepository _CategoryRepository { get; set; }
        private ICategoryInfoRepository _CategoryInfoRepository { get; set; }
        private ICustomerRepository _CustomerRepository { get; set; }
        private IRoomRepository _RoomRepository { get; set; }
        private IRoomImageRepository _RoomImageRepository { get; set; }
        private IServiceRepository _ServiceRepository { get; set; }
        public EFUnitOfWork(string ConnectionString)
        {
            ContextDB = new ContextDB(ConnectionString);
        }

        public IBookingInfoRepository BookingInfoes { get
        {
            if(_BookingInfoRepository == null)
            {
                _BookingInfoRepository = new BookingInfoRepository(ContextDB);
            }
            return _BookingInfoRepository;
        }}
        public ICategoryRepository Categories { get
        {
            if(_CategoryRepository == null)
            {
                _CategoryRepository = new CategoryRepository(ContextDB);
            }
            return _CategoryRepository;
        }}
        public ICategoryInfoRepository CategoryInfoes { get 
        {
            if (_CategoryInfoRepository == null)
            {
                _CategoryInfoRepository = new CategoryInfoRepository(ContextDB);
            }
            return _CategoryInfoRepository;
        }}
        public ICustomerRepository Customers { get
        { 
            if(_CustomerRepository == null)
            {
                _CustomerRepository = new CustomerRepository(ContextDB);
            }
            return _CustomerRepository;
        }}
        public IRoomRepository Rooms{get
        {
            if (_RoomRepository == null)
            {
                _RoomRepository = new RoomRepository(ContextDB);
            }
            return _RoomRepository;
        }}
        public IRoomImageRepository RoomImages { get
        {
            if(_RoomImageRepository == null)
            {
                _RoomImageRepository = new RoomImageRepository(ContextDB);
            }
            return _RoomImageRepository;
        }}
        public IServiceRepository services { get 
        {
            if(_ServiceRepository == null)
            {
                _ServiceRepository = new ServiceRepository(ContextDB);
            }
            return _ServiceRepository;
        }}
        public void SaveChanges()
        {
            ContextDB.SaveChanges();
        }
        public void Dispose()
        {
            if (!Disposed)
            {
                ContextDB.Dispose();
                Disposed = true;
            }
        }


    }
}

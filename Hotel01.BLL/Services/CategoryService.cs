using Hotel01.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel01.DAL.Interfaces;
using Hotel01.BLL.DTO;
using AutoMapper;
using Hotel01.DAL.Etities;

namespace Hotel01.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private bool Disposed = false;
        private IUnitOfWork Database { get; set; }
        static IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Category, CategoryDTO>();
            cfg.CreateMap<service, serviceDTO>();
            cfg.CreateMap<Room, RoomDTO>();
            cfg.CreateMap<CategoryInfo, CategoryInfoDTO>();
            cfg.CreateMap<BookingInfo, BookingInfoDTO>();
            cfg.CreateMap<RoomImage, RoomImageDTO>();
            cfg.CreateMap<Customer, CustomerDTO>();
        }).CreateMapper();
        public CategoryService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<CategoryDTO> GetAllCategory()
        { 
            return mapper.Map<List<CategoryDTO>>(Database.Categories.GetAll());
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                Database.Dispose();
                Disposed = true;
            }
        }
    }
}

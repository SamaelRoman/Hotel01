using AutoMapper;
using Hotel01.BLL.DTO;
using Hotel01.BLL.Interfaces;
using Hotel01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotel01.Controllers
{
    public class CategoryController : Controller
    {
        public ICategoryService CategoryService { get; set; }
        public CategoryController(ICategoryService CategoryService)
        {
            this.CategoryService = CategoryService;
        }
        // GET: Category
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index()
        {
            List<CategoryDTO> _Categories = (List<CategoryDTO>)CategoryService.GetAllCategory();
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CategoryDTO, CategoryViewModel>();
                cfg.CreateMap<serviceDTO, serviceViewModel>();
                cfg.CreateMap<RoomDTO, RoomViewModel>();
                cfg.CreateMap<CategoryInfoDTO, CategoryInfoViewModel>();
                cfg.CreateMap<BookingInfoDTO, BookingInfoViewModel>();
                cfg.CreateMap<RoomImageDTO, RoomImageViewModel>();
                cfg.CreateMap<CustomerDTO, CustomerViewModel>();
            }).CreateMapper();
            var Categories = mapper.Map<List<CategoryDTO>, List<CategoryViewModel>>(_Categories);

            return View("Index",Categories);
        }
    }
}
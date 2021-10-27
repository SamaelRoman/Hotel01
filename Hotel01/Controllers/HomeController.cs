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
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        { 
            return View();
        }

    }
}
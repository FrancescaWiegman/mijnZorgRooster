using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.Models.DTO;
using mijnZorgRooster.Models.Entities;
using mijnZorgRooster.DAL;
using mijnZorgRooster.Services;

namespace mijnZorgRooster.Controllers
{
    public class DienstController : Controller
    {
		private readonly IUnitOfWork _unitOfWork;

		public DienstController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IActionResult Index()
        {
            return View();
        }
    }
}
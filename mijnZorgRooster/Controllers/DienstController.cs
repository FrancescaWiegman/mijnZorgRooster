using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mijnZorgRooster.Models;
using mijnZorgRooster.DAL.Entities;
using mijnZorgRooster.DAL;
using mijnZorgRooster.Services;
using mijnZorgRooster.DAL.Repositories;

namespace mijnZorgRooster.Controllers
{
	public class DienstController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
        private readonly IDienstRepository _dienstRepository;

		public DienstController(IUnitOfWork unitOfWork, IDienstRepository dienstRepository)
		{
			_unitOfWork = unitOfWork;
            _dienstRepository = dienstRepository;
		}

		// GET: Dienst
		public async Task<IActionResult> Index()
		{
    		return View(await _dienstRepository.GetAsync());
		}

        public async Task<IActionResult> Details(int? id)
        {
            DienstDTO dienstDTO = null;

            if (id.HasValue)
            {
                dienstDTO = await _dienstRepository.GetByIdAsync(id.Value);
            }
            else
            {
                return NotFound();
            }

            return View(dienstDTO);
        }

	}
}
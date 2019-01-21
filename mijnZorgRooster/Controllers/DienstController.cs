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

		// GET: Dienst
		public async Task<IActionResult> Index()
		{
            List<DienstDto> diensten = await _unitOfWork.DienstRepository.GetDienstenDto();

			return View(diensten);
		}

        public async Task<IActionResult> Details(int? id)
        {
            DienstDto dienst = null;

            if (id.HasValue)
            {
                dienst = await _unitOfWork.DienstRepository.GetDienstDto(id.Value);
            }
            else
            {
                return NotFound();
            }

            return View(dienst);
        }

	}
}
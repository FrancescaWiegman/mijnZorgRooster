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
		private readonly IRoosterService _roosterService;

		public DienstController(IRoosterService roosterService, IUnitOfWork unitOfWork)
		{
			_roosterService = roosterService;
			_unitOfWork = unitOfWork;
		}

		// GET: Dienst
		public async Task<IActionResult> Index()
		{
			IList<Dienst> dienstList = await _unitOfWork.DienstRepository.GetAsync();
			List<DienstDto> dienstDtoList = new List<DienstDto>();
			DienstDto dienstDto = new DienstDto();

			foreach (var d in dienstList)
			{
				dienstDto = await _unitOfWork.DienstRepository.GetDienstDto(d.DienstID);
				// TODO: rooster nog aanhangen?
				dienstDtoList.Add(dienstDto);
			}
			return View(dienstDtoList);
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
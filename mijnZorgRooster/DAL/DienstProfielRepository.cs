using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.DAL
{
	public class DienstProfielRepository : GenericRepository<DienstProfiel>, IDienstProfielRepository
	{

		public DienstProfielRepository(ZorginstellingDbContext context) : base(context)
		{
		}

	}
}

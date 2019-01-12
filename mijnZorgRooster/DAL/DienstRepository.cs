using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.DAL
{
	public class DienstRepository : GenericRepository<Dienst>, IDienstRepository
	{
		public DienstRepository(ZorginstellingDbContext context) : base(context)
		{
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.DAL
{
	public class RoosterRepository : GenericRepository<Rooster>, IRoosterRepository
	{
		public RoosterRepository(ZorginstellingDbContext context) : base(context)
		{
		}
	}
}

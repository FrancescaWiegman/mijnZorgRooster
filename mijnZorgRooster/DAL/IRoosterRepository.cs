using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.DAL
{
	public interface IRoosterRepository
	{
		Task<IEnumerable<Rooster>> GetAsync();
		Task<Rooster> GetByIdAsync(object id);
		void Insert(Rooster rooster);
		void Delete(object id);
		void Delete(Rooster rooster);
		void Update(Rooster rooster);
	}
}

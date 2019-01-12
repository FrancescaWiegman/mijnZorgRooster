using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.DAL
{
	public interface IDienstRepository
	{
		Task<IEnumerable<Dienst>> GetAsync();
		Task<Dienst> GetByIdAsync(object id);
		void Insert(Dienst dienst);
		void Delete(object id);
		void Delete(Dienst dienst);
		void Update(Dienst dienst);
	}
}

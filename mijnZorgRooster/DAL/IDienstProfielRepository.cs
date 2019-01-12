using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models.Entities;

namespace mijnZorgRooster.DAL
{
	public interface IDienstProfielRepository
	{
		Task<IEnumerable<DienstProfiel>> GetAsync();
		Task<DienstProfiel> GetByIdAsync(object id);
		void Insert(DienstProfiel dienstprofiel);
		void Delete(object id);
		void Delete(DienstProfiel dienstprofiel);
		void Update(DienstProfiel dienstprofiel);
	}
}

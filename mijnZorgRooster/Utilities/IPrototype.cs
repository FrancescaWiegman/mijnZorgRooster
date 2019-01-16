using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Utilities
{
	public interface IPrototype
	{
		IPrototype Clone();
		object ReturnClonedObject();
	}
}

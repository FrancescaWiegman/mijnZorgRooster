using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Services
{
    interface IContractService
    {
        int BerekenParttimePercentage(int medewerkerID);
    }
}

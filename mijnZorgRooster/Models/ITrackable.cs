using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Models
{
    interface ITrackable
    {
        DateTime AanmaakDatum { get; set; }
        DateTime WijzigingsDatum { get; set; }
    }
}

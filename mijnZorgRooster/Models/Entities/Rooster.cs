﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace mijnZorgRooster.Models.Entities
{
    public class Rooster : ITrackable
    {
		[Key]
		public int RoosterID { get; set; }
        public int Jaar { get; set; }
		public int Maand { get; set; }
		public Boolean IsGevalideerd { get; set; }

		public List<RoosterDienstProfiel> RoosterDienstProfielen { get; set; }
		public List<Dienst> Diensten { get; set; }
        //TODO: Bij implementatie van de use case CRUD Teams, zou hier ook nog een property voor het Team moeten komen.

        public DateTime AanmaakDatum { get; set; }
        public DateTime WijzigingsDatum { get; set; }

    }
}

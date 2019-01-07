using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mijnZorgRooster.Models;

namespace mijnZorgRooster.ViewModels
{
    public class MedewerkerDetailsdto : MedewerkerbasisDto
    {

        public MedewerkerDetailsdto(Medewerker medewerker)
        {
            MedewerkerID = medewerker.MedewerkerID;
            Voornaam = medewerker.Voornaam;
            //enz 
        }
        public int LeeftijdInJaren { get; set; }
        
    }
  }

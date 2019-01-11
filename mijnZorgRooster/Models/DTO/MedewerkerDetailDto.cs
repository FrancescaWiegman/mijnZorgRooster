using mijnZorgRooster.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace mijnZorgRooster.Models.DTO
{
    public class MedewerkerDetailDto : MedewerkerBasisDto
    {

        public MedewerkerDetailDto(Medewerker medewerker)
        {
            MedewerkerID = medewerker.MedewerkerID;
            Voornaam = medewerker.Voornaam;
            //enz 
        }
        public int LeeftijdInJaren { get; set; }

    }
  }

using mijnZorgRooster.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace mijnZorgRooster.Models.DTO
{
    public class MedewerkerDetailDto : MedewerkerBasisDto
    {

        public MedewerkerDetailDto(Medewerker medewerker) : base(medewerker)
        {
        }

        public int LeeftijdInJaren { get; set; }

        public string Naam { get { return string.Concat(Voornaam, " ", Tussenvoegsels, " ", Achternaam); } }
    }
  }

using mijnZorgRooster.Models.Entities;

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

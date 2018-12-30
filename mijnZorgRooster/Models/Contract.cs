using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mijnZorgRooster.Models
{
    public class Contract
    {
		public const int WekenPerJaar = 52;
		public const decimal NormUren = 36; // normaal geldende werktijd in een week. Is dit overal in de zorg hetzelfde? Ik ben daar nu wel even van uitgegaan.

        public int ContractID { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime Einddatum { get; set; }
        public decimal ContractUren { get; set; }

        public Medewerker Medewerker { get; set; }

        // Dit is wederom iets wat berekend moet worden. Dit moet ik nog even navragen voor ik Controllers, Views en databases met connectiestrings aan ga maken.
        public int verlofDagenPerJaar { get; set; }

		//Parttime percentage moet berekend worden op deze manier: https://www.pfzw.nl/Werkgevers/wat-doe-ik-bij/Paginas/Berekening-deeltijdfactor.aspx
		public decimal ParttimePercentage { get; set; }

		//TODO: Testen. 7 Contracturen op een normale werkweek van 38 uur moet een deeltijdfactor van 0,1842 geven, en dus een deeltijdpercentage van 18,42 %
		public decimal berekenParttimePercentage()
		{
			var DeeltijdFactor = System.Math.Round(ContractUren / NormUren, 4);
			return System.Math.Round(DeeltijdFactor * 100, 2);
		}

    }
}

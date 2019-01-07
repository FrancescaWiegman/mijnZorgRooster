//using mijnZorgRooster.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace mijnZorgRooster.Data
//{
//    public class DbInitializer
//    {
//        public static void Initialize(ZorginstellingContext context)
//        {
//            context.Database.EnsureCreated();

//            // Controleer or er medewerkers in de database zitten.
//            if (context.Medewerkers.Any())
//            {
//                return;   // DB has been seeded
//            }

//            var medewerkers = new Medewerker[]
//            {
//            new Medewerker{MedewerkerID=1, Voornaam="Francesca", Tussenvoegsels = "",Achternaam="Wiegman",Telefoonnummer="0748513535",
//                MobielNummer ="0652526090", Emailadres = "francescawiegman@ziggo.nl", Adres = "Hunenborg 6",
//                Postcode = "7556 MR", Woonplaats = "Hengelo", Geboortedatum = DateTime.Parse("23-06-1979"),
            
//            },
            
//            };
//            foreach (Medewerker m in medewerkers)
//            {
//                context.Medewerkers.Add(m);
//            }
//            context.SaveChanges();

//            var contracts = new Contract[]
//            {
//            new Contract{ContractID=1,BeginDatum=DateTime.Parse("15-03-2017"), Einddatum=DateTime.Parse("00-00-0000"),
//            ContractUren = 36, ParttimePercentage = 100, verlofDagenPerJaar = 25},
        
           
//            };
//            foreach (Contract c in contracts)
//            {
//                context.Contracts.Add(c);
//            }
//            context.SaveChanges();

//            var certificaats = new Certificate[]
//            {
//            new Certificate{CertificaatID = 2, MedewerkerID=1, Datum =DateTime.Parse("01-07-2005"),
//                geldigTot =DateTime.Parse("01-07-2055")}
//            };
          
          
//            foreach (Certificate e in certificaats)
//            {
//                context.Certificates.Add(e);
//            }
//            context.SaveChanges();
//        }
//    }
//}


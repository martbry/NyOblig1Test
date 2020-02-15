using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Oblig1Test
{
    public class FamilyApp
    {
        public string WelcomeMessage { get; } = "Velkommen til Oblig1-applikasjonen. Skriv \"hjelp\" for hjelp.";
        public string CommandPrompt { get; } = "";
        private List<Person> _personer = new List<Person>();


        public FamilyApp(params Person[] personer)
        {
            _personer.AddRange(personer);
        }


        public string HandleCommand(string command)
        {
            string returstring;
            return returstring = command == "hjelp" ? Hjelp() :
                command == "liste" ? Liste() :
                command.Contains("vis") ? Vis(command.Substring(4)) : "Denne kommandoen støttes ikke. Skriv \"hjelp\" for hjelp.";
        }


        //hjelp => viser en hjelpetekst som forklarer alle kommandoene
        private string Hjelp()
        {
            return
$@"""liste"" lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert
""vis <id>"" viser en bestemt person med mor, far og barn (og id for disse, slik at man lett kan vise en av dem";
        }

        //liste => lister alle personer med id, fornavn, fødselsår, dødsår og navn og id på mor og far om det finnes registrert.
        private string Liste()
        {
            string returstring = "";
            foreach (var person in _personer)
            {
                returstring += $"{person.FirstName}\n";
            }

            return returstring;
        }

        //vis <id> => viser en bestemt person med mor, far og barn(og id for disse, slik at man lett kan vise en av dem)
        private string Vis(string id)
        {
            int denneID;
            string returstring = "";
            string returbarn = "";
            try
            {
                denneID = Convert.ToInt32(id);
            }
            catch
            {
                return "IDen må være et heltall. Prøv igjen.";
            }

            foreach (var person in _personer)
            {
                if (person.Id == denneID)
                {
                    returstring += $"{person.GetDescription()}\n";

                    bool fantBarn = false;
                    foreach (var barn in _personer)
                    {
                        if (barn.Father == person || barn.Mother == person)
                        {
                            if (!fantBarn) { returbarn += "  Barn:\n"; fantBarn = true; }

                            returbarn += $"    {barn.GetDescription(true)}\n";
                        }
                    }

                    return returstring + returbarn;
                }
            }

            return "Det finnes ingen personer med denne IDen.";
        }
    }
}

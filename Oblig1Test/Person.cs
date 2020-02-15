using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig1Test
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }
        public Person Father { get; set; }
        public Person Mother { get; set; }

        public string GetDescription(bool child = false)
        {
            //"Ola Nordmann (Id=17) Født: 2000 Død: 3000 Far: Per (Id=12) Mor: Lise (Id=15)"

            string firstname = FirstName != null ? $"{FirstName} " : "";
            string lastname = LastName != null ? $"{LastName} " : "";
            string id = $"(Id={Id}) ";
            string birth = BirthYear != null ? $"Født: {BirthYear} " : "";
            string death = DeathYear != null ? $"Død: {DeathYear} " : "";
            string far = Father != null && !child ? $"Far: {Father.FirstName} (Id={Father.Id}) " : "";
            string mor = Mother != null && !child ? $"Mor: {Mother.FirstName} (Id={Mother.Id})" : "";


            return $"{firstname}{lastname}{id}{birth}{death}{far}{mor}".Trim();

        }
    }
}

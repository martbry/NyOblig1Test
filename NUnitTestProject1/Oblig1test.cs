using NUnit.Framework;
using Oblig1Test;

namespace NUnitTestNyOblig1
{
    public class PersonTest
    {
        [Test]
        public void TestAllFields()
        {
            var p = new Person
            {
                Id = 17,
                FirstName = "Ola",
                LastName = "Nordmann",
                BirthYear = 2000,
                DeathYear = 3000,
                //
                //!!! Lagt til ID på mor og far og endret expectedstringen
                //
                Father = new Person() {FirstName = "Per", Id = 12},
                Mother = new Person() {FirstName = "Lise", Id = 15},
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Ola Nordmann (Id=17) Født: 2000 Død: 3000 Far: Per (Id=12) Mor: Lise (Id=15)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        
        [Test]
        public void TestNoFields()
        {
            var p = new Person
            {
                Id = 1,
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "(Id=1)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }


        [Test]
        public void TestSomeFields()
        {
            var p = new Person
            {
                Id = 17,
                LastName = "Nordmann",
                BirthYear = 2000,
                Mother = new Person() { FirstName = "Mamma", Id = 42},
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Nordmann (Id=17) Født: 2000 Mor: Mamma (Id=42)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }

    public class FamilyAppTest
    {
        [Test]
        public void Test()
        {
            var sverreMagnus = new Person { Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005 };
            var ingridAlexandra = new Person { Id = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004 };
            var haakon = new Person { Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };
            var harald = new Person { Id = 6, FirstName = "Harald", BirthYear = 1937 };
            sverreMagnus.Father = haakon;
            ingridAlexandra.Father = haakon;
            haakon.Father = harald;

            var app = new FamilyApp(sverreMagnus, ingridAlexandra, haakon);
            var actualResponse = app.HandleCommand("vis 3");
            var expectedResponse = "Haakon Magnus (Id=3) Født: 1973 Far: Harald (Id=6)\n"
                                   + "  Barn:\n"
                                   + "    Sverre Magnus (Id=1) Født: 2005\n"
                                   + "    Ingrid Alexandra (Id=2) Født: 2004\n";
            Assert.AreEqual(expectedResponse, actualResponse);
        }

        [Test]
        public void TestNoChildren()
        {
            var ingridAlexandra = new Person { Id = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004 };
            var haakon = new Person { Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };
            ingridAlexandra.Father = haakon;

            var app = new FamilyApp(ingridAlexandra, haakon);
            var actualResponse = app.HandleCommand("vis 2");
            var expectedResponse = "Ingrid Alexandra (Id=2) Født: 2004 Far: Haakon Magnus (Id=3)\n";

            Assert.AreEqual(expectedResponse, actualResponse);
        }

    }
}
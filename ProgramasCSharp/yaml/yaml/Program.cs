using System;
using System.IO;
using System.Collections.Generic;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace yaml
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var person = new Person
            {
                Name = "Abe Lincoln",
                Age = 25,
                HeightInInches = 6f + 4f / 12f,
                Addresses = new Dictionary<string, Address>{
        { "home", new  Address() {
                Street = "2720  Sundown Lane",
                City = "Kentucketsville",
                State = "Calousiyorkida",
                Zip = "99978",
            }},
        { "work", new  Address() {
                Street = "1600 Pennsylvania Avenue NW",
                City = "Washington",
                State = "District of Columbia",
                Zip = "20500",
            }},
    }
            };*/
            var yml = @"
name: George Washington
age: 89
height_in_inches: 5.75
addresses:
  home:
    street: 400 Mockingbird Lane
    city: Louaryland
    state: Hawidaho
    zip: 99970
";
            var deserializer = new DeserializerBuilder()
    .WithNamingConvention(UnderscoredNamingConvention.Instance)  // see height_in_inches in sample yml 
    .Build();

            //yml contains a string containing your YAML
            var p = deserializer.Deserialize<Person>(yml);
            //var h = p.Addresses["home"];
            //System.Console.WriteLine($"{p.Name} is {p.Age} years old and lives at {h.Street} in {h.City}, {h.State}.");
            //Console.WriteLine(p.Name);

            string path = @"C:\Users\micha\OneDrive\Área de Trabalho\pjGCP/config.yaml";
            var r = new StreamReader(path);
            Console.WriteLine(r.ReadToEnd());
            Console.WriteLine("Hello World!");
        }
    }

    internal class Address
    {
        public Address()
        {
        }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
    }

    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public float HeightInInches { get; set; }
        public object Addresses { get; set; }
    }
}

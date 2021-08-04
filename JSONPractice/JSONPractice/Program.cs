using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JSONPractice
{
    public class AddressInformation
    {
        public string PostcodeChecker(String postcode) {
            if (postcode.Length != 6) {
                return "InvalidPostcode";
            }
            for (int i = 0; i < 4; i++) {
                if (!char.IsNumber(postcode[i])) {
                    return "InvalidPostcode";
                }
            }
            for (int i = 4; i < 6; i++) {
                if (!char.IsLetter(postcode[i])) {
                    return "InvalidPostcode";
                }
            }
            return postcode;
        }

        public string Country { get; set; }
        public string Street { get; set; }
        public int Housenumber { get; set; }
        private string postcode;
        public string Postcode {
            get { return postcode; }
            set { postcode = PostcodeChecker(value); }
        }
    }

    public class PersonalInformation
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public AddressInformation Address { get; set; }
    }


    public class Program
    {
        static void Main(string[] args) {
            var person1 = new PersonalInformation {
                Name = "Nathan",
                Age = 23,
                Address = new AddressInformation { Country = "Netherlands", Street = "SomeStreet", Housenumber = 123, Postcode = "22222" }
            };
            var person2 = new PersonalInformation {
                Name = "Another",
                Age = 99,
                Address = new AddressInformation { Country = "Anywhere", Street = "SomeStreet", Housenumber = 321, Postcode = "6666AA" }
            };
            PersonalInformation[] people = new PersonalInformation[] { person1, person2 };
            
            string fileName = "People.json";
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(people, options);
            File.WriteAllText(fileName, jsonString);

            Console.WriteLine(File.ReadAllText(fileName));

        }
    }
}

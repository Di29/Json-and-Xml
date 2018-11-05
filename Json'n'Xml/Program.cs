using System;
using System.IO;
using Newtonsoft.Json;
using System.Xml;

namespace Json_n_Xml
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Environment.CurrentDirectory;
            string peopleJson = @path + "\\people.json";
            string phoneJson = @path + "\\phone.json";
            string univereJson = @path + "\\univer.json";
            string peopleXml = @path + "\\people.xml";
            string phoneXml = @path + "\\phone.xml";
            string univereXml = @path + "\\univer.xml";

            Person[] people = new Person[] {
                new Person()
                {
                    FName = "Диас",
                    LName = "Уринбасаров",
                    PhoneNumber = "8700222020",
                    YearOfBirth = 1900
                },

                new Person()
                {
                    FName = "Азамат",
                    LName = "Бенгалин",
                    PhoneNumber = "87888888888",
                    YearOfBirth = 1999
                }
            };

            Phone[] phones = new Phone[]
            {
                new Phone()
                {
                    Mark = "Samsung",
                    Model = "Note 9",
                    Diagonal = 6.4
                },
                new Phone()
                {
                    Mark = "IPhone",
                    Model = "XS Max",
                    Diagonal = 6.5
                }
            };

            University[] universities = new University[]
            {
                new University()
                {
                    Name = "КазАТУ",
                    Rector = "Ахылбек Куришбаев",
                    NumberOfStudents = 5000
                },
                new University()
                {
                    Name = "ЕНУ",
                    Rector = "Сыдыков Ерлан",
                    NumberOfStudents = 6000
                }
            };

            string peopleString = JsonConvert.SerializeObject(people);
            string phonesString = JsonConvert.SerializeObject(phones);
            string universityString = JsonConvert.SerializeObject(universities);

            if (!File.Exists(peopleJson))
            {
                File.Create(peopleJson);
            }
            if (!File.Exists(phoneJson))
            {
                File.Create(phoneJson);
            }
            if (!File.Exists(univereJson))
            {
                File.Create(univereJson);
            }

            using (StreamWriter writer = new StreamWriter(peopleJson, false))
            {
                writer.WriteLine(peopleString);
            }

            using (StreamWriter writer = new StreamWriter(phoneJson, false))
            {
                writer.WriteLine(phonesString);
            }

            using (StreamWriter writer = new StreamWriter(univereJson, false))
            {
                writer.WriteLine(universityString);
            }

            XmlDocument xmlDocumentPeople = new XmlDocument();
            XmlDocument xmlDocumentPhones = new XmlDocument();
            XmlDocument xmlDocumentUnivers = new XmlDocument();

            XmlNode rootPeople = xmlDocumentPeople.CreateElement("People");
            XmlNode rootPhones = xmlDocumentPhones.CreateElement("Phones");
            XmlNode rootUniver = xmlDocumentUnivers.CreateElement("University");

            foreach (var person in people)
            {
                var personElement = xmlDocumentPeople.CreateElement("person");
                personElement.SetAttribute("firstName", person.FName);
                personElement.SetAttribute("lastName", person.LName);
                personElement.SetAttribute("phoneNumber", person.PhoneNumber);
                personElement.SetAttribute("birthDate", person.YearOfBirth.ToString());

                rootPeople.AppendChild(personElement);
            }

            foreach (var phone in phones)
            {
                var phoneElement = xmlDocumentPhones.CreateElement("phone");
                phoneElement.SetAttribute("mark", phone.Mark);
                phoneElement.SetAttribute("model", phone.Model);
                phoneElement.SetAttribute("diagonal", phone.Diagonal.ToString());

                rootPhones.AppendChild(phoneElement);
            }

            foreach (var univer in universities)
            {
                var univerElement = xmlDocumentUnivers.CreateElement("university");
                univerElement.SetAttribute("name", univer.Name);
                univerElement.SetAttribute("rector", univer.Rector);
                univerElement.SetAttribute("numberOfStudents", univer.NumberOfStudents.ToString());

                rootUniver.AppendChild(univerElement);
            }

            xmlDocumentPeople.AppendChild(rootPeople);
            xmlDocumentPhones.AppendChild(rootPhones);
            xmlDocumentUnivers.AppendChild(rootUniver);

            xmlDocumentPeople.Save(peopleXml);
            xmlDocumentPhones.Save(phoneXml);
            xmlDocumentUnivers.Save(univereXml);


            Console.WriteLine("People:\n{0} \nPhones:\n{1} \nUniversities:\n{2}", peopleString, phonesString, universityString);
            Console.ReadLine();
        }
    }
}

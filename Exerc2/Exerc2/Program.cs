using System;
using System.Collections.Generic;
using System.Linq;

namespace ListLINQ
{
    class Program
    {
        // Listas con LINQ
        #region Classes
        public class People {
            #region Properties
            public string Name { get; set; }
            public int Age { get; set; }
            public eGender Gender { get; set; } // Femenino - Masculino - Indefinido 
            #endregion

            #region Constructors
            public People() { } // no es necesario porque ya está declarado

            public People(string name, int age, eGender gender)
            {
                Name = name;
                Age = age;
                Gender = gender;
            }
            #endregion

            #region Methods
            public override string ToString() {
                return $"Nombre: {Name}, Edad: {Age}, Género: {this.GetStringGender(Gender)}";
            }

            private string GetStringGender(eGender gender) {
                string genderString;

                #region if
                /*if (gender == eGender.Undefined)
                    genderString = "Indefinido";
                else if (gender == eGender.Female)
                    genderString = "Femenino";
                else if (gender == eGender.Male)
                    genderString = "Masculino";
                else
                    genderString = "No válido";*/ 
                #endregion

                #region Switch
                /*switch (gender)
                {
                    case eGender.Undefined:
                        genderString = "Indefinido";
                        break;

                    case eGender.Female:
                        genderString = "Fmeenino";
                        break;

                    case eGender.Male:
                        genderString = "Masculino";
                        break;

                    default:
                        genderString = "No válido";
                        break;
                }*/
                #endregion

                #region Switch lambda
                genderString = gender switch {
                    eGender.Undefined => "Indefinido",
                    eGender.Female => "Femenino",
                    eGender.Male => "Masculino",
                    _ => "No válido",
                };
                #endregion

                return genderString;
            }
            #endregion
        }
        #endregion

        #region Enum
        public enum eGender
        {
            Undefined,// = 0,
            Female, // = 1,
            Male // = 2
        }
        #endregion

        static void Main(string[] args)
        {
            List<People> employeers = new()
            {
                new People
                {
                    Name = "María",
                    Age = 18,
                    Gender = eGender.Female
                },

                new People
                {
                    Name = "Andrea",
                    Age = 25,
                    Gender = eGender.Female
                },
            };

            if (employeers != null)
            {
                employeers.Add(new("Vaquera", 20, eGender.Male));
                employeers.Add(new("Miriam", 21, eGender.Female));
                employeers.Add(new("Marcos", 21, eGender.Male));
                employeers.Add(new("Elías", 22, eGender.Male));
                employeers.Add(new("Layla", 21, eGender.Male));
            }

            List<People> students = new()
            {
                new("Iris", 23, eGender.Female),
                new("Jesús", 26, eGender.Male),
                new("Andrés", 33, eGender.Male),
                new("América", 22, eGender.Female),
                new("Paola", 21, eGender.Female),
                new("Christian", 22, eGender.Male)
            };

            #region Where
            // Ejemplo 1: Filtrar nombres que comiencen con la letra 'A'
            // Lista de empleados

            Console.WriteLine("\nWHERE - Filtrar los nombres que comiencen con la letra 'A'");
            List<People> filteredEmployeers = employeers.Where(employeer => employeer.Name.StartsWith("A")).ToList();
            WriteLineE(filteredEmployeers);

            Console.WriteLine("\nWHERE - Filtrar empleados mayores a 30 años");
            filteredEmployeers = employeers.Where(employeer => employeer.Age > 20).ToList();
            WriteLineE(filteredEmployeers);
            #endregion

            #region Select

            #endregion

            /*foreach (People employeer in employeers) {
                Console.WriteLine($"Nombre: {employeer.Name}");
                Console.WriteLine($"Edad: {employeer.Age}");
                Console.WriteLine($"Género: {employeer.Gender}");
            }*/

            Console.ReadKey();
        }

        private static void WriteLineE(List<People> peopleList)
        {
            foreach (People people in peopleList)
            {
                Console.WriteLine(people.ToString());
            }
        }
    }
}
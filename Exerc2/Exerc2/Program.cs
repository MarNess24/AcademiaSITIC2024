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
            Console.WriteLine("\nSELECT - Tomar el nombre (sirve para seleccionar una propiedad en espacífico).");
            List<string> filteredEmployeersNames = employeers.Select(employeer => employeer.Name).ToList();
            
            foreach (string name in filteredEmployeersNames)
                Console.WriteLine(name);
            #endregion

            #region OrderBy & OrderByDescending
            Console.WriteLine("\nORDER BY - Ordenamiento por nombre vs la diferencia de la lista original");
            List<People> filteredStudents = students.OrderBy(student => student.Name).ToList();

            int i = 0;
            People originalStudent = null;

            foreach (var filteredStudent in filteredStudents) {
                originalStudent = students[i];
                Console.WriteLine($"{filteredStudent.Name} - {originalStudent.Name}");
                i++;
            }

            Console.WriteLine("\nORDER BY DESCENDING - Ordenamiento por edad y referenciarlo con la lista original");
            filteredStudents = students.OrderByDescending(student => student.Age).ToList();

            i = 0;
            originalStudent = null;

            foreach (var filteredStudent in filteredStudents)
            {
                originalStudent = students[i];
                Console.WriteLine($"{filteredStudent.Name} - {originalStudent.Name}");
                i++;
            }
            #endregion

            #region GroupBy
            Console.WriteLine("\nGROUP BY - Agrupamiento por género");
            var groupedByGender = students.GroupBy(student => student.Gender);

            foreach (var group in groupedByGender) {
                Console.WriteLine($"Género (grupo): {group.Key}");

                foreach (var person in group) {
                    Console.WriteLine($"{person.Name}");
                }
            }

            Console.WriteLine("\nGROUP BY - Agrupamiento por edad mostrando el nombre");
            var groupedByAge = employeers.GroupBy(employeer => employeer.Age);
            //int cont = 0;

            foreach (var group in groupedByAge) {
                //Console.WriteLine($"\nEdad (grupo): {group.Key}");
                Console.WriteLine($"\nEdad (grupo): {group.Key} - Total: {group.Count()}");

                foreach (var person in group) {
                    Console.WriteLine($"{person.Name}");
                    //cont++;
                }

                //Console.WriteLine($"Empleados de este grupo: {cont}");
                //cont = 0;
            }
            #endregion

            #region Any
            Console.WriteLine($"\nANY - Verifica si hay valores o no dentro de la lista");
            Console.WriteLine($"Existen valores en 'employeers': {employeers.Any()}");
            Console.WriteLine($"Existen empleados mayores de 30: {employeers.Any(i => i.Age > 30)}");
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
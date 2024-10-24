using System;

namespace Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            string courseName = "Academia SITIC"; // string y String es lo mismo
            String courseName2 = "Academia SITIC 2";

            int studentCount = 28;
            bool isStartingNow = true;

            int? age = null; // para valores nulos

            //1ra manera
            Console.WriteLine(age != null ? age : 0);

            // 2da manera
            if (age != null)
                Console.WriteLine(age);
            else
                Console.WriteLine(0);

            //3ra manera
            Console.WriteLine(age.GetValueOrDefault(0));


            Console.ReadKey();
            User user = new();
            Employer emp = new();
        }

        public class User
        {
            /*// Forma corta
            public int IdUser { get; set; }

            // Forma media
            private string _password;
            public string Password
            {
                get {
                    return _password;
                }

                set
                {
                    _password = value;
                }
            }

            // Forma larga      Atributos privados
            private string _name;

            public string GetName()
            {
                return _name;
            }

            public void SetName(string name)
            {
                _name = name;
            }*/

            private int idUser;
            private string _name;
            private string _password;

            public string Password { get => _password; set => _password = value; }
        }

        public class Person
        {
            public int PersonId { get; set; }
            public string Name { get; set; }
        }
        
        public class Employer : Person
        {
            public DateTime StartDate { get; set; }
        }
    }
}

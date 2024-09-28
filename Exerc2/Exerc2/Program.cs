using System;

namespace ListLINQ
{
    class Program
    {
        // Listas con LINQ
        #region Classes
        public class People {
            public string Name { get; set; }
            public int Age { get; set; }
            public eGender Gender { get; set; } // Femenino - Masculino - Indefinido
        }
        #endregion

        #region MyRegion
        public enum eGender
        {
            Undefined,// = 0,
            Female, // = 1,
            Male // = 2
        }
        #endregion

        static void Main(string[] args)
        {
            //
            
            Console.ReadKey();
        }
    }
}
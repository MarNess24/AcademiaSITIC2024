using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exerc2
{
    class ErrorHandler
    {
        #region Properties
        private static List<User> UserList { get; set; } = GetUsers();
        #endregion

        #region Variables
        private const int MIN_AGE = 10;
        private const int MAX_AGE = 100;
        #endregion

        #region Classes
        public class User
        {
            #region Properties
            public int UserId { get; set; }
            public string Username { get; set; }
            public string Password { get; set; } 
            #endregion

            #region Constructors
            public User() { }

            public User(int userId, string userName, string password) {
                UserId = userId;
                Username = userName;
                Password = password;
            }

            public User(string userName, string password) {
                Username = userName;
                Password = password;
            }
            #endregion
        }
        #endregion

        private static List<User> GetUsers()
        {
            return new()
            {
                new(1, "admin", "admin"),
                new(2, "layla", "1919"),
                new(3, "vanessa", "12345"),
                new(4, "equis", "contraseña")
            };
        }

        public static void Main(string[] args)
        {
            const string username = "Tamaris";
            const string password = "admin";

            Console.ReadKey();
        }

        public static int RegisterUserWithoutValidations ( string username, string password, string ageInput)
        {
            int userId, age;

            Console.WriteLine("Conexión a la base de datos");
            Console.WriteLine("Abrimos transacción");

            age = Convert.ToInt32(ageInput);

            Console.WriteLine("Ejecutamos acciones en la base de datos");

            if (!IsExiststingUser(username))
                InsertUser(new(username, password));

            return 0;
        }

        public static bool IsExiststingUser ( string username )
        {
            return UserList != null && UserList.Any(user=>user.Username == username);
            //return (UserList?.Any(user => user.Username == username)).GetValueOrDefault();
        }

        public static bool InsertUser ( User user )
        {
                                         //v "si es que"
            user.UserId = UserList != null ? ( UserList.Max(user => user.UserId) + 1 ) : 1;

            /*if (UserList != null)
                UserList.Add(user);
            else
                UserList = new();
                UserList.Add(user);*/

            if (UserList == null)
                UserList = new();

            UserList.Add(user);

            Console.WriteLine("Acción ejecutada en base de datos => Usuario insertado");

            return true;
        }
    }
}

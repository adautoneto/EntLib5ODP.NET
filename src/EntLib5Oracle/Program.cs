using System;
using System.Collections.Generic;

namespace EntLib5Oracle
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeader("Printing all users");

            var users = new UserData().GetAll();            
            PrintUsers(users);
                        
            PrintHeader("Printing user with id 2");

            var user = new UserData().GetById(2);
            PrintUser(user);

            Console.ReadKey(false);
        }

        private static void PrintHeader(string headerText)
        {
            Console.WriteLine();
            Console.WriteLine(headerText);
            Console.WriteLine("--------------------------------------------------");
        }

        private static void PrintUsers(IEnumerable<User> users)
        {
            foreach (var user in users) PrintUser(user);
        }

        private static void PrintUser(User user)
        {
            Console.WriteLine("Id:{0} - Name:{1} - Email:{2} - BirthDate:{3} - Phone:{4}",
                user.Id, user.Name, user.Email, (user.BirthDate.HasValue ? user.BirthDate.Value.ToShortDateString() : null), user.Phone);
        }
    }
}

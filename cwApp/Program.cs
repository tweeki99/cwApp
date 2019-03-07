using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CwApp
{
    class Program
    {
        static void Main(string[] args)
        {

            List<User> users = new List<User>();

            using (var stream = new StreamReader("data.json"))
            {

                string json = stream.ReadLine();
                List<User> result = JsonConvert.DeserializeObject<List<User>>(json);
                users = result;
            }

            // User result = JsonConvert.DeserializeObject<User>(json);

            while (true)
            {


                Console.WriteLine("1: Регистрация");
                Console.WriteLine("2: Вход");
                Console.WriteLine("3: Выход");

                var i = Console.ReadLine();
                if (i != "1" && i != "2" && i != "3")
                    Console.Clear();
                else if (i == "1")
                {
                    Registration(users);
                }
                else if (i == "2")
                {
                    Authorization(users);
                }
                else if (i == "3")
                    Environment.Exit(0);

            }


        }

        static public void Authorization(List<User> users)
        {
            int posUser;
            Console.Clear();
            while (true)
            {
                
                Console.WriteLine("Введите почту");
                string email = Console.ReadLine();

                bool check = true;
                int iteration = 0;
                foreach (var user in users)
                {
                    if (user.Email == email)
                    {
                        check = false;
                        break;
                    }
                    iteration++;
                }
                if (check)
                {
                    Console.Clear();
                    Console.WriteLine("Пользователь не найден");
                    //Console.ReadKey();
                }
                else
                {
                    posUser = iteration;
                    break;
                }
            }
            Console.Clear();

            while (true)
            {
                Console.WriteLine("Введите пароль");

                string password = Console.ReadLine();

                if (users[posUser].Password != password)
                {
                    Console.Clear();
                    Console.WriteLine("НЕВЕРНЫЙПАРОЛЬ");
                    //Console.ReadKey();

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Вход выполнен успешно");
                    //Console.ReadKey();
                    break;
                }

            }
            Console.Clear();
        }

            static public void Registration(List<User> users)
        {
            Console.Clear();

            User user = new User();

            Console.WriteLine("Введите почту");
            while (true)
            {
                if (!user.ReadEmail(Console.ReadLine()))
                {
                    Console.Clear();
                    Console.WriteLine("Неверный формат почты");
                    

                }
                else break;
            }
            Console.Clear();

            while (true)
            {
                Console.WriteLine("Введите и повторите пароль");
                if (!ReadPassword(user))
                {
                    Console.Clear();
                    Console.WriteLine("Пароли не совпадают");

                }
                else break;
            }
            Console.Clear();

            Console.WriteLine("Введите номер телефона");
            while (true)
            {
                if (!user.ReadPhone(Console.ReadLine()))
                {
                    Console.Clear();
                    Console.WriteLine("Неверный формат номера");

                }
                else break;
            }
            Console.Clear();

            Console.WriteLine("Введите город");
            user.City = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Введите свой возраст");
            user.Age = Console.ReadLine();


            users.Add(user);

            string json = JsonConvert.SerializeObject(users);

            using (var stream = new StreamWriter("data.json"))
            {

                stream.WriteLine(json);
            }

            //User result = JsonConvert.DeserializeObject<User>(json);
            Console.Clear();

            Console.WriteLine("Регистрация прошла успешно");
        }

        static public bool ReadPassword(User user)
        {
            string firstPassword = "";
            string secondPassword = "";

            ConsoleKeyInfo key = Console.ReadKey(true);
            while (key.Key != ConsoleKey.Enter)
            {
                Console.Write("*");
                key = Console.ReadKey(true);
                firstPassword += key.KeyChar;
            }

            Console.WriteLine();

            key = Console.ReadKey(true);

            while (key.Key != ConsoleKey.Enter)
            {
                Console.Write("*");
                key = Console.ReadKey(true);
                secondPassword += key.KeyChar;
            }

            Console.WriteLine();

            if (firstPassword != secondPassword)
            {
                return false;
            }
            else
            {
                user.Password = firstPassword;
                return true;
            }
        }
       
    }
}

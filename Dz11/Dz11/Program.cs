using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Dz11
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using FireSharp.Config;
    using FireSharp.Interfaces;
    using FireSharp.Response;

    internal class Program
    {
        static void PrintTableGroup(Dictionary<string, group> Data)
        {
            string str = "Name\t|login\t|password\t|current subject\t\n";
            foreach (var group in Data.Values)
                str += $"{group.Name}\t|{group.Login}\t|{group.Password}\t|{group.current_subject}\t\n";
            Console.WriteLine(str);
        }

        static void PrintTableGamerr(Dictionary<string, gamerr> Data)
        {
            string str = "Name\t Group\tYear\t\n";
            foreach (var gamerr in Data.Values)
                str += $"{gamerr.Name}\t|{gamerr.Group}\t|{gamerr.Year_Experience}\t\n";
            Console.WriteLine(str);
        }

        static void PrintTableGamer(Dictionary<string, gamer> Data)
        {
            string str = "Gamer: \n";
            foreach (var gamer in Data.Values)
                str += $"{gamer.Name}\n";
            Console.WriteLine(str);
        }

        static void Main(string[] args)
        {
            IFirebaseConfig ifc = new FirebaseConfig()
            {
                AuthSecret = "AIzaSyCYHu1LM6fcXkCyUV3koGyo7rghC--6qVU",
                BasePath = "https://dz11-d5b7d-default-rtdb.europe-west1.firebasedatabase.app/"
            };

            IFirebaseClient client = new FireSharp.FirebaseClient(ifc);

            while (true)
            {
                Console.WriteLine("1. Вивід даних\n2. Ввід даних\n3. Грати в казино");
                int task = int.Parse(Console.ReadLine());

                switch (task)
                {
                    case 1:
                        Console.WriteLine("1. Гравці\n2. Групи\n3. Гра");

                        switch (int.Parse(Console.ReadLine()))
                        {
                            case 1:
                                FirebaseResponse res = client.Get(@"Gamerr/");
                                Dictionary<string, gamerr> DataGamerr = JsonConvert.DeserializeObject<Dictionary<string, gamerr>>(res.Body.ToString());
                                PrintTableGamerr(DataGamerr);
                                break;
                            case 2:
                                FirebaseResponse res1 = client.Get(@"Group/");
                                Dictionary<string, group> DataGroup = JsonConvert.DeserializeObject<Dictionary<string, group>>(res1.Body.ToString());
                                PrintTableGroup(DataGroup);
                                break;
                            case 3:
                                FirebaseResponse res2 = client.Get(@"Gamer/");
                                Dictionary<string, gamer> DataGamer = JsonConvert.DeserializeObject<Dictionary<string, gamer>>(res2.Body.ToString());
                                PrintTableGamer(DataGamer);
                                break;
                            default:
                                Console.WriteLine("Варіант невірний, спробуйте ще раз.");
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("1. Гравці\n2. Групи\n3. Гра");

                        switch (int.Parse(Console.ReadLine()))
                        {
                            case 1:
                                var Gamerr = new gamerr
                                {
                                    Name = Console.ReadLine(),
                                    Group = Console.ReadLine(),
                                    Year_Experience = Console.ReadLine()
                                };
                                client.Set(@"Gamerr/" + Gamerr.Name, Gamerr);
                                break;
                            case 2:
                                var Group = new group
                                {
                                    Name = Console.ReadLine(),
                                    current_subject = Console.ReadLine(),
                                    Login = Console.ReadLine(),
                                    Password = Console.ReadLine()
                                };
                                client.Set(@"Group/" + Group.Name, Group);
                                break;
                            case 3:
                                var Gamer = new gamer
                                {
                                    Name = Console.ReadLine()
                                };
                                client.Set(@"Gamer/" + Gamer.Name, Gamer);
                                break;
                            default:
                                Console.WriteLine("Варіант невірний, спробуйте ще раз.");
                                break;
                        }
                        break;
                    case 3:
                        Console.WriteLine("Запуск гри в казино");
                        break;
                }
            }
        }
    }

}


using MongoDbCRUDapp.Data;
using MongoDbCRUDapp.Models;
using static System.Formats.Asn1.AsnWriter;

namespace MongoDbCRUDapp
{
    internal class Program
    {
        static MongoCRUD db = new MongoCRUD("MongoDB_FightingGame");
        static List<Fighter> fightersList = new List<Fighter>();
        static void Main(string[] args)
        {
            while (true)
            {

                string[] menuOptions = new string[] { "Add Fighter", "Get Fighters", "Get Fighter by ID", "Update Fighter", "Delete Fighter" };
                int menuSelect = 0;

                while (true)
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    if (menuSelect == 0)
                    {
                        Console.WriteLine(menuOptions[0] + "**");
                        Console.WriteLine(menuOptions[1]);
                        Console.WriteLine(menuOptions[2]);
                        Console.WriteLine(menuOptions[3]);
                        Console.WriteLine(menuOptions[4]);

                    }

                    else if (menuSelect == 1)
                    {
                        Console.WriteLine(menuOptions[0]);
                        Console.WriteLine(menuOptions[1] + "**");
                        Console.WriteLine(menuOptions[2]);
                        Console.WriteLine(menuOptions[3]);
                        Console.WriteLine(menuOptions[4]);
                    }

                    else if (menuSelect == 2)
                    {
                        Console.WriteLine(menuOptions[0]);
                        Console.WriteLine(menuOptions[1]);
                        Console.WriteLine(menuOptions[2] + "**");
                        Console.WriteLine(menuOptions[3]);
                        Console.WriteLine(menuOptions[4]);
                    }

                    else if (menuSelect == 3)
                    {
                        Console.WriteLine(menuOptions[0]);
                        Console.WriteLine(menuOptions[1]);
                        Console.WriteLine(menuOptions[2]);
                        Console.WriteLine(menuOptions[3] + "**");
                        Console.WriteLine(menuOptions[4]);
                    }

                    else if (menuSelect == 4)
                    {
                        Console.WriteLine(menuOptions[0]);
                        Console.WriteLine(menuOptions[1]);
                        Console.WriteLine(menuOptions[2]);
                        Console.WriteLine(menuOptions[3]);
                        Console.WriteLine(menuOptions[4] + "**");
                    }

                    var key = Console.ReadKey();

                    if (key.Key == ConsoleKey.DownArrow && menuSelect != menuOptions.Length - 1)
                    {
                        menuSelect++;
                    }

                    if (key.Key == ConsoleKey.UpArrow && menuSelect >= 1)
                    {
                        menuSelect--;
                    }

                    if (key.Key == ConsoleKey.Enter)
                    {
                        switch (menuSelect)
                        {
                            case 0:
                                AddFighter();
                                break;

                            case 1:
                                GetFighters();
                                break;

                            case 2:
                                GetFighterById();
                                break;

                            case 3:
                                UpdateFighter();
                                break;

                            case 4:
                                DeleteFighters();
                                break;

                        }
                    }
                }

            }
        }

        static void AddFighter()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of your fighter");
            string fighterName = Console.ReadLine();
            Console.WriteLine("What is your fighting style?");
            string fightingStyle = Console.ReadLine();
            Console.WriteLine("What is your special ability?");
            string specialAbility = Console.ReadLine();
            Fighter fighter = new Fighter()
            {
                Name = fighterName,
                FightingStyle = fightingStyle,
                SpecialAbility = specialAbility,
                Hp = 100
            };
            db.AddFighter("Fighters", fighter);
            Console.WriteLine($"{fighter.Name} is now playable!");
            Console.ReadLine();
        }

        static void GetFighters()
        {
            Console.Clear();
            fightersList = db.GetFighters("Fighters");
            Console.WriteLine("Playable characters:");
            foreach (var item in fightersList)
            {
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine($"{item.Name}");
                Console.WriteLine($"Fighting style: {item.FightingStyle}");
                Console.WriteLine($"Special ability: {item.SpecialAbility}");
                Console.WriteLine($"HP: {item.Hp}");
                Console.WriteLine("----------------------------------------------------------------------");
                Console.WriteLine();


            }
            Console.ReadKey();
        }

        static void GetFighterById()
        {
            if (fightersList.Count > 0)
            {
                var result = db.GetFighterById("Fighters", fightersList[0].Id);
                Console.WriteLine($"Found fighter {result.Name}");
            } else
            {
                Console.WriteLine("No fighters was found");
            }

            Console.ReadKey();
        }

        static void UpdateFighter()
        {
            if (fightersList.Count > 0)
            {
                db.UpdateFighter("Fighters", fightersList[0]);
            }
            else
            {
                Console.WriteLine("No fighters available to update.");
            }
            Console.ReadKey();
        }

        static void DeleteFighters()
        {
            if (fightersList.Count > 0)
            {
                db.DeleteFighter("Fighters", fightersList[0].Id);
            }
            else
            {
                Console.WriteLine("No fighters available to delete.");
            }
            Console.ReadKey();
        }



    }
}
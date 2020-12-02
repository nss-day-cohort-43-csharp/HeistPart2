using System;
using System.Collections.Generic;

namespace TeamSixHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an initial list of robbers
            List<IRobber> rolodex = new List<IRobber>()
            {
                new Hacker()
                {
                    Name = "Bill Burr",
                    SkillLevel = 30,
                    PercentageCut = 25
                },
                new Hacker()
                {
                    Name = "Sam",
                    SkillLevel = 75,
                    PercentageCut = 40
                },
                new LockSpecialist()
                {
                    Name = "CJ",
                    SkillLevel = 70,
                    PercentageCut = 40
                },
                new LockSpecialist()
                {
                    Name = "Tom Segura",
                    SkillLevel = 60,
                    PercentageCut = 30
                },
                new Muscle()
                {
                    Name = "Brady",
                    SkillLevel = 88,
                    PercentageCut = 15
                },
                new Muscle()
                {
                    Name = "John Mulaney",
                    SkillLevel = 20,
                    PercentageCut = 45
                }
            };

            //print initial number of criminals
            Console.WriteLine($"Number of criminals: {rolodex.Count}");

            //allow user to add as many criminals as they want
            while(true)
            {
                //prompt for a new criminal
                Console.WriteLine("Is there another criminal you know? If so, what is their name?");
                string name = Console.ReadLine();

                if(name == "")
                {
                    break;
                }

                int selection = 0;
                //prompt for a specialty
                while(true)
                {
                    Console.WriteLine("What is their specialty?\n1) Hacker\n2) Muscle\n3) Lock Specialist");
                    try
                    {
                        selection = Int32.Parse(Console.ReadLine());
                        if(selection <= 0 || selection > 3)
                        {
                            throw new Exception();
                        }
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Please enter either 1, 2, or 3");
                    }
                }

                //prompt for skill level
                int skillLevel = 0;
                while (true) 
                {
                    Console.Write("Skill Level (between 1 and 100): ");
                    try
                    {
                        skillLevel = Int32.Parse(Console.ReadLine());
                        if(skillLevel <= 0 || skillLevel > 100)
                        {
                            throw new Exception();
                        }
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Skill Level must be an integer between 1 and 100");
                    }
                }

                //prompt for skill level
                int cut = 0;
                while (true) 
                {
                    Console.Write("Cut (between 1 and 100): ");
                    try
                    {
                        cut = Int32.Parse(Console.ReadLine());
                        if(cut <= 0 || cut > 100)
                        {
                            throw new Exception();
                        }
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Cut must be an integer between 1 and 100");
                    }
                }

                //declare a type of instance based on the user's choice
                // IRobber newCriminal;
                // switch (selection)
                // {
                //     case 1:
                //         newCriminal = new Hacker();
                //         break;
                //      case 2:
                //         newCriminal = new Muscle();
                //         break;
                //     case 3:
                //         newCriminal = new LockSpecialist();
                //         break;    
                // }

            }
        }
    }
}

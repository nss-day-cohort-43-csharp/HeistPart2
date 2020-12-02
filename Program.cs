using System;
using System.Collections.Generic;
using System.Linq;

namespace TeamSixHeist
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IRobber> rolodex = CreateRolodex();

            // create a new bank 
            Bank b = new Bank();
            b.Recon();

            //display the rolodex
            DisplayRolodex(rolodex);

            //create the crew
            List<IRobber> crew = CreateCrew(rolodex);

            bool isSuccess = PassOrFail(crew, b);

            DisplaySuccess(crew, b, isSuccess);

        }

        static void DisplaySuccess(List<IRobber> crew, Bank b, bool isSuccess)
        {
            // If we passed the heist
            if (isSuccess)
            {
                // Get bank's cash
                double bankCash = Convert.ToDouble(b.CashOnHand);
                // Store a separate variable of our cash
                double myCut = bankCash;
                //   interate over criminals and get their cut
                crew.ForEach(c =>
                {
                    double criminalCutPercent = Convert.ToDouble(c.PercentageCut) / 100.0;
                    double criminalCutAmount = bankCash * criminalCutPercent;
                    myCut -= criminalCutAmount;
                    Console.WriteLine($"{c.Name}'s cut was {criminalCutAmount.ToString("0.00")}");
                });

                Console.WriteLine($"My cut is {myCut.ToString("0.00")}");
            }
        }

        static List<IRobber> CreateCrew(List<IRobber> rolodex)
        {
            //declare the crew
            List<IRobber> crew = new List<IRobber>();

            //declare and initialize the total cut
            int totalCutLeft = 100;

            //prompt the user
            while (rolodex.Count > 0)
            {
                //make sure selection is valid
                int indexOfSelection = 0;
                string selection = "dummy";
                while (true)
                {
                    //prompt for selection
                    Console.Write("Pick criminal for your crew: ");
                    selection = Console.ReadLine();
                    //if blank, exit
                    if (selection == "")
                    {
                        break;
                    }
                    try
                    {
                        //try to parse
                        indexOfSelection = Int32.Parse(selection) - 1;
                        //make sure it is not out of bounds
                        if (indexOfSelection < 0 || indexOfSelection >= rolodex.Count)
                        {
                            throw new Exception();
                        }
                        //make sure there is enough cut left
                        if (rolodex[indexOfSelection].PercentageCut > totalCutLeft)
                        {
                            Console.WriteLine("That criminal is too greedy");
                            throw new Exception();
                        }

                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid selection");
                    }
                }

                //if user enters nothing, exit
                if (selection == "")
                {
                    break;
                }

                //grab the selected criminal
                IRobber selectedCriminal = rolodex[indexOfSelection];

                //decrement the totalCut by the selected criminals cut
                totalCutLeft -= selectedCriminal.PercentageCut;

                //add the criminal to the crew and remove it from the rolodex
                crew.Add(selectedCriminal);
                rolodex.RemoveAt(indexOfSelection);

                //display the rolodex
                DisplayRolodex(rolodex);
            }
            return crew;
        }

        static void DisplayRolodex(List<IRobber> rolodex)
        {
            // Iterate list of robbers and display their stats
            int indexValue = 1;
            rolodex.ForEach(robber =>
            {
                string specialty = robber.GetType().ToString().Split(".")[1];

                Console.WriteLine($"{indexValue}: {robber.Name}\nSpecialty: {specialty}\nSkill Level: {robber.SkillLevel}\nCut: {robber.PercentageCut}");
                Console.WriteLine("");
                ++indexValue;
            });
        }

        static List<IRobber> CreateRolodex()
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
                    SkillLevel = 80,
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
                    SkillLevel = 90,
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
            while (true)
            {
                //prompt for a new criminal
                Console.WriteLine("Is there another criminal you know? If so, what is their name?");
                string name = Console.ReadLine();

                if (name == "")
                {
                    break;
                }

                int selection = 0;
                //prompt for a specialty
                while (true)
                {
                    Console.WriteLine("What is their specialty?\n1) Hacker\n2) Muscle\n3) Lock Specialist");
                    try
                    {
                        selection = Int32.Parse(Console.ReadLine());
                        if (selection <= 0 || selection > 3)
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
                        if (skillLevel <= 0 || skillLevel > 100)
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
                        if (cut <= 0 || cut > 100)
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

                // add appropiate typr of criminal with user's choices
                switch (selection)
                {
                    case 1:
                        rolodex.Add(new Hacker(name, skillLevel, cut));
                        break;
                    case 2:
                        rolodex.Add(new Muscle(name, skillLevel, cut));
                        break;
                    case 3:
                        rolodex.Add(new LockSpecialist(name, skillLevel, cut));
                        break;
                }
            }

            return rolodex;
        }


        static bool PassOrFail(List<IRobber> crew, Bank b)
        {
            List<Muscle> muscleCriminsls = crew.OfType<Muscle>().ToList();
            List<Hacker> hackerCriminals = crew.OfType<Hacker>().ToList();
            List<LockSpecialist> lockCriminals = crew.OfType<LockSpecialist>().ToList();

            List<int> muscleValues = muscleCriminsls.Select(m => m.SkillLevel).ToList();
            List<int> hackerValues = hackerCriminals.Select(h => h.SkillLevel).ToList();
            List<int> lockValues = lockCriminals.Select(l => l.SkillLevel).ToList();

            int musclesTotal = muscleValues.Sum();
            int hackersTotal = hackerValues.Sum();
            int locksTotal = lockValues.Sum();

            if (musclesTotal < b.SecurityGuardScore || hackersTotal < b.AlarmScore || locksTotal < b.VaultScore)
            {
                Console.WriteLine("Failed");
                return false;
            }
            else
            {
                Console.WriteLine("Success");
                return true;
            }
        }
    }
}

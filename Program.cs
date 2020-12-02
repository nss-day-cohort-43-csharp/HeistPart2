using System;
using System.Collections.Generic;

namespace TeamSixHeist
{
    class Program
    {
        static void Main(string[] args)
        {
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
        }
    }
}

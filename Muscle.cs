using System;

namespace TeamSixHeist
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerfromSkill(Bank b)
        {
            int finalScore = b.SecurityGuardScore - SkillLevel;

            Console.WriteLine($"{Name} beat up security guards by {SkillLevel}.");
            if (finalScore <= 0) Console.WriteLine($"{Name} knocked out the guards!");
        }
    }
}
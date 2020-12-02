using System;

namespace TeamSixHeist
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerfromSkill(Bank b)
        {
            int finalScore = b.AlarmScore - SkillLevel;

            Console.WriteLine($"{Name} decreased the alarm score by {SkillLevel}.");
            if (finalScore <= 0) Console.WriteLine($"{Name} disabled the alarms!");
        }
    }
}
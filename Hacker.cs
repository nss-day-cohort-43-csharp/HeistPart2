using System;

namespace TeamSixHeist
{
    public class Hacker : IRobber
    {
        //empty constructor
        public Hacker()
        {

        }
        //overload for initialize
        public Hacker(string name, int skill, int cut)
        {
            Name = name;
            SkillLevel = skill;
            PercentageCut = cut;
        }

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
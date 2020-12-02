using System;

namespace TeamSixHeist
{
    public class LockSpecialist : IRobber
    {
        //empty constructor
        public LockSpecialist()
        {

        }
        //orverload for initialize
         public LockSpecialist(string name, int skill, int cut)
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
           int finalScore = b.VaultScore - SkillLevel;
           
           Console.WriteLine($"{Name} decreased the vault score by {SkillLevel}.");
           if (finalScore <= 0) Console.WriteLine($"{Name} cracked the vault!");
        }
    }
}
namespace TeamSixHeist
{
  public interface IRobber
  {
    string Name { get; set; }
    int SkillLevel { get; set; }
    int PercentageCut { get; set; }
    void PerfromSkill(Bank b);
  }
}
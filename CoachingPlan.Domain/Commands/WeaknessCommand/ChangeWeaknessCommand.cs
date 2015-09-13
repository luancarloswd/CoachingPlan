namespace CoachingPlan.Domain.Commands.WeaknessCommand
{
    public class ChangeWeaknessCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ChangeWeaknessCommand(string name, string description = null)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}

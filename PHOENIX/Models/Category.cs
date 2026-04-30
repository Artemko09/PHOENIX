namespace PHOENIX.Models
{
    public class Category
    {
        public int Id { get; init; }
        public string? Name { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public double MinWeight { get; set; }
        public double MaxWeight { get; set; }
        public Discipline DisciplineType { get; set; }
        public Gender Gender { get; set; }
        public virtual ICollection<Sportsman> Sportsmen { get; set; } = new List<Sportsman>();
    }

    public enum Discipline
    {
        Kata = 0,
        Kumite = 1,
        Phantom = 2,
        TeamKata = 3,
        TeamKumite = 4
    }
}
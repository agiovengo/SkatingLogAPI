namespace SkatingLogAPI.Infrastructure.Models
{
    public class LevelState
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string FreestyleLevel { get; set; } = String.Empty;
        public string DanceLevel { get; set; } = String.Empty;
        public string PairsLevel { get; set; } = String.Empty;

        public virtual ICollection<LogEntry> LogEntries { get; set; }
    }
}

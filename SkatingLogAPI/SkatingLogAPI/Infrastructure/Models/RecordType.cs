namespace SkatingLogAPI.Infrastructure.Models
{
    public class RecordType
    {
        public int Id { get; set; }
        public string Description { get; set; } = String.Empty;

        public virtual ICollection<LogEntry> LogEntries { get; set; } = new List<LogEntry>();
    }
}

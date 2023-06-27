namespace SkatingLogAPI.Infrastructure.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LogEntry> LogEntries { get; set; }
    }
}

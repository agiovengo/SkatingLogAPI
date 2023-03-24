namespace SkatingLogAPI.Infrastructure.Models
{
    public class Subclass
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Classification { get; set; }

        public virtual ICollection<SkatingLogEntry> SkatingLogEntries { get; set; }
    }
}

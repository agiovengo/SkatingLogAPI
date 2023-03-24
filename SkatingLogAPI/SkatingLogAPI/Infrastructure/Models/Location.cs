namespace SkatingLogAPI.Infrastructure.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SkatingLogEntry> SkatingLogEntries { get; set; }
    }
}

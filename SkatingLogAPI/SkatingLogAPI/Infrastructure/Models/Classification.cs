namespace SkatingLogAPI.Infrastructure.Models
{
    public class Classification
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SkatingLogEntry> SkatingLogEntries { get; set; }
    }
}

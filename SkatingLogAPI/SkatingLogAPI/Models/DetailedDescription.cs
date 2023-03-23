namespace SkatingLogAPI.Models
{
    public class DetailedDescription
    {
        public int DetailedDescriptionId { get; set; }
        public int EntryId { get; set; }
        public string Description { get; set; } = String.Empty;
        public virtual SkatingLogEntry SkatingLogEntry { get; set; } = new SkatingLogEntry();
    }
}

namespace SkatingLogAPI.Models
{
    public class SkatingLogEntry
    {
        public int EntryId { get; set; }
        public DateTime EntryDateTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime StopDateTime { get; set; }
        public int EntryClassificationId { get; set; }
        public int LocationId { get; set; }
        public string BasicDescription { get; set; } = String.Empty;
        public int FreestyleLevel { get; set; }
        public int DanceLevel { get; set; }
        public int TotalTimeMinutes { get; set; }
        public virtual List<DetailedDescription> DetailedDescriptions { get; set; } = new List<DetailedDescription>();
    }
}

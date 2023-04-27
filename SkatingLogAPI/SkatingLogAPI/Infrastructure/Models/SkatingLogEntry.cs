namespace SkatingLogAPI.Infrastructure.Models
{
    public class SkatingLogEntry
    {
        public int EntryId { get; set; }
        public DateTime EntryDateTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime StopDateTime { get; set; }
        public int ClassificationId { get; set; }
        public int SubclassId { get; set; }
        public int LocationId { get; set; }
        public string BasicDescription { get; set; }
        public string DetailedDescription { get; set; }
        public int FreestyleLevel { get; set; }
        public int DanceLevel { get; set; }
        public int TotalTimeMinutes { get; set; }

        public virtual Classification Classification { get; set; }
        public virtual Subclass Subclass { get; set; }
        public virtual Location Location { get; set; }
    }

    public class SkatingLogEntryView
    {
        public DateTime EntryDateTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime StopDateTime { get; set; }
        public string Classification { get; set; }
        public string Subclass { get; set; }
        public string Location { get; set; }
        public string BasicDescription { get; set; }
        public string DetailedDescription { get; set; }
        public int FreestyleLevel { get; set; }
        public int DanceLevel { get; set; }
        public int TotalTimeMinutes { get; set; }
    }

}

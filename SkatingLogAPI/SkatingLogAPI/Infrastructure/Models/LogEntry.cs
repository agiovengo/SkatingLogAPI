namespace SkatingLogAPI.Infrastructure.Models
{
    public class LogEntry
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime StopDateTime { get; set; }
        public int RecordTypeId { get; set; }
        public int LocationId { get; set; }
        public string BasicDescription { get; set; } = String.Empty;
        public string DetailedDescription { get; set; } = String.Empty;
        public int LevelStateId { get; set; }
        public bool IsOnIce { get; set; }
        public int TotalTimeMinutes { get; set; }

        public virtual RecordType RecordType { get; set; }
        public virtual Location Location { get; set; }
        public virtual LevelState LevelState { get; set; }
    }

    public class LogEntryView
    {
        public DateTime StartDateTime { get; set; }
        public DateTime StopDateTime { get; set; }
        public string RecordType { get; set; } = String.Empty;
        public string Location { get; set; } = String.Empty;
        public string BasicDescription { get; set; } = String.Empty;
        public string DetailedDescription { get; set; } = String.Empty;
        public string LevelState { get; set; } = String.Empty;
        public string OnIce { get; set; } = String.Empty;
        public int TotalTimeMinutes { get; set; }
    }

    public class AddLogEntry
    {
        public DateTime StartDateTime { get; set; }
        public DateTime StopDateTime { get; set; }
        public int RecordTypeId { get; set; }
        public int LocationId { get; set; }
        public string BasicDescription { get; set; } = String.Empty;
        public string DetailedDescription { get; set; } = String.Empty;
        public bool IsOnIce { get; set; }
    }

}

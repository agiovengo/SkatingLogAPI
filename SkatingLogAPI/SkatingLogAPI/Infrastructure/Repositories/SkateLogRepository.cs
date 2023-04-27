using Microsoft.EntityFrameworkCore;
using SkatingLogAPI.Contexts;
using SkatingLogAPI.Infrastructure.Models;

namespace SkatingLogAPI.Infrastructure.Repositories
{
    public class SkateLogRepository
    {
        public SkatingLogDBContext dbContext { get; set; }
        public SkateLogRepository(SkatingLogDBContext dBContext) 
        { 
            this.dbContext = dBContext;
        }

        public SkatingLogEntryView ConvertEntryToView(SkatingLogEntry entry)
        {
            return new SkatingLogEntryView()
            {
                BasicDescription = entry.BasicDescription,
                Classification = entry.Classification.Description,
                DanceLevel = entry.DanceLevel,
                DetailedDescription = entry.DetailedDescription,
                EntryDateTime = entry.EntryDateTime,
                FreestyleLevel = entry.FreestyleLevel,
                Location = entry.Location.Description,
                StartDateTime = entry.StartDateTime,
                StopDateTime = entry.StopDateTime,
                Subclass = entry.Subclass.Description,
                TotalTimeMinutes = entry.TotalTimeMinutes
            };
        }

        public SkatingLogEntry SampleEntry = new()
        {
            EntryDateTime = DateTime.Now,
            StartDateTime = DateTime.Now.AddMinutes(-60),
            StopDateTime = DateTime.Now,
            ClassificationId = 1,
            SubclassId = 0,
            LocationId = 1,
            BasicDescription = "Public Session",
            DetailedDescription = "Skated for an hour",
            FreestyleLevel = 2,
            DanceLevel = 3,
        };

        public void DebugEntry(SkatingLogEntry entry)
        {
            Console.WriteLine("Entry ID: " + entry.EntryId);
            Console.WriteLine("Entry Date Time: " + entry.EntryDateTime);
            Console.WriteLine("Start Date Time: " + entry.StartDateTime);
            Console.WriteLine("Stop Date Time: " + entry.StopDateTime);
            Console.WriteLine("Entry Classification ID: " + entry.ClassificationId);
            Console.WriteLine("Entry Subclass ID: " + entry.SubclassId);
            Console.WriteLine("Location ID: " + entry.LocationId);
            Console.WriteLine("Basic Description: " + entry.BasicDescription);
            Console.WriteLine("Freestyle Level: " + entry.FreestyleLevel);
            Console.WriteLine("Dance Level: " + entry.DanceLevel);
            Console.WriteLine("Total Time (minutes): " + entry.TotalTimeMinutes);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using SkatingLogAPI.Contexts;
using SkatingLogAPI.Infrastructure.Models;

namespace SkatingLogAPI.Infrastructure.Repositories
{
    public class SkateLogRepository
    {
        public dBContext dbContext { get; set; }
        public SkateLogRepository(dBContext dBContext) 
        { 
            this.dbContext = dBContext;
        }


        //public LogEntry SampleEntry = new()
        //{
        //    EntryDateTime = DateTime.Now,
        //    StartDateTime = DateTime.Now.AddMinutes(-60),
        //    StopDateTime = DateTime.Now,
        //    ClassificationId = 1,
        //    SubclassId = 0,
        //    LocationId = 1,
        //    BasicDescription = "Public Session",
        //    DetailedDescription = "Skated for an hour",
        //    FreestyleLevel = 2,
        //    DanceLevel = 3,
        //};

        //public void DebugEntry(LogEntry entry)
        //{
        //    Console.WriteLine("ID: " + entry.Id);
        //    Console.WriteLine("Created Date Time: " + entry.CreatedDateTime);
        //    Console.WriteLine("Start Date Time: " + entry.StartDateTime);
        //    Console.WriteLine("Stop Date Time: " + entry.StopDateTime);
        //    Console.WriteLine("Basic Description: " + entry.BasicDescription);
        //    Console.WriteLine("Total Time (minutes): " + entry.TotalTimeMinutes);
        //}

        public ListContainer GetListContainer() {
            var locations = dbContext.Locations.ToList();
            var levelStates = dbContext.LevelStates.OrderByDescending(l => l.Date).ToList();
            var subclasses = dbContext.RecordTypes.ToList();

            return new ListContainer { Locations = locations, LevelStates = levelStates, RecordTypes = subclasses };
        }
    }
}
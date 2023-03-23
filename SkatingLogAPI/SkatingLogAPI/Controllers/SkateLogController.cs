using Microsoft.AspNetCore.Mvc;
using SkatingLogAPI.Contexts;
using SkatingLogAPI.Models;

namespace SkatingLogAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkateLogController : ControllerBase
    {
        private SkatingLogDBContext dbContext = new SkatingLogDBContext();

        private static readonly SkatingLogEntry SampleEntry = new()
        {
            EntryDateTime = DateTime.Now,
            StartDateTime = DateTime.Now.AddMinutes(-60),
            StopDateTime = DateTime.Now,
            EntryClassificationId = 1,
            LocationId = 1,
            BasicDescription = "Skated for an hour",
            FreestyleLevel = 2,
            DanceLevel = 3,
            DetailedDescriptions = new List<DetailedDescription>()
            {
                new DetailedDescription
                {
                    Description = "Testing Detailed Description"
                },
                new DetailedDescription
                {
                    Description = "Testing Detailed Description 2"
                },
            }
        };

        private readonly ILogger<SkateLogController> _logger;

        public SkateLogController(ILogger<SkateLogController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "AddSampleSkatingLogEntry")]
        public bool AddSampleSkatingLogEntry()
        {
            try
            {
                // Add the new entry to the database
                dbContext.SkatingLogEntries.Add(SampleEntry);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpGet(Name = "GetSkatingLogEntries")]
        public List<SkatingLogEntry> GetSkatingLogEntries()
        {
            // Get all entries from the database
            var entries = dbContext.SkatingLogEntries.ToList();
            foreach (var entry in entries)
            {
                Console.WriteLine("Entry ID: " + entry.EntryId);
                Console.WriteLine("Entry Date Time: " + entry.EntryDateTime);
                Console.WriteLine("Start Date Time: " + entry.StartDateTime);
                Console.WriteLine("Stop Date Time: " + entry.StopDateTime);
                Console.WriteLine("Entry Classification ID: " + entry.EntryClassificationId);
                Console.WriteLine("Location ID: " + entry.LocationId);
                Console.WriteLine("Basic Description: " + entry.BasicDescription);
                Console.WriteLine("Freestyle Level: " + entry.FreestyleLevel);
                Console.WriteLine("Dance Level: " + entry.DanceLevel);
                Console.WriteLine("Total Time (minutes): " + entry.TotalTimeMinutes);
                Console.WriteLine();
            };

            return entries;
        }
    }
}
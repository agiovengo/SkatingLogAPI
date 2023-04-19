using Microsoft.AspNetCore.Mvc;
using SkatingLogAPI.Contexts;
using SkatingLogAPI.Infrastructure.Models;
using System.Data.Entity;

namespace SkatingLogAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkateLogController : ControllerBase
    {
        private SkatingLogDBContext _dbContext;
        private readonly ILogger<SkateLogController> _logger;

        private SkatingLogEntry SampleEntry = new()
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


        public SkateLogController(ILogger<SkateLogController> logger, SkatingLogDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        [HttpPost]
        [ActionName("AddSkatingLogEntry")]
        [Route("[action]")]
        //[Route("AddSkatingLogEntry")]
        public bool AddSkatingLogEntry(SkatingLogEntry skatingLogEntry)
        {
            // TODO: Add data Validation here

            try
            {
                // Add the new entry to the database
                _dbContext.SkatingLogEntries.Add(skatingLogEntry);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpPost]
        [ActionName("AddSampleSkatingLogEntry")]
        [Route("[action]")]
        public bool AddSampleSkatingLogEntry()
        {
            try
            {
                // Add the new entry to the database
                _dbContext.SkatingLogEntries.Add(SampleEntry);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpGet(Name = "GetSkatingLogEntries")]
        public List<SkatingLogEntry> GetSkatingLogEntries()
        {
            try
            {
                // Get all entries from the database
                var entries = _dbContext.SkatingLogEntries.ToList();
                foreach (var entry in entries)
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
                    Console.WriteLine();
                };

                return entries;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
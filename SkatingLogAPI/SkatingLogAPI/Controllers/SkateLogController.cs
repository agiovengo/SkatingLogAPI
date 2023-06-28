using Microsoft.AspNetCore.Mvc;
using SkatingLogAPI.Contexts;
using SkatingLogAPI.Infrastructure.Models;
using SkatingLogAPI.Infrastructure.Repositories;
using System.Data.Entity;

namespace SkatingLogAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkateLogController : ControllerBase
    {
        private dBContext dbContext;
        private readonly ILogger<SkateLogController> logger;
        private readonly SkateLogRepository repository;

        public SkateLogController(ILogger<SkateLogController> logger, dBContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;

            repository = new SkateLogRepository(dbContext);
        }

        [HttpPost]
        [ActionName("AddLogEntry")]
        [Route("[action]")]
        public bool AddLogEntry(AddLogEntry skatingLogEntry)
        {
            // TODO: Add data Validation here

            try
            {
                // Add the new entry to the database

                var currentLevelStateId = dbContext.LevelStates.OrderByDescending(x => x.Date).FirstOrDefault()?.Id ?? 0;

                LogEntry newLogEntry = new LogEntry {
                    CreatedDateTime = DateTime.Now,
                    BasicDescription = skatingLogEntry.BasicDescription,
                    DetailedDescription = skatingLogEntry.DetailedDescription,
                    IsOnIce = skatingLogEntry.IsOnIce,
                    LocationId = skatingLogEntry.LocationId,
                    LevelStateId = currentLevelStateId,
                    RecordTypeId = skatingLogEntry.RecordTypeId,
                    StartDateTime = skatingLogEntry.StartDateTime,
                    StopDateTime = skatingLogEntry.StopDateTime
                };

                dbContext.LogEntries.Add(newLogEntry);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //[HttpPost]
        //[ActionName("AddSampleSkatingLogEntry")]
        //[Route("[action]")]
        //public bool AddSampleSkatingLogEntry()
        //{
        //    try
        //    {
        //        // Add the new entry to the database
        //        dbContext.SkatingLogEntries.Add(repository.SampleEntry);
        //        dbContext.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //        return false;
        //    }
        //}

        [HttpGet]
        [ActionName("GetSkatingLogEntries")]
        [Route("[action]")]
        public List<LogEntry> GetSkatingLogEntries()
        {
            try
            {
                // Get all entries from the database
                var entries = dbContext.LogEntries.ToList();
                //foreach (var entry in entries)
                //{
                //    repository.DebugEntry(entry);
                //};

                return entries;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpGet]
        [ActionName("GetLocations")]
        [Route("[action]")]
        public List<Location> GetLocations()
        {
            try
            {
                // Get all entries from the database
                var locations = dbContext.Locations.ToList();
                return locations;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpGet]
        [ActionName("GetSubclasses")]
        [Route("[action]")]
        public List<RecordType> GetSubclasses()
        {
            try
            {
                // Get all entries from the database
                var subclasses = dbContext.RecordTypes.ToList();
                return subclasses;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpGet]
        [ActionName("GetListContainer")]
        [Route("[action]")]
        public ListContainer GetListContainer()
        {
            try
            {
                // Get all entries from the database
                var listContainer = repository.GetListContainer();
                return listContainer;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
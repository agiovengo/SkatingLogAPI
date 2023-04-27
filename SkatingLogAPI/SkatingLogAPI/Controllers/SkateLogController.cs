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
        private SkatingLogDBContext dbContext;
        private readonly ILogger<SkateLogController> logger;
        private readonly SkateLogRepository repository;

        public SkateLogController(ILogger<SkateLogController> logger, SkatingLogDBContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;

            repository = new SkateLogRepository(dbContext);
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
                dbContext.SkatingLogEntries.Add(skatingLogEntry);
                dbContext.SaveChanges();
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
                dbContext.SkatingLogEntries.Add(repository.SampleEntry);
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        [HttpGet]
        [ActionName("GetSkatingLogEntries")]
        [Route("[action]")]
        public List<SkatingLogEntry> GetSkatingLogEntries()
        {
            try
            {
                // Get all entries from the database
                var entries = dbContext.SkatingLogEntries.ToList();
                foreach (var entry in entries)
                {
                    repository.DebugEntry(entry);
                };

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
        [ActionName("GetClassifications")]
        [Route("[action]")]
        public List<Classification> GetClassifications()
        {
            try
            {
                // Get all entries from the database
                var classifications = dbContext.Classifications.ToList();
                return classifications;
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
        public List<Subclass> GetSubclasses()
        {
            try
            {
                // Get all entries from the database
                var subclasses = dbContext.Subclasses.ToList();
                return subclasses;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
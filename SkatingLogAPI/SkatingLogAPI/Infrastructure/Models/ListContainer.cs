namespace SkatingLogAPI.Infrastructure.Models
{
    public class ListContainer
    {
        public List<RecordType> RecordTypes { get; set; } = new List<RecordType>();
        public List<Location> Locations { get; set; } = new List<Location>();
        public List<LevelState> LevelStates { get; set; } = new List<LevelState>();
    }
}

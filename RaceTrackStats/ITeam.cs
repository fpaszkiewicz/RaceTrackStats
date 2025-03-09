using static RaceTrackStats.TeamBase;

namespace RaceTrackStats
{
    interface ITeam
    {
        public string TeamName { get; }
        public string LiveryColor { get; }

        public void AddResult(string position, string driver, int number);
        public void AddDriver(DriverInMemory driver);

        public DriverInMemory BestDriver();
        public Statistics GetStatistics();

        public event DriverAddedDelegate DriverAdded;
    }
}

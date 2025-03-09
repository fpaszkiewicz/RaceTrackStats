
namespace RaceTrackStats
{
    public abstract class TeamBase : ITeam
    {
        public delegate void DriverAddedDelegate(object sender, EventArgs args);

        public abstract event DriverAddedDelegate DriverAdded;
        protected TeamBase(string teamName, string livery )
        {
            this.TeamName = teamName;
            this.LiveryColor = livery;
        }
        public string TeamName { get; private set; }

        public string LiveryColor { get; private set; }

        public abstract void AddDriver(DriverInMemory driver);

        public abstract void AddResult(string position, string driver, int number);

        public abstract Statistics GetStatistics();

        public abstract DriverInMemory BestDriver();
    }
}

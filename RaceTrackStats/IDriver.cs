using static RaceTrackStats.DriverBase;

namespace RaceTrackStats
{
    interface IDriver
    {
        public string Name { get; }
        public string LastName { get; }
        public int Number { get; }
        public void AddResult(string position);

        public void AddResult(int position);

        public event ResultAddedDelegate ResultAdded;
        public Statistics GetStatistics();
    }
}

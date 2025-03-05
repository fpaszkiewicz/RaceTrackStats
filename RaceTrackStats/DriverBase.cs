namespace RaceTrackStats
{
    public abstract class DriverBase : IDriver
    {
        public delegate void ScoreAddedDelegate(object sender, EventArgs args);

        public abstract event ScoreAddedDelegate ScoreAdded;

        public DriverBase(string name, string lastName, int number)
        {
            this.Name = name;
            this.LastName = lastName;
            this.Number = number;
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public int Number { get; private set; }

        public abstract void AddResult(string position);

        public abstract void AddResult(int position);

        public abstract Statistics GetStatistics();
    }
}

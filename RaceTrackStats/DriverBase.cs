namespace RaceTrackStats
{
    public abstract class DriverBase : IDriver
    {
        public delegate void ResultAddedDelegate(object sender, EventArgs args);

        public abstract event ResultAddedDelegate ResultAdded;

        public DriverBase(string name, int number)
        {
            this.Name = name;
            this.Number = number;
        }

        public string Name { get; private set; }
        public int Number { get; private set; }

        public abstract void AddResult(string position);

        public abstract void AddResult(int position);

        public abstract Statistics GetStatistics();
    }
}

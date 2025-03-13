namespace RaceTrackStats
{
    public class DriverInMemory : DriverBase
    {
        public DriverInMemory(string name, int number)
            : base(name, number)
        {
        }

        private List<string> results = new List<string>();

        public List<string> Results
        {
            get { return results; }
        }

        public override event ResultAddedDelegate ResultAdded;

        public override void AddResult(string position)
        {

            if (position.ToUpper() == "DNF")
            {
                //acknowledging DNF as a result although it wont be taken into account in statistics
                this.results.Add(position.ToUpper());
                ResultAdded?.Invoke(this, new EventArgs());
            }
            else
            {
                if (int.TryParse(position, out int result))
                {
                    //positions for now are limited to current f1 drivercount 
                    //TODO: change condition so it can have different values so they are dependent on grid count
                    if (result > 0 && result <= 20)
                    {
                        this.results.Add(position);
                        ResultAdded?.Invoke(this, new EventArgs());
                    }
                    else
                    {
                        throw new Exception($"This position ({position}) doesnt exist");
                    }
                }
                else
                {
                    throw new Exception($"This string ({position}) is not an integer");
                }
            }
        }

        public override void AddResult(int position)
        {
            this.AddResult(position.ToString());
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics(this.Results);

            return statistics;
        }
    }
}

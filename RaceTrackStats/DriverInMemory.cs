namespace RaceTrackStats
{
    public class DriverInMemory : DriverBase
    {
        public DriverInMemory(string name, string lastName, int number)
            : base(name, lastName, number)
        {
        }

        private List<string> results = new List<string>();

        public List<string> Results
        {
            get { return results; }
        }

        public override event ScoreAddedDelegate ScoreAdded;

        public override void AddResult(string position)
        {

            if (position.ToUpper() == "DNF")
            {
                //acknowledging DNF as a result although it wont be taken into account in statistics
                this.results.Add(position.ToUpper());
            }
            else
            {
                if (int.TryParse(position, out int result))
                {
                    //positions for now are limited to current f1 drivercount //to change
                    if (result > 0 && result <= 20)
                    {
                        this.results.Add(position);
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
            var statistics = new Statistics();

            foreach(var position in results)
            {
                if(position == "DNF")
                {
                    //ingoring DNF in statistics
                    continue;
                }
                statistics.AddPoints(int.Parse(position));
            }

            return statistics;
        }
    }
}

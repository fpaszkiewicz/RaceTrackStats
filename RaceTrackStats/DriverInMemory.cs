namespace RaceTrackStats
{
    class DriverInMemory : DriverBase
    {
        public DriverInMemory(string name, string lastName, int number)
            : base(name, lastName, number)
        {
        }

        private List<string> results = new List<string>();

        public override event ScoreAddedDelegate ScoreAdded;

        public override void AddResult(string position)
        {
            if (int.TryParse(position, out int result))
            {
                if(result > 0 && result <= 20)
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

        public override void AddResult(int position)
        {
            this.AddResult(position.ToString());
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach(var position in results)
            {
                statistics.AddPoints(int.Parse(position));
            }

            return statistics;
        }
    }
}

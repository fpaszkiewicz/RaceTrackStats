namespace RaceTrackStats
{
    public class Statistics
    {
        public int WorstResult { get; private set; }
        public int BestResult { get; private set; }
        public int Points { get; private set; }

        public int Count { get; private set; }

        public int SmallPoints { get; private set; }

        public float AvaregePoints { get
            {
                return this.Points * 1f / this.Count;
            } }

        public float AvaregePosition { get
            {
                return this.SmallPoints * 1f / this.Count; 
            } }

        public Statistics()
        {
            this.WorstResult = int.MinValue;
            this.BestResult = int.MaxValue;
            this.Points = 0;
            this.Count = 0;
            this.SmallPoints = 0;
        }

        public Statistics(List<string> results)
        {
            this.WorstResult = int.MinValue;
            this.BestResult = int.MaxValue;
            this.Points = 0;
            this.Count = 0;
            this.SmallPoints = 0;

            foreach(var result in results)
            {
                //ignoring dnf
                if (result == "DNF")
                {
                    continue;
                }
                int position = int.Parse(result);
                this.AddPoints(position);
            }
        }

        public Statistics(List<DriverInMemory> TeamDrivers)
        {
            this.WorstResult = int.MinValue;
            this.BestResult = int.MaxValue;
            this.Points = 0;
            this.Count = 0;
            this.SmallPoints = 0;

            foreach(var driver in TeamDrivers)
            {
                foreach (var result in driver.Results)
                {
                    //ignoring dnf
                    if (result == "DNF")
                    {
                        continue;
                    }
                    int position = int.Parse(result);
                    this.AddPoints(position);
                }
            }
        }

        public void AddPoints(int position, bool fastestLap = false)
        {
            this.Count++;
            this.SmallPoints += position;
            this.BestResult = Math.Min(position, BestResult);
            this.WorstResult = Math.Max(position, WorstResult);

            //adding score according to current f1 point system
            switch (position)
            {
                case 1:
                    this.Points += 25;
                    break;
                case 2:
                    this.Points += 18;
                    break;
                case 3:
                    this.Points += 15;
                    break;
                case int result when result > 3 && result < 10:
                    result -= 4;
                    this.Points += 12 - result * 2;
                    break;
                case 10:
                    this.Points += 1;
                    break;
            }
            if (fastestLap && position < 11)
            {
                this.Points += 1;
            }
        }
    }
}

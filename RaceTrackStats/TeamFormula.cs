namespace RaceTrackStats
{
    public class TeamFormula : TeamBase
    {
        public TeamFormula(string teamName, string livery) 
            : base(teamName, livery.ToLower())
        {
            
        }

        private List<DriverInMemory> teamDrivers = new List<DriverInMemory>();

        public override event DriverAddedDelegate DriverAdded;

        public List<DriverInMemory> TeamDrivers { 
            get { return teamDrivers; } 
        }
        public override void AddDriver(DriverInMemory driver)
        {
            this.teamDrivers.Add(driver);
            DriverAdded?.Invoke(this, new EventArgs());
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics(this.teamDrivers);

            return statistics;
        }

        public override void AddResult(string position, string driverFullName, int number)
        {
            foreach(var driver in teamDrivers)
            {
                //matching driver to add result
                if(driver.Number == number)
                {
                    driver.AddResult(position);
                    return;
                }
            }
            //if loop didnt find match function will create driver with given number and name to add result to
            //it may create drivers with same names but drivers during season may change teams
            //but results still needs to be recorded and saved
            string[] fullNameInArr = driverFullName.Split(' ');
            DriverInMemory newDriver = new DriverInMemory(fullNameInArr[0], fullNameInArr[1], number);
            newDriver.AddResult(position);
            this.AddDriver(newDriver);
        }

        public override DriverInMemory BestDriver()
        {
            if(teamDrivers != null)
            {
                if (teamDrivers.Count == 1)
                {
                    //if team have only one driver return this driver
                    return teamDrivers[0];
                }

                DriverInMemory bestDriver = teamDrivers[0];
                var bestStats = bestDriver.GetStatistics();
                //loop to determine best driver
                for (int i = 1; i < teamDrivers.Count; i++)
                {
                    var currentStats = teamDrivers[i].GetStatistics();

                    if (bestStats.Points < currentStats.Points)
                    {
                        bestDriver = teamDrivers[i];
                        bestStats = currentStats;
                    }
                    else if (bestStats.Points == currentStats.Points)
                    {
                        if (bestStats.SmallPoints < currentStats.SmallPoints)
                        {
                            bestDriver = teamDrivers[i];
                            bestStats = currentStats;
                        }
                        else if (bestStats.SmallPoints == currentStats.SmallPoints)
                        {
                            //if team doesnt have clear two or more best drivers it will throw an exception
                            //as we expect to return only one driver
                            throw new Exception("Two drivers (or more) have the same result");
                        }
                    }
                }
                return bestDriver;
            }
            throw new Exception($"There are no drivers in {this.TeamName} team");
        }
    }
}


namespace RaceTrackStats
{
    public class DriverInFile : DriverBase
    {
        private const string fileName = "results.txt";
        public DriverInFile(string name, string lastName, int number) : base(name, lastName, number)
        {
        }

        public override event ResultAddedDelegate ResultAdded;

        public override void AddResult(string position)
        {

            if (position.ToUpper() == "DNF")
            {
                //acknowledging DNF as a result although it wont be taken into account in statistics
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(position.ToUpper());
                    ResultAdded?.Invoke(this, new EventArgs());
                }
            }
            else
            {
                if (int.TryParse(position, out int result))
                {
                    //positions for now are limited to current f1 drivercount //to change
                    if (result > 0 && result <= 20)
                    {
                        using (var writer = File.AppendText(fileName))
                        {
                            writer.WriteLine(position);
                            ResultAdded?.Invoke(this, new EventArgs());
                        }
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
            if (File.Exists(fileName))
            {
                var statistics = new Statistics();

                using(var reader = File.OpenText(fileName))
                {
                    var line = reader.ReadLine();
                    while(line != null)
                    {
                        if (line != "DNF")
                        {
                            //ingoring DNF in statistics
                            statistics.AddPoints(int.Parse(line));
                        }
                        line = reader.ReadLine();
                    }
                }

                return statistics;
            }
            else
            {
                throw new Exception($"File not found");
            }
        }
    }
}

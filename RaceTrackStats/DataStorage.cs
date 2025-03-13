using Newtonsoft.Json;

namespace RaceTrackStats
{
    class DataStorage
    {
        private const string fileName = "RaceTrackStatsData.json"; 
        public List<TeamFormula> formulaLineUp = new List<TeamFormula>();

        //function loads saved data from file
        public void LoadData()
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                this.formulaLineUp = JsonConvert.DeserializeObject<List<TeamFormula>>(json);
            }
        }

        //function saves data into json file
        public void SaveData()
        {
            string json = JsonConvert.SerializeObject(this.formulaLineUp, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        public void AddResults(string resultsFileName)
        {
            if (File.Exists(resultsFileName))
            {
                //file formatting should look like example below
                //position;startingNumber;drivers name;teams name
                //  0           1               2           3

                using (var reader = File.OpenText(resultsFileName))
                {
                    string line = reader.ReadLine();
                    while(line != null)
                    {
                        string[] lineInArr = line.Split(";");
                        this.AddResult(lineInArr);
                        line = reader.ReadLine();
                    }
                }
            }
            else
            {
                throw new Exception($"Could not find file named: {resultsFileName}");
            }
        }

        private void AddResult(string[] lineInArr)
        {
            //unpacking array, assigning values to variables for transparency
            var position = lineInArr[0]; var number = int.Parse(lineInArr[1]); var driverName = lineInArr[2]; var teamName = lineInArr[3];
            if (this.formulaLineUp != null)
            {
                foreach (var team in this.formulaLineUp)
                {
                    if(team.TeamName == teamName)
                    {
                        //if found matching teamname adds result to that team
                        team.AddResult(position, driverName, number);
                        return;
                    }
                }
                //if didnt find a match creates new team and adds result to it
                TeamFormula newTeam = new TeamFormula(teamName);
                newTeam.AddResult(position, driverName, number);
                this.formulaLineUp.Add(newTeam);
            }
        }
    }
}

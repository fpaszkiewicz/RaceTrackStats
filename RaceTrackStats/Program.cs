// See https://aka.ms/new-console-template for more information
using RaceTrackStats;
using System.Text;
using System.Text.Json;

//Console.OutputEncoding = Encoding.UTF8; // Enable Unicode support
//Console.ForegroundColor = ConsoleColor.Red;
//Console.Write("●"); // Unicode for a solid circle
//Console.ResetColor();
//Console.WriteLine();

DriverInMemory driver = new DriverInMemory("Carlos", "Sainz", 55);
//Console.WriteLine($"Drivers name: {driver.Name} {driver.LastName} and his number is {driver.Number}");

driver.AddResult(20);
driver.AddResult(1);
driver.AddResult(4);
driver.AddResult("DNF");


Statistics stats = driver.GetStatistics();

//Console.WriteLine(stats.AvaregePoints);
Console.WriteLine(stats.AvaregePosition);
Console.WriteLine(stats.SmallPoints);
//Console.WriteLine(stats.WorstResult);
//Console.WriteLine(stats.BestResult);
//Console.WriteLine(stats.Points);
string jsonString = JsonSerializer.Serialize(driver, new JsonSerializerOptions { WriteIndented = true });
File.WriteAllText("driver.json", jsonString);
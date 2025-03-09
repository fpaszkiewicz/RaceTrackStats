using RaceTrackStats;

TeamFormula Mclaren = new TeamFormula("Mclaren", "orange");
Mclaren.AddResult("1", "Lando Noriss", 4);
Mclaren.AddResult("2", "Oscar Piastri", 81);
Mclaren.AddResult("5", "Lando Noriss", 4);
Mclaren.AddResult("3", "Oscar Piastri", 81);
Mclaren.AddResult("2", "Lando Noriss", 4);
Mclaren.AddResult("1", "Oscar Piastri", 81);
Mclaren.AddResult("3", "Lando Noriss", 4);
Mclaren.AddResult("dnf", "Oscar Piastri", 81);

var stats = Mclaren.GetStatistics();

Console.WriteLine(stats.AvaregePosition);
Console.WriteLine(stats.AvaregePoints);
Console.WriteLine(stats.BestResult);
Console.WriteLine(stats.WorstResult);

foreach(var driver in Mclaren.TeamDrivers)
{
    Console.WriteLine($"{driver.Name} {driver.LastName}");
}

var amBesten = Mclaren.BestDriver();

Console.WriteLine($"{amBesten.Name} {amBesten.LastName}");
//var response = "";
//DriverInMemory driver = new DriverInMemory("Carlos", "Sainz", 55);
//driver.ResultAdded += DriverResultAdded;

//void DriverResultAdded(object sender, EventArgs args)
//{
//    Console.WriteLine("Dodano wynik.");
//}

//Console.WriteLine("Witaj w programie do analizy wyników kierowców");
//Console.WriteLine("==============================================");
//Console.WriteLine();

//while (true)
//{
//    Console.WriteLine("Wprowadz wynik, lub wybierz 'Q' aby przejść do podsumowania");
//    response = Console.ReadLine();
//    if(response == "q" || response == "Q")
//    {
//        break;
//    }
//    try
//    {
//        driver.AddResult(response);
//    }
//    catch(Exception exc)
//    {
//        Console.WriteLine();
//        Console.WriteLine(exc.Message);
//    }

//    Console.WriteLine();
//}

//Console.Clear();
//Console.WriteLine($"Podsumowanie dla kierowcy {driver.Name} {driver.LastName} {driver.Number}");
//Console.WriteLine("=========================================");
//Console.WriteLine();

//Statistics result;
//try
//{
//    result = driver.GetStatistics();

//    Console.WriteLine($"Punkty: {result.Points}");
//    Console.WriteLine($"Średnie zdobywane Punkty: {string.Format("{0:F2}", result.AvaregePoints)}");
//    Console.WriteLine($"Średnie pozycja: {string.Format("{0:F2}", result.AvaregePosition)}");
//}
//catch(Exception exc)
//{
//    Console.WriteLine();
//    Console.WriteLine(exc.Message);
//}
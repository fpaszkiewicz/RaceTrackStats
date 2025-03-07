using RaceTrackStats;

var response = "";
DriverInFile driver = new DriverInFile("Carlos", "Sainz", 55);
driver.ResultAdded += DriverResultAdded;

void DriverResultAdded(object sender, EventArgs args)
{
    Console.WriteLine("Dodano wynik.");
}

Console.WriteLine("Witaj w programie do analizy wyników kierowców");
Console.WriteLine("==============================================");
Console.WriteLine();

while (true)
{
    Console.WriteLine("Wprowadz wynik, lub wybierz 'Q' aby przejść do podsumowania");
    response = Console.ReadLine();
    if(response == "q" || response == "Q")
    {
        break;
    }
    try
    {
        driver.AddResult(response);
    }
    catch(Exception exc)
    {
        Console.WriteLine();
        Console.WriteLine(exc.Message);
    }

    Console.WriteLine();
}

Console.Clear();
Console.WriteLine($"Podsumowanie dla kierowcy {driver.Name} {driver.LastName} {driver.Number}");
Console.WriteLine("=========================================");
Console.WriteLine();

Statistics result;
try
{
    result = driver.GetStatistics();

    Console.WriteLine($"Punkty: {result.Points}");
    Console.WriteLine($"Średnie zdobywane Punkty: {string.Format("{0:F2}", result.AvaregePoints)}");
    Console.WriteLine($"Średnie pozycja: {string.Format("{0:F2}", result.AvaregePosition)}");
}
catch(Exception exc)
{
    Console.WriteLine();
    Console.WriteLine(exc.Message);
}
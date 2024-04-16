using System.Data.Common;
using TryCatchApp.DataAccess;
using static System.Runtime.InteropServices.JavaScript.JSType;

CSVfile db = new CSVfile();
string[] lines = db.Get();

List<string> GoodMovies = new List<string>();
List<string> BadMovies = new List<string>();
List<string> UnreadableMovies = new List<string>();

for (int i = 1; i < lines.Length; i++)
{
    string line = lines[i];
    try
    {
        string[] columns = line.Split(';');
        double VoteAverage = double.Parse(columns[2]);
        string OriginalLanguage = columns[4];

        //Tjek om voteaverage er højere end 7 for at afgøre om filmen skal indgå i GoodMovies eller BadMovies
        //Kun have engelske film ind under GoodMovies
        if (columns.Length == 5)
        {
            if (VoteAverage > 7 && OriginalLanguage == "en")
            {
                GoodMovies.Add(line);
            }
            else
            {
                BadMovies.Add(line);
            }
        }
    }
    catch (Exception ex)
    {
        UnreadableMovies.Add(line);
        Console.WriteLine($"Ugyldig dataform i linje: {line} {ex.Message}");
    }
}

//Udskriv GoodMovies til ny CSV fil
string outputFilePath = "c:\\csv\\GoodMovies.csv";
File.WriteAllLines(outputFilePath, GoodMovies);

//Udskriv BadMovies til ny CSV fil
string outputFilePath2 = "c:\\csv\\BadMovies.csv";
File.WriteAllLines(outputFilePath2, BadMovies);

//Udskriv ugyldige film til ny CSV fil
string outputFilePath3 = "c:\\csv\\UnreadableMovies.csv";
File.WriteAllLines(outputFilePath3, UnreadableMovies);

//Udskriv GoodMovies samt informationer i konsol
Console.WriteLine("Good movies (rating > 7 ");
foreach (string movie in GoodMovies)
{
    string[] columns = movie.Split(";");
    Console.WriteLine($"Title: {columns[0]}");
    Console.WriteLine($"Overview: {columns[1]}");
    Console.WriteLine($"Rating: {columns[2]}");
    Console.WriteLine($"Release Date: {columns[3]}");
    Console.WriteLine($"Language: {columns[4]}");
    Console.WriteLine();
}

//Udskriv antallet af film der blev udskrevet før
Console.WriteLine($"Antal gode film udskrevet: {GoodMovies.Count}");
Console.WriteLine($"Antal unreadable film udskrevet: {UnreadableMovies.Count}");
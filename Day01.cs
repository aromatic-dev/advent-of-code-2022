var input = await File.ReadAllLinesAsync(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Input\Day01.txt"));

var elfCalories = 0;
var allElfCalories = new List<int>();

var foodItems = input.Split(Environment.NewLine);
foreach (var food in foodItems)
{
    if (int.TryParse(food, out var currentCalories))
    {
        elfCalories += currentCalories;
    }
    else
    {
        allElfCalories.Add(elfCalories);
        elfCalories = 0;
    }
}

allElfCalories.Sort();

Console.WriteLine($"#1 total calories: {allElfCalories.ElementAt(allElfCalories.Count - 1)}");
Console.WriteLine($"Top three elves total calories: {allElfCalories.ElementAt(allElfCalories.Count - 1) + allElfCalories.ElementAt(allElfCalories.Count - 2) + allElfCalories.ElementAt(allElfCalories.Count - 3)}");
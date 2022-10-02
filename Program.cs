Console.WriteLine("Pairs of integers (Sample input: 1,9,5,0,20,-4,12,16,7 12)");

var result = Function.FindPairsOfIntegers(Console.ReadLine());
foreach (var item in result) Console.WriteLine(item);

Console.WriteLine("Press enter to exit!");
Console.ReadLine();

public static class Function
{
    public static IEnumerable<string> FindPairsOfIntegers(string input)
    {
        var line = input.Split(" ");
        var list = new List<int>(line[0].Split(",").Select(x => int.Parse(x)));
        var target = int.Parse(line[1]);

        var map = new Dictionary<int, bool>(list.Select(x => new KeyValuePair<int, bool>(x, true)));
        foreach (var value in list)
        {
            var targetValue = target - value;
            if (map[value] && map.GetValueOrDefault(targetValue))
            {
                map[targetValue] = false;
                yield return $"{value},{targetValue}";
            }
        }
    }
}


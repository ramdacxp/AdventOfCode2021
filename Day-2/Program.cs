
var h = 0;
var d = 0;

var input = File.ReadAllLines("input.txt");
foreach (var line in input)
{
    var splitted = line.Split(' ');
    var amount = Convert.ToInt32(splitted[1]);
    switch (splitted[0])
    {
        case "up": d -= amount; break;
        case "down": d += amount; break;
        case "forward": h += amount; break;
    }
}

Console.WriteLine($"Horizontal Position: {h}");
Console.WriteLine($"Depth: {d}");
Console.WriteLine($"Sum: {h * d}");

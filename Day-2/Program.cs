
var h = 0;
var d = 0;
var a = 0;

var input = File.ReadAllLines("input.txt");
foreach (var line in input)
{
    var splitted = line.Split(' ');
    var amount = Convert.ToInt32(splitted[1]);
    switch (splitted[0])
    {
        case "up":
            a -= amount;
            break;
        case "down":
            a += amount;
            break;
        case "forward":
            h += amount;
            d += (a * amount);
            break;
    }
}

Console.WriteLine($"Horizontal Position: {h}");
Console.WriteLine($"Depth: {d}");
Console.WriteLine($"Sum: {h * d}");

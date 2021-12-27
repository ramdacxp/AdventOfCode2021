
int GetWindow(string[] input, int idx)
{
    var sum = 0;
    for (var i = 0; i < 3; i++)
    {
        sum += Convert.ToInt32(input[idx + i]);
    }
    return sum;
}


var input = File.ReadAllLines("input.txt");
var increased = 0;
var windowIncreased = 0;

for (int line = 1; line < input.Length; line++)
{
    var prev = Convert.ToInt32(input[line - 1]);
    var current = Convert.ToInt32(input[line]);
    if (current > prev) increased++;

    // part 2: sum 3 values
    if (line > 2)
    {
        var w1 = GetWindow(input, line - 3);
        var w2 = GetWindow(input, line - 2);
        if (w2 > w1) windowIncreased++;
    }
}

Console.WriteLine($"Zeilen: {input.Length}");
Console.WriteLine($"Zeilen größer als Vorgänger: {increased}");
Console.WriteLine($"3er Blöcke größer als Vorgänger: {windowIncreased}");

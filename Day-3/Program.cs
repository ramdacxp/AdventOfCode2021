void DumpArray(int[] input)
{
    for (var i = 0; i < input.Length; i++)
    {
        Console.Write(input[i]);
        if (i < input.Length - 1) Console.Write(":");
    }
}


var input = File.ReadAllLines("input.txt");

var num0 = new int[12];
var num1 = new int[12];

foreach (var line in input)
{
    for (var pos = 0; pos < line.Length; pos++)
    {
        if (line[pos] == '1')
            num1[pos]++;
        else
            num0[pos]++;
    }

    Console.Write($"{line}: ");
    DumpArray(num0);
    Console.Write("  ");
    DumpArray(num1);
    Console.WriteLine();
}

var gamma = "";
var epsilon = "";
for (var digit = 0; digit < num0.Length; digit++)
{
    gamma += (num1[digit] > num0[digit]) ? '1' : '0';
    epsilon += (num1[digit] > num0[digit]) ? '0' : '1';

}

var g = Convert.ToInt32(gamma, 2);
var e = Convert.ToInt32(epsilon, 2);

Console.WriteLine($"Gamme Rate: {gamma}: {g}");
Console.WriteLine($"Epsilon Rate: {epsilon}: {e}");
Console.WriteLine($"Power consumption: {g * e}");

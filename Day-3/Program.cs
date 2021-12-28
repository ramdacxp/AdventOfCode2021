void DumpCounter(int[] input)
{
    for (var i = 0; i < input.Length; i++)
    {
        Console.Write(input[i]);
        if (i < input.Length - 1) Console.Write(":");
    }
}

string CalcBits(string[] input, bool mostCommon)
{
    var num0 = new int[12];
    var num1 = new int[12];

    foreach (var line in input)
    {
        for (var pos = 0; pos < line.Length; pos++)
        {
            if (line[pos] == '1') num1[pos]++; else num0[pos]++;
        }
    }

    var result = "";
    for (var digit = 0; digit < num0.Length; digit++)
    {
        if (mostCommon)
            result += (num1[digit] >= num0[digit]) ? '1' : '0';
        else
            result += (num1[digit] >= num0[digit]) ? '0' : '1';
    }

    return result;
}

// PART 1

var input = File.ReadAllLines("input.txt");
var gammaStr = CalcBits(input, true);
var epsilonStr = CalcBits(input, false);

var gamma = Convert.ToInt32(gammaStr, 2);
var epsilon = Convert.ToInt32(epsilonStr, 2);

Console.WriteLine($"Gamme Rate: {gammaStr}: {gamma}");
Console.WriteLine($"Epsilon Rate: {epsilonStr}: {epsilon}");
Console.WriteLine($"Power consumption: {gamma * epsilon}");

// PART 2

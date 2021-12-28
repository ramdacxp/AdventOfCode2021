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

string Filter(string[] input, int position, bool mostCommon)
{
    Console.WriteLine($"Filtering {input.Length} items on pos {position} ...");
    var bits = CalcBits(input, mostCommon);
    Console.WriteLine($"- Using bitmask {bits} and filter {bits[position]}");

    var filtered = input.Where(line => line[position] == bits[position]).ToList();
    Console.WriteLine($"- Found {filtered.Count} items");
    if (filtered.Count == 1)
    {
        Console.WriteLine($"- Result is {filtered[0]}");
        return filtered[0];
    }

    return Filter(filtered.ToArray(), position + 1, mostCommon);
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
var oxyStr = Filter(input, 0, true);
var oxy = Convert.ToInt32(oxyStr, 2);

var co2Str = Filter(input, 0, false);
var co2 = Convert.ToInt32(co2Str, 2);

Console.WriteLine($"Oxygen generator rating: {oxyStr}: {oxy}");
Console.WriteLine($"CO2 scrubber rating: {co2Str}: {co2}");
Console.WriteLine($"LIfe support rating: {oxy * co2}");


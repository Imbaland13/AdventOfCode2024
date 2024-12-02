
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

string location = "C:\\Users\\danny\\Documents\\adventofcode1.txt";
string locationAoc2 = "C:\\Users\\danny\\Documents\\aoc2.txt";
FileStream fileAoc2 = new FileStream(locationAoc2, FileMode.Open);
StreamReader reader = new(location);


static void AdventOfCode1(StreamReader reader)
{
    int numberA = 0;
    int numberB = 0;
    string data = "";
    string data1 = "";
    
    List <int> columnA = [];
    List <int> columnB = [];

    while (!reader.EndOfStream )
    {
        {
            data = reader.ReadToEnd();
        }
    }

    data1 = data.Replace("\n", " ");
    string[] dataSplit = data1.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

    for (int i = 1; i <= dataSplit.Length; i++)
    {
        if (i % 2 == 1)
        {
            numberA = Convert.ToInt32(dataSplit[i - 1]);
            columnA.Add(numberA);
        }
        else
        {
            numberB = Convert.ToInt32(dataSplit[i - 1]);
            columnB.Add(numberB);
        }
    }
    int columnAcurrent = 0;
    int columnBcurrent = 0;
    columnA.Sort();
    columnB.Sort();
    for(int i = 0; i < columnA.Count; i++)
    {
            Console.WriteLine(columnA[i] + " " + columnB[i]);
    }
    int sum = 0;
    int number = 0;
    for (int i = 0; i < columnA.Count; i++)
    {
        columnBcurrent = columnB[i];
        columnAcurrent = columnA[i];
        number = columnB[i] - columnA[i];
        if (number < 0) { number *= -1; }
        sum += number;
    }
    Console.WriteLine("Result " + sum);
    //TEST
    //int testsum = 0;
    //int testAcurrent = 0;
    //int testBcurrent = 0;
    //List<int> testA = [3, 4, 2, 1, 3, 3, 5];
    //List<int> testB = [4, 3, 5, 3, 9, 3];
    //testA.Sort();
    //testB.Sort();
    //for (int i = 0; i < testA.Count; i++)
    //{
    //    if (i <= testB.Count - 1)
    //    {
    //        testAcurrent = testA[i];
    //        testBcurrent = testB[i];
    //        testsum += testBcurrent - testAcurrent;
    //    }
    //    else
    //    {
    //        testAcurrent = testA[i];
    //        testsum += testBcurrent - testAcurrent;
    //    }
    //}
    //Console.WriteLine("Result " + testsum);
}

static void AdventOfCode2(FileStream fs)
{
    StreamReader sr = new StreamReader(fs);
    List<string> lines = [];
    bool isSafe = false;
    int counter = 0;
    for (int i = 0; i < fs.Length; i++) 
    {
        string s = sr.ReadLine();
        if (s != null) 
        {
            lines.Add(s);
        }
    }
    //foreach (string line in lines) 
    //{
    //    numbers.Add([line]);
    //}
    //for (int i = 0; i < lines.Count; i++)
    //{
    //    string line = lines[i];
    //    //List<int> numbers = new List<int>();
    //    string[] numbersAsString = line.Split(" ");
    //    int[] numbers = Array.ConvertAll(numbersAsString, int.Parse);
    //    isSafe = IsAoc2Safe(numbers);
    //    foreach(int l in numbers) Console.Write(l + " ");
    //    Console.WriteLine();
    //    if (isSafe) { counter++ ; }
    //}
    //TESTDATA
    bool isSafeTest = false;
    int counterTest = 0;
    int[] numbers1 = [7, 6, 4, 2, 1];
    int[] numbers2 = [1, 2, 7, 8, 9];
    int[] numbers3 = [9, 7, 6, 2, 1];
    int[] numbers4 = [1, 3, 2, 4, 5];
    int[] numbers5 = [8, 6, 4, 4, 1];
    int[] numbers6 = [1, 3, 6, 7, 9];
    int[][] ArrayOfNumbers = [numbers1, numbers2, numbers3, numbers4, numbers5,numbers6];

    //List<int> numbers = new List<int>();
    foreach (var item in ArrayOfNumbers)
    {
        isSafeTest = IsAoc2SafeTest(item);
    }
    isSafeTest = IsAoc2SafeTest(ArrayOfNumbers);
    if (isSafeTest) { counterTest++; }
    Console.WriteLine(counterTest);
    }
    
static bool IsAoc2Safe(int[] numbers)
{
    int counter = 0;
    for (int i = 0; i < numbers.Length; i++)
    {
    if (numbers[i] < numbers[i + 1])
    {
        counter++;
        if (counter == numbers.Length - 1)
        {
            return true;
        }
    }
    else if (numbers[i]< numbers[i + 1])
    {
        counter++;
        if (counter == numbers.Length - 1)
        {
            return true;
        }
    }
    else return false;
    }
    return false;
}
static bool IsAoc2SafeTest(int[][] numbersArray)
{
    for (int i = 0; i < numbersArray.Length; i++)
    {
        int counter = 0;
        int [] numbers = numbersArray[i];
        for (int k = 0; k < numbers.Length - 1; k++)
        {
            if (numbers[k] < numbers[k + 1])
            {
                counter++;
                if (counter == numbers.Length - 1)
                {
                    return true;
                }
            }
            else if (numbers[k] < numbers[k + 1])
            {
                counter++;
                if (counter == numbers.Length - 1)
                {
                    return true;
                }
            }
            else return false;
        }
        return false;
    }
    return false;
}
AdventOfCode2(fileAoc2);

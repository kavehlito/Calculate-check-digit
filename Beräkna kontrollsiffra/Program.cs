bool inputCheck = false;

while (inputCheck == false)
{

    Console.WriteLine("\nSkriv in dom första nio siffrorna i ditt personnummer...");
    string userInput = Console.ReadLine();
    long SSN; //Social Security Number

    bool correctInput = long.TryParse(userInput, out SSN);

    if (correctInput == false || SSN.ToString().Length != 9)
    {
        Console.WriteLine("Fel inmatning");
    }
    else
    {
        inputCheck = true;
        List<long> ssnNumbers = new List<long>();
        ssnNumbers = SSN.ToString().Select(digits => long.Parse(digits.ToString())).ToList();

        Console.WriteLine("\nKorrekt inmatning\n");
        for (int i = 0; i < ssnNumbers.Count; i++)
        {
            ssnNumbers[i] = ssnNumbers[i] * 2;
            i++;
        }

        for (int i = 0; i < ssnNumbers.Count; i++)
        {
            long sum = 0;
            if (ssnNumbers[i].ToString().Length > 1)
            {
                sum = ssnNumbers[i].ToString().ToList().Sum(x => long.Parse(x.ToString()));
                ssnNumbers[i] = sum;
            }
        }

        var listSum = ssnNumbers.Sum();
        var roundUpNumber = listSum;
        while (roundUpNumber % 10 != 0)
        {
            roundUpNumber++;
        }

        var lastDigit = roundUpNumber - listSum;
        var finalSSN = SSN.ToString() + lastDigit.ToString();

        Console.WriteLine($"Den sista siffran i ditt personnummer är {lastDigit}, vilket innebär att ditt personnummer är {finalSSN}");
    }
}
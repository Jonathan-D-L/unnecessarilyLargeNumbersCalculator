namespace unnecessarilyLargeNumbersCalculator;

public class CalculatorApp
{
    public void AddLargerPositiveNumbers()
    {
        //no error handling, enter ur ridiculous numbers here to add them!
        var largeNum1 = "33333";
        var largeNum2 = "9999999999";

        var charArray1 = largeNum1.ToArray();
        var charArray2 = largeNum2.ToArray();
        var result = new List<int>();
        var leftover = 0;
        var numArray1 = charArray1.Select(c => Convert.ToInt32(c - '0')).ToList();
        var numArray2 = charArray2.Select(c => Convert.ToInt32(c - '0')).ToList();
        numArray1.Reverse();
        numArray2.Reverse();
        if (numArray1.Count > numArray2.Count)
        {
            leftover = numArray1.Count - numArray2.Count;
            for (var i = 0; i < leftover; i++)
            {
                numArray2.Add(0);
            }
        }
        if (numArray1.Count < numArray2.Count)
        {
            leftover = numArray2.Count - numArray1.Count;
            for (var i = 0; i < leftover; i++)
            {
                numArray1.Add(0);
            }
        }
        var runFor = numArray1.Count > numArray2.Count ? numArray1.Count : numArray2.Count;
        var productOfSum = 0;
        for (var i = 0; i < runFor; i++)
        {
            var sum = numArray1[i] + numArray2[i] + productOfSum;
            productOfSum = 0;
            if (i + 1 == runFor)
            {
                result.Add(sum);
                break;
            }
            if (sum > 9)
            {
                var sumAndProduct = sum.ToString().ToArray();
                productOfSum = sumAndProduct[0] - '0';
                result.Add(sumAndProduct[1] - '0');
            }
            else
            {
                result.Add(sum);
            }
        }
        result.Reverse();
        var resultString = result.Aggregate("", (current, num) => current + num);
        Console.WriteLine(resultString);
    }
}
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'maxSubarray' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static List<int> maxSubarray(List<int> arr)
    {
        if (arr == null || arr.Count == 0)
        return new List<int> { 0, 0 };
    
    // Handle case where all elements are negative
    int maxElement = arr.Max();
    if (maxElement <= 0)
    {
        return new List<int> { maxElement, maxElement };
    }
    
    // Kadane's algorithm for maximum subarray (contiguous)
    int maxCurrent = arr[0];
    int maxGlobal = arr[0];
    
    for (int i = 1; i < arr.Count; i++)
    {
        maxCurrent = Math.Max(arr[i], maxCurrent + arr[i]);
        maxGlobal = Math.Max(maxGlobal, maxCurrent);
    }
    
    // Maximum subsequence (non-contiguous) - sum of all positive elements
    int maxSubsequenceSum = arr.Where(x => x > 0).Sum();
    
    // If all elements are negative, this sum would be 0, but we already handled that case
    // So we're safe to use the sum of positives
    
    return new List<int> { maxGlobal, maxSubsequenceSum };

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            List<int> result = Result.maxSubarray(arr);

            textWriter.WriteLine(String.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
    }
}

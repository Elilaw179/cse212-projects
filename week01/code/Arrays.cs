 using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive integer > 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create an array with size equal to 'length'.
        // 2. Loop from 0 to length - 1.
        // 3. For each position i, calculate the multiple: number * (i + 1).
        // 4. Store the result in the array.
        // 5. Return the array.

        double[] result = new double[length]; // Step 1: create the array

        for (int i = 0; i < length; i++) // Step 2: loop through positions
        {
            result[i] = number * (i + 1); // Step 3 & 4: calculate and store
        }

        return result; // Step 5: return the array
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Identify the last 'amount' elements of the list.
        // 2. Extract them using GetRange.
        // 3. Remove them from the original list.
        // 4. Insert them at the beginning using InsertRange.
        // 5. The list is now rotated right.

        int startIndex = data.Count - amount;                // Step 1: starting index of the part to move
        List<int> endPart = data.GetRange(startIndex, amount); // Step 2: extract last 'amount' elements
        data.RemoveRange(startIndex, amount);               // Step 3: remove them from the end
        data.InsertRange(0, endPart);                       // Step 4: insert at beginning
    }
}
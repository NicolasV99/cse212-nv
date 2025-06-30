public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}. Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create a new array of doubles with the specified 'length'.
        // 2. Iterate from 0 up to (but not including) 'length'.
        // 3. In each iteration, calculate the next multiple of 'number'.
        //    - For the first element (index 0), the value will be 'number' * 1.
        //    - For the second element (index 1), the value will be 'number' * 2.
        //    - And so on...
        // 4. Assign the calculated multiple to the corresponding index in the array.
        // 5. After the loop finishes, return the created array.

        // Implementation:
        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}. The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan using list slicing and manipulation:
        // 1. Get the elements that will be moved to the front of the list. These are the last 'amount' elements.
        //    - Use GetRange to extract these elements into a new temporary list.
        // 2. Remove these last 'amount' elements from the original 'data' list.
        //    - Use RemoveRange. Be careful with the starting index and the count.
        // 3. Insert the temporary list (containing the moved elements) at the beginning of the original 'data' list.
        //    - Use InsertRange at index 0.

        // Implementation:
        if (data == null || data.Count == 0 || amount <= 0)
        {
            return; // Nothing to rotate or invalid amount
        }

        int n = data.Count;
        amount = amount % n; // Handle cases where amount > n

        if (amount == 0)
        {
            return; // No rotation needed
        }

        // 1. Get the last 'amount' elements.
        List<int> elementsToMove = data.GetRange(n - amount, amount);

        // 2. Remove these elements from the end.
        data.RemoveRange(n - amount, amount);

        // 3. Insert these elements at the beginning.
        data.InsertRange(0, elementsToMove);
    }
}
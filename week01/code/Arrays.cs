public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        
        //We need to create a new array from length, after we need to iterate from 0
        //for calculate the next numbers, next we assign the numbers to a index in 
        //the array and finally we return the arrey.

        //Create a new array for doubles
        double[] result = new double[length];
        //Iterate to populate the array with multiples.
        for (int i = 0; i < length; i++){
            //Calculate the multiple, number * 1, number * 2, etc...
            result[i] = number * (i + 1);
        }

        return result; // Return the array
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //We will use list slicing and manipulation
        //We get the elements that willbe moved to the front of the list(last items from amount)
        //Next we extract these element into a new temporaly list, next we remove
        //the last amount items from the original data. Finally we insert the temporaly
        //list at the beginning of the original data.

        if (data == null || data.Count == 0 || amount <= 0 ){
            return;
        } 
        int n = data.Count;
        amount = amount % n; //where amount > n

        if (amount == 0){
            return;
        }

        //Get the last 'amount' elements.
        List<int> elementsToMove = data.GetRange(n - amount, amount);
        //Remove these elements from the end
        data.RemoveRange(n - amount, amount);  
        //Insert these elements at the beginning.
        data.InsertRange(0, elementsToMove);

    }
}

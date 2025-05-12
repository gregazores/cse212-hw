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

        //create an array with type double provided with the length
        double[] array = new double[length];

        //within the for loop calculate each multiple of the number by number + number*i
        for(int i = 0; i < length; i++) 
        {
            array[i] = number + number*i;
            //write the current iteration in the console to check
            Console.WriteLine(array[i]);
        }

        return array; // replace this return statement with your own
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
        
        //Use the GetRange() method to get the range of elements (slice starting from data.Count - amount with count number of elements)
        List<int> lastEntries = data.GetRange(data.Count - amount, amount);
        // Use the GetRange() method to get the range of elements (slice from the Start(0) with data.Count - amount number of elements)
        List<int> firstEntries = data.GetRange(0, data.Count - amount); 

        // clear the original list
        data.Clear();

        // add the sliced parts
        data.AddRange(lastEntries);
        data.AddRange(firstEntries);

    }
}

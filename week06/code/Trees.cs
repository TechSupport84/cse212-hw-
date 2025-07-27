public static class Trees
{
    /// <summary>
    /// Given a sorted list (sorted_list), create a balanced BST.  
    /// </summary>
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree(); // Create an empty BST to start with 
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    /// <summary>
    /// Insert the middle element of the sortedNumbers[first..last] into bst,
    /// then recursively insert middles of left and right sublists.
    /// </summary>
    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        if (first > last)
        {
            // Base case: no elements in this sublist
            return;
        }

        // Find middle index
        int mid = (first + last) / 2;

        // Insert middle element into BST
        bst.Insert(sortedNumbers[mid]);

        // Recursively insert middle of left sublist
        InsertMiddle(sortedNumbers, first, mid - 1, bst);

        // Recursively insert middle of right sublist
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}

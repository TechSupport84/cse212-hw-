public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Problem 1: Insert Unique Values Only
        if (value == Data)
        {
            // Value already exists, do not insert duplicates
            return;
        }
        else if (value < Data)
        {
            // Insert to the left
            if (Left == null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else // value > Data
        {
            // Insert to the right
            if (Right == null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // Problem 2: Contains
        if (value == Data)
        {
            return true;
        }
        else if (value < Data)
        {
            if (Left == null)
                return false;
            else
                return Left.Contains(value);
        }
        else // value > Data
        {
            if (Right == null)
                return false;
            else
                return Right.Contains(value);
        }
    }

    public int GetHeight()
    {
        // Problem 4: GetHeight recursively
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        return 1 + (leftHeight > rightHeight ? leftHeight : rightHeight);
    }
}

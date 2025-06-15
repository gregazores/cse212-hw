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
        // TODO Start Problem 1


        if (value < Data)
        {

            // Insert to the left
            // since this current node's left prop is empty
            // let us create a new instance of node and make it 
            // left property of this current node
            if (Left is null)
                Left = new Node(value);
            // so the left property of this current node is not empty
            // let us go inside this current node's Left property and call 
            // it's insert method to see if it is empty or not
            // and then do the same thing for each case empty or not
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
        
        // No 'else' case: if value == Data, we do nothing
    }

    // To implement the Contains method in the Node class using recursion
    // Follow the same pattern as the Insert method
    // compare the value to the current node's Data and decide to go left or right.
    // If the value matches the current node’s data, return true. If it's less, search the left subtree.
    // If it's greater, search the right subtree. 
    // If there’s no node to go to (i.e., Left or Right is null), return false.

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        if (value == Data)
        {
            return true;
        }
        else if (value < Data)
        {
            // Go left
            return Left != null && Left.Contains(value);
        }
        else // value > Data
        {
            // Go right
            return Right != null && Right.Contains(value);
        }
    }

    // To implement the GetHeight method in the Node class, 
    // you can use recursion to calculate the height of both the left and right subtrees. 
    // Then, return 1 + the maximum of those two heights.
    public int GetHeight()
    {
        // TODO Start Problem 4
        int leftHeight = Left != null ? Left.GetHeight() : 0;
        int rightHeight = Right != null ? Right.GetHeight() : 0;
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
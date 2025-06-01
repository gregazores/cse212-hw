// DO NOT MODIFY THIS FILE
public class Node
{
    // defining the properties on this part
    // public means this property can be accessed or modified from outside the class.
    // { get; set; } means the value can be read (get) and changed (set).
    public int Data { get; set; }
    public Node? Next { get; set; }
    public Node? Prev { get; set; }

    // this part is the constructor
    // a special method that's called when you create a new Node.
    public Node(int data)
    {
        this.Data = data;
    }
}
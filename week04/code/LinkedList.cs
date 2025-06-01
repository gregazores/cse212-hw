using System.Collections;

public class LinkedList : IEnumerable<int>
{
    //The ? makes the type nullable — meaning it can either be a Node or null.
    // private means only this class can see or use this variable.
    // Other classes or objects can’t access _head directly.
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        // This is a shortcut syntax introduced in C# 9.0 and later.
        // It’s equivalent to the more traditional version:
        // Node newNode = new Node(value);

        Node newNode = new(value);

        // by the way this can also be done
        // Node newNode = new Node(); (no value passed) 
        // newNode.Data = value;  (given the Data property is public)

        // Here's why new(value) is preferred
        // Encapsulation / Object Integrity
        // More Maintainable

        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            // note that In C#, classes are reference types. That means when you do: node1.Next = node2;
            // You're not copying the whole node2 object — you're just storing a reference (pointer) to it.
            // That’s perfect for a linked list because:
            // 1) You want each node to link to the next.
            // 2) You don’t want to copy data — just refer to the next node.

            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // TODO Problem 1

        // getting inspiration from InsertHead

        // create a new node
        Node newNode = new(value);

        // If the list is empty, then point both head and tail to the new node.
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
            else
        {
            // note that In C#, classes are reference types. That means when you do: node1.Next = node2;
            // You're not copying the whole node2 object — you're just storing a reference (pointer) to it.
            // That’s perfect for a linked list because:
            // 1) You want each node to link to the next.
            // 2) You don’t want to copy data — just refer to the next node.

            newNode.Prev = _tail; // Connect new node to the previous head
            _tail.Next = newNode; // Connect the previous head to the new node
            _tail = newNode; // Update the head to point to the new node
        }
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null) // and assuming that the list has more than 1 item
        {
            // Note: below can be compact but hard to read
            // but basically you are accesing the node after the head and then set the valie .prev to null
            // note that the ! is a null-forgiving operator It tells the compiler: "I know _head.Next is not null, so stop warning me."
            // so to silence that warning (without adding a null check), the developer adds !
            //But the line will still crash at runtime if _head.Next is null — for example, if:
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            // in reference to above you could do Node nextNode = _head.Next; 
            // and then nextNode.Prev = null;
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // TODO Problem 2

        // inspired by the prev problem
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_tail is not null)
        {
            _tail.Prev!.Next = null; // make second to the last node tail and change the next property to null
            _tail = _tail.Prev;
        }

    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        // It means that curr is a variable of type Node, but it is allowed to be null.
        // This is called a nullable reference type in C# 8.0 and later.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // TODO Problem 3

        // as usual start from the head of the list
        Node? current = _head;

        // Keep looping as long as there's a node to look at.
        // because if we loop in the tail the current.Next will be null
        while (current != null)
        {
            // when we have found the first node that matches 'value' by starting at the head
            if (current.Data == value)
            {
                // Case 1: Node is the head
                if (current == _head)
                {
                    // _head = current.Next;
                    // if (_head != null)
                    //     _head.Prev = null;
                    // else
                    //     _tail = null; // list became empty
                    RemoveHead(); // simply call the RemoveHead method
                }
                // Case 2: Node is the tail
                else if (current == _tail)
                {
                    // _tail = current.Prev;
                    // if (_tail != null)
                    //     _tail.Next = null;
                    RemoveTail(); // simply call the RemoveTail method
                }
                // Case 3: Node is in the middle
                else
                {
                    // just change the pointer accordingly
                    current.Prev!.Next = current.Next;
                    current.Next!.Prev = current.Prev;
                }

                return; // Exit after removing the first match
            }

            current = current.Next;
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4

        // as usual start from the head
        Node? current = _head;

        // while there is still a node
        // remember if we have reached the tail then the current.next will be null
        while (current != null)
        {
            // when we have found the first Node having the oldValue
            if (current.Data == oldValue)
            {
                // since the Data of each Node is public we can just change the data
                // and keep the rest of the Node as is
                current.Data = newValue;
            }

            current = current.Next;
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator() // This line is part of enabling LinkedList to be used in a foreach loop.
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // TODO Problem 5
        //yield return 0; // replace this line with the correct yield return statement(s)

        // this time we are starting from the tail and move back (notice current = current.Prev;)
        Node? current = _tail;

        while (current != null)
        {
            yield return current.Data;
            current = current.Prev;
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
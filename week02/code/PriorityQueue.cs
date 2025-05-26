public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);

        // Ensure stable priority order (sorting by highest priority first)
        //_queue = _queue.OrderByDescending(item => item.Priority).ToList();
    }

    public string Dequeue()
    {
        if (_queue.Count == 0) // Verify the queue is not empty
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Find the index of the item with the highest priority to remove
        var highPriorityIndex = 0;
        // for some reason, index stops before the last item index < _queue.Count - 1
        // itn should iterate through the entire list index < _queue.Count
        for (int index = 1; index < _queue.Count; index++) // Fix the loop condition
        {
            // old code
            // if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            //     highPriorityIndex = index;

            // the fix

            if (_queue[index].Priority > _queue[highPriorityIndex].Priority ||
                (_queue[index].Priority == _queue[highPriorityIndex].Priority && index < highPriorityIndex))
            {
                highPriorityIndex = index;
            }
        }

        // Remove and return the item with the highest priority
        var value = _queue[highPriorityIndex].Value;
        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}
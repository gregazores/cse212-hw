/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{

    //observation, this assignment is using List<T> instead of Queue<T>
    // probably since List allows more flexible access to the elements
    // unline Queue which is is a strict FIFO (First-In, First-Out) structure
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        _queue.Add(person);
    }

    public Person Dequeue()
    {
        var person = _queue[0];
        _queue.RemoveAt(0);
        return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}
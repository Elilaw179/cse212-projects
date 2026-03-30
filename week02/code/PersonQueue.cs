
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    public void Enqueue(Person person)
    {
        _queue.Add(person); // add to BACK
    }

    public Person Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var person = _queue[0];   // remove from FRONT
        _queue.RemoveAt(0);

        return person;
    }

    public bool IsEmpty()
    {
        return _queue.Count == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}
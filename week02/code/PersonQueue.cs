/// <summary>
/// A basic implementation of a Queue (FIFO - First-In, First-Out)
/// </summary>
/// <summary>
/// A basic implementation of a Queue (FIFO - First-In, First-Out)
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the end of the queue (FIFO behavior).
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        // *** CORRECCIÓN CLAVE AQUÍ ***
        // Para que sea FIFO, los nuevos elementos se añaden al FINAL de la lista.
        _queue.Add(person);
    }

    /// <summary>
    /// Remove and return the person from the front of the queue (FIFO behavior).
    /// </summary>
    public Person Dequeue()
    {
        // Es buena práctica verificar si la cola está vacía antes de desencolar.
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        var person = _queue[0];     // Obtener el primer elemento
        _queue.RemoveAt(0);          // Remover el primer elemento
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
using System.Collections;

public class LinkedList : IEnumerable<int>{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value){
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null){
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value){
        // TODO Problem 1 - ADD YOUR CODE HERE
        // 1. Create a new node with the given value.
        Node newNode = new(value);

        // 2. Case: If the list is empty
        //    (both _head and _tail are null, or just _head is null)
        if (_tail is null){ // Or _head is null, they should be null together
    
            _head = newNode;
            _tail = newNode;
        }
        // 3. Case: If the list is not empty
        else{
            // Connect the current tail's Next to the new node
            _tail.Next = newNode;
            // Connect the new node's Prev to the current tail
            newNode.Prev = _tail;
            // Update the tail to be the new node
            _tail = newNode;
        }
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead(){
        // If the list has only one item in it, then set head and tail
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail){
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null){
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail(){
        // TODO Problem 2 - ADD YOUR CODE HERE
        // Case 1: The list is empty or has only one node.
        // This condition (_head == _tail) covers both cases:
        // - If _head is null (empty list), it remains null.
        // - If _head and _tail point to the same (single) node, both become null.
        if (_head == _tail){
            _head = null;
            _tail = null;
        }
        // Case 2: The list has more than one node.
        // We need to update the _tail to point to the second-to-last node,
        // and sever the connection from that new tail to the old tail.
        else if (_tail is not null){ // Ensures the list is not empty (already handled by first if for single/empty)
            // The new tail will be the node currently pointed to by _tail.Prev.
            // We need to disconnect it from the old tail.
            _tail.Prev!.Next = null; // Disconnect the new tail from the old tail.
            _tail = _tail.Prev;      // Update _tail to be the new tail.
            // The old tail's Prev pointer is still set, but it will be garbage collected
            // once no other references point to it.
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue){
        // Search for the node that matches 'value' by starting at the
        // head of the list.
        Node? curr = _head;
        while (curr is not null){
            if (curr.Data == value){
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail){
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a
                // new node and reconnect the links to insert.
                else{
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
    public void Remove(int value){
        // TODO Problem 3 - ADD YOUR CODE HERE

        // Case 1: List is empty. Nothing to remove.
        if (_head is null){
            return;
        }

        Node? curr = _head;

        // Iterate through the list to find the first occurrence of 'value'
        while (curr is not null){
            if (curr.Data == value){
                // Case 2: Node to remove is the Head
                if (curr == _head){
                    RemoveHead(); // Reuse existing function
                }
                // Case 3: Node to remove is the Tail (and not the head, handled above)
                else if (curr == _tail){
                    RemoveTail(); // Reuse existing function
                }
                // Case 4: Node to remove is in the middle of the list
                else{
                    // Reconnect the previous node to the next node
                    curr.Prev!.Next = curr.Next;
                    // Reconnect the next node to the previous node
                    curr.Next!.Prev = curr.Prev;
                    // Note: curr.Prev and curr.Next cannot be null if curr is a middle node.
                }

                // Node found and removed, exit the function.
                return;
            }

            // Move to the next node if 'value' not found in current node
            curr = curr.Next;
        }
        // If the loop finishes, it means 'value' was not found in the list.
        // No action is needed as per the problem description (just "remove that one node").
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue){
        // TODO Problem 4 - ADD YOUR CODE HERE
        // Comenzar la búsqueda desde el principio de la lista.
        Node? curr = _head;

        // Iterar sobre cada nodo de la lista.
        while (curr is not null){
            // Si el dato del nodo actual coincide con oldValue, reemplazarlo.
            if (curr.Data == oldValue){
                curr.Data = newValue; // Reemplazar el valor.
            }

            // Mover al siguiente nodo para continuar la búsqueda (a diferencia de Remove).
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator(){
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator(){
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null){
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse(){
        // TODO Problem 5 - ADD YOUR CODE HERE
        // Iniciar la iteración desde la cola (_tail) para ir hacia atrás.
        var curr = _tail;

        // Iterar mientras el nodo actual no sea nulo.
        while (curr is not null){
            // Proporcionar (yield) el dato del nodo actual.
            yield return curr.Data;

            // Mover al nodo anterior en la lista (hacia atrás).
            curr = curr.Prev;
        }
    }

    public override string ToString(){
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull(){
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull(){
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests{
    [TestMethod]
    // Scenario: Enqueue multiple items with varying priorities and then Dequeue them.
    // Expected Result: Items should be dequeued in order of highest priority. If priorities are equal, 
    // Defect(s) Found:
    // 1. Defect in Dequeue: The loop condition 'index < _queue.Count - 1' was incorrect. It should be 'index < _queue.Count'.
    //    This caused the last element of the queue to never be considered for highest priority.
    //    (e.g., if E (30) was the last element, it might be missed).
    // 2. Defect in Dequeue: The condition to select the high priority item '_queue[index].Priority >= _queue[highPriorityIndex].Priority'
    //    was incorrect for tie-breaking. It should be strictly '>' for priority, to ensure FIFO order for equal priorities.
    //    If it's '>=', and a new item has the same priority as the current 'highPriorityIndex' item, the 'highPriorityIndex'
    //    would be updated to the newer (later) item, violating FIFO for ties.
    // 3. Defect in Dequeue: After finding the highPriorityIndex, the item was not actually removed from _queue.
    //    The line '_queue.RemoveAt(highPriorityIndex);' was missing, leading to the same item being returned repeatedly
    //    and the queue never shrinking.
    public void TestPriorityQueue_ComplexPrioritiesAndFifoTieBreaking(){
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("ItemD", 20); // 1
        priorityQueue.Enqueue("ItemA", 40); // 2
        priorityQueue.Enqueue("ItemC", 50); // 3 
        priorityQueue.Enqueue("ItemB", 40); // 4 
        priorityQueue.Enqueue("ItemE", 30); // 5

        // Current visual queue (ordered by enqueue order): [D(20), A(40), C(50), B(40), E(30)]
        Assert.AreEqual("ItemC", priorityQueue.Dequeue(), "Dequeue 1: ItemC (Highest Priority)"); // C(50)
        Assert.AreEqual("ItemA", priorityQueue.Dequeue(), "Dequeue 2: ItemA (Highest Priority among A/B, FIFO)"); // A(40)
        Assert.AreEqual("ItemB", priorityQueue.Dequeue(), "Dequeue 3: ItemB (Next highest priority, FIFO for ties)"); // B(40)
        Assert.AreEqual("ItemE", priorityQueue.Dequeue(), "Dequeue 4: ItemE (Next highest priority)"); // E(30)
        Assert.AreEqual("ItemD", priorityQueue.Dequeue(), "Dequeue 5: ItemD (Last remaining item)"); // D(20)
        
    }

    [TestMethod]
    // Scenario: Try to Dequeue from an empty PriorityQueue.
    // Expected Result: An InvalidOperationException should be thrown with the message "The queue is empty.".
    // Defect(s) Found:
    // 1. None. The initial code already handles this correctly by throwing the specified exception.
    public void TestPriorityQueue_EmptyQueueException(){
        var priorityQueue = new PriorityQueue();

        try{
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown for an empty queue.");
        }
        catch (InvalidOperationException e){
            Assert.AreEqual("The queue is empty.", e.Message, "Incorrect exception message for empty queue.");
        }
        catch (AssertFailedException){
            throw; 
        }
        catch (Exception e){
            Assert.Fail($"Unexpected exception type thrown: {e.GetType().Name}. Expected InvalidOperationException.");
        }
    }

    [TestMethod]
    // Scenario: Enqueue a single item and then Dequeue it.
    // Expected Result: The enqueued item should be returned.
    // Defect(s) Found:
    // 1. Defect in Dequeue: The loop condition 'index < _queue.Count - 1' would cause the loop to not run at all
    //    if _queue.Count is 1 (0 < 1-1 = 0 is false), so highPriorityIndex would remain 0, which is correct for a single item.
    //    However, the missing '_queue.RemoveAt(highPriorityIndex);' would still be an issue (same as Test 1).
    //    After fixing Test 1's issues, this test should pass automatically.
    public void TestPriorityQueue_SingleItem(){
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Single", 100);

        Assert.AreEqual("Single", priorityQueue.Dequeue(), "Single item was not dequeued correctly.");
        Assert.IsTrue(priorityQueue.Count == 0, "Queue should be empty after dequeuing the single item.");
    }


    // Add more test cases as needed below.
    // Example: Test with all same priorities to ensure strict FIFO
    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority.
    // Expected Result: Items should be dequeued in their original enqueue order (FIFO).
    //                  Specifically: ItemA (10), ItemB (10), ItemC (10).
    // Defect(s) Found:
    // 1. Defect in Dequeue: The tie-breaking condition was using '>=' instead of strictly '>'.
    //    This would cause the 'highPriorityIndex' to incorrectly update to a *later* item if it had the
    //    exact same priority as the current highest. This violates the FIFO rule for equal priorities.
    public void TestPriorityQueue_SamePrioritiesFifo(){
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("ItemA", 10);
        priorityQueue.Enqueue("ItemB", 10);
        priorityQueue.Enqueue("ItemC", 10);

        Assert.AreEqual("ItemA", priorityQueue.Dequeue(), "Dequeue 1: ItemA (FIFO)");
        Assert.AreEqual("ItemB", priorityQueue.Dequeue(), "Dequeue 2: ItemB (FIFO)");
        Assert.AreEqual("ItemC", priorityQueue.Dequeue(), "Dequeue 3: ItemC (FIFO)");
    }
}
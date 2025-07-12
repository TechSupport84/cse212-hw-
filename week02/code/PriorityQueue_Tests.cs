using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue two items with different priorities and dequeue them
    // Expected Result: Higher priority item dequeued first, then lower priority
    // Defect(s) Found: None yet, implement and verify
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high", 10);

        Assert.AreEqual("high", priorityQueue.Dequeue());
        Assert.AreEqual("low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with same priority and dequeue them
    // Expected Result: Items dequeued in FIFO order for same priority
    // Defect(s) Found: None yet, implement and verify
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("first", 5);
        priorityQueue.Enqueue("second", 5);

        Assert.AreEqual("first", priorityQueue.Dequeue());
        Assert.AreEqual("second", priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Dequeue on empty queue throws exception
    // Expected Result: InvalidOperationException is thrown
    // Defect(s) Found: None yet, implement and verify
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_3_EmptyQueueThrows()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue(); // Should throw
    }
}

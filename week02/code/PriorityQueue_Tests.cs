using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_1()
    {
        //string[] expectedResult = ["Nina", "Randy", "Paul", "Oscar", "Sam"];

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("FirstItem", 5);
        priorityQueue.Enqueue("SecondItem", 5);
        priorityQueue.Enqueue("ThirdItem", 5);

        var dequeuedItem1 = priorityQueue.Dequeue();
        var dequeuedItem2 = priorityQueue.Dequeue();
        var dequeuedItem3 = priorityQueue.Dequeue();

        Assert.AreEqual("FirstItem", dequeuedItem1, "Expected FIFO order for same-priority items.");
        Assert.AreEqual("SecondItem", dequeuedItem2, "Expected FIFO order for same-priority items.");
        Assert.AreEqual("ThirdItem", dequeuedItem3, "Expected FIFO order for same-priority items.");

    }

    [TestMethod]
    // Scenario: 
    // Expected Result: 
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        Assert.Fail("Implement the test case and then remove this.");
    }

    // Add more test cases as needed below.
}
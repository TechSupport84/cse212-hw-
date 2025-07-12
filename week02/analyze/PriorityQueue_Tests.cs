using System;
using System.Collections.Generic;

public class PriorityQueue<T> {
    private class QueueItem {
        public T Data { get; set; }
        public int Priority { get; set; }
        public int InsertionIndex { get; set; }  // For FIFO among equal priority
    }

    private List<QueueItem> items = new List<QueueItem>();
    private int insertionCounter = 0;

    public void Enqueue(T data, int priority) {
        items.Add(new QueueItem {
            Data = data,
            Priority = priority,
            InsertionIndex = insertionCounter++
        });
    }

    public T Dequeue() {
        if (items.Count == 0)
            throw new InvalidOperationException("Queue is empty.");

        // Find item with highest priority; among ties, lowest insertion index
        int bestIndex = 0;
        for (int i = 1; i < items.Count; i++) {
            if (items[i].Priority > items[bestIndex].Priority ||
               (items[i].Priority == items[bestIndex].Priority &&
                items[i].InsertionIndex < items[bestIndex].InsertionIndex)) {
                bestIndex = i;
            }
        }

        var bestItem = items[bestIndex];
        items.RemoveAt(bestIndex);
        return bestItem.Data;
    }
}

// See https://aka.ms/new-console-template for more information

using System;

class Program
{
    static void HeapSort(int[] array)
    {
        int n = array.Length;

        // Build heap
        for (int i = n / 2 - 1; i >= 0; i--)
            Heapify(array, n, i);

        // Extract elements from heap
        for (int i = n - 1; i > 0; i--)
        {
            // Swap root with the last element
            int temp = array[0];
            array[0] = array[i];
            array[i] = temp;

            // Heapify the reduced heap
            Heapify(array, i, 0);
        }
    }

    static void Heapify(int[] array, int n, int i)
    {
        int largest = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < n && array[left] > array[largest])
            largest = left;

        if (right < n && array[right] > array[largest])
            largest = right;

        if (largest != i)
        {
            int swap = array[i];
            array[i] = array[largest];
            array[largest] = swap;

            Heapify(array, n, largest);
        }
    }

    static void Main()
    {
        int[] array = { 4, 10, 3, 5, 1 };

        Console.WriteLine("Before sorting:");
        Console.WriteLine(string.Join(" ", array));

        HeapSort(array);

        Console.WriteLine("\nAfter sorting:");
        Console.WriteLine(string.Join(" ", array));
    }
}

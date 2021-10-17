using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

public class Program
{
    #region Bubble Sorts

    public static void bubbleSort1(ref int[] x)
    {
        bool exchanges;
        do
        {
            exchanges = false;
            for (int i = 0; i < x.Length - 1; i++)
            {
                if (x[i] > x[i + 1])
                {
                    // Exchange elements
                    int temp = x[i];
                    x[i] = x[i + 1];
                    x[i + 1] = temp;
                    exchanges = true;
                }
            }
        } while (exchanges);
    }

    public static void bubbleSort2(ref int[] x)
    {
        for (int pass = 1; pass < x.Length - 1; pass++)
        {
            // Count how many times this next loop
            // becomes shorter and shorter
            for (int i = 0; i < x.Length - pass; i++)
            {
                if (x[i] > x[i + 1])
                {
                    // Exchange elements
                    int temp = x[i];
                    x[i] = x[i + 1];
                    x[i + 1] = temp;
                }
            }
        }
    }

    public static void bubbleSort3(ref int[] x)
    {
        bool exchanges;
        int n = x.Length;
        do
        {
            n--; // Make loop smaller each time.
            // and assume this is last pass over array
            exchanges = false;
            for (int i = 0; i < x.Length - 1; i++)
            {
                if (x[i] > x[i + 1])
                {
                    // Exchange elements
                    int temp = x[i];
                    x[i] = x[i + 1];
                    x[i + 1] = temp;
                    exchanges = true;
                }
            }
        } while (exchanges);
    }

    public static void bubbleSortRange(ref int[] x)
    {
        int lowerBound = 0; // First position to compare.
        int upperBound = x.Length - 1; // First position NOT to compare.
        int n = x.Length - 1;

        // Continue making passes while there is a potential exchange.
        while (lowerBound <= upperBound)
        {
            int firstExchange = n;  // assume impossibly high index for low end.
            int lastExchange = -1; // assume impossibly low index for high end.

            // Make a pass over the appropriate range.
            for (int i = lowerBound; i < upperBound; i++)
            {
                if (x[i] > x[i + 1])
                {
                    // Exchange elements
                    int temp = x[i];
                    x[i] = x[i + 1];
                    x[i + 1] = temp;
                    // Remember first and last exchange indexes.
                    if (i < firstExchange)
                    {   // True only for first exchange.
                        firstExchange = i;
                    }
                    lastExchange = i;
                }
            }

            //--- Prepare limits for next pass.
            lowerBound = firstExchange - 1;
            if (lowerBound < 0)
            {
                lowerBound = 0;
            }
            upperBound = lastExchange;
        }
    }
    #endregion

    #region Cocktail Sort
    public static void CocktailSort(ref int[] x)
    {
        for (int k = x.Length - 1; k > 0; k--)
        {
            bool swapped = false;
            for (int i = k; i > 0; i--)
                if (x[i] < x[i - 1])
                {
                    // swap
                    int temp = x[i];
                    x[i] = x[i - 1];
                    x[i - 1] = temp;
                    swapped = true;
                }

            for (int i = 0; i < k; i++)
                if (x[i] > x[i + 1])
                {
                    // swap
                    int temp = x[i];
                    x[i] = x[i + 1];
                    x[i + 1] = temp;
                    swapped = true;
                }

            if (!swapped)
                break;
        }
    }
    #endregion

    #region Odd Even Sort
    public static void OddEvenSort(ref int[] x)
    {
        int temp;
        for (int i = 0; i < x.Length / 2; ++i)
        {
            for (int j = 0; j < x.Length - 1; j += 2)
            {
                if (x[j] > x[j + 1])
                {
                    temp = x[j];
                    x[j] = x[j + 1];
                    x[j + 1] = temp;
                }
            }

            for (int j = 1; j < x.Length - 1; j += 2)
            {
                if (x[j] > x[j + 1])
                {
                    temp = x[j];
                    x[j] = x[j + 1];
                    x[j + 1] = temp;
                }
            }
        }
    }
    #endregion

    #region Comb Sort
    public static int newGap(int gap)
    {
        gap = gap * 10 / 13;
        if (gap == 9 || gap == 10)
            gap = 11;
        if (gap < 1)
            return 1;
        return gap;
    }

    public static void CombSort(ref int[] x)
    {
        int gap = x.Length;
        bool swapped;
        do
        {
            swapped = false;
            gap = newGap(gap);
            for (int i = 0; i < (x.Length - gap); i++)
            {
                if (x[i] > x[i + gap])
                {
                    swapped = true;
                    int temp = x[i];
                    x[i] = x[i + gap];
                    x[i + gap] = temp;
                }
            }
        } while (gap > 1 || swapped);
    }
    #endregion

    #region Gnome Sort
    public static void GnomeSort(ref int[] x)
    {
        int i = 0;
        while (i < x.Length)
        {
            if (i == 0 || x[i - 1] <= x[i]) i++;
            else
            {
                int temp = x[i];
                x[i] = x[i - 1];
                x[--i] = temp;
            }
        }
    }
    #endregion

    #region Insertion Sort
    public static void InsertionSort(ref int[] x)
    {
        int n = x.Length - 1;
        int i, j, temp;

        for (i = 1; i <= n; ++i)
        {
            temp = x[i];
            for (j = i - 1; j >= 0; --j)
            {
                if (temp < x[j]) x[j + 1] = x[j];
                else break;
            }
            x[j + 1] = temp;
        }
    }
    #endregion

    #region Quick Sort

    public static void QuickSort(ref int[] x)
    {
        qs(x, 0, x.Length - 1);
    }

    public static void qs(int[] x, int left, int right)
    {
        int i, j;
        int pivot, temp;

        i = left;
        j = right;
        pivot = x[(left + right) / 2];

        do
        {
            while ((x[i] < pivot) && (i < right)) i++;
            while ((pivot < x[j]) && (j > left)) j--;

            if (i <= j)
            {
                temp = x[i];
                x[i] = x[j];
                x[j] = temp;
                i++; j--;
            }
        } while (i <= j);

        if (left < j) qs(x, left, j);
        if (i < right) qs(x, i, right);
    }

    #endregion

    #region Shell Sort

    public static void ShellSort(ref int[] x)
    {
        int i, j, temp;
        int increment = 3;

        while (increment > 0)
        {
            for (i = 0; i < x.Length; i++)
            {
                j = i;
                temp = x[i];

                while ((j >= increment) && (x[j - increment] > temp))
                {
                    x[j] = x[j - increment];
                    j = j - increment;
                }

                x[j] = temp;
            }

            if (increment / 2 != 0)
            {
                increment = increment / 2;
            }
            else if (increment == 1)
            {
                increment = 0;
            }
            else
            {
                increment = 1;
            }
        }
    }
    #endregion

    #region Selection Sort

    public static void SelectionSort(ref int[] x)
    {
        int i, j;
        int min, temp;

        for (i = 0; i < x.Length - 1; i++)
        {
            min = i;
            for (j = i + 1; j < x.Length; j++)
            {
                if (x[j] < x[min])
                {
                    min = j;
                }
            }
            temp = x[i];
            x[i] = x[min];
            x[min] = temp;
        }
    }
    #endregion

    #region Merge Sort

    public static void MergeSort(ref int[] x, int left, int right)
    {
        if (left < right)
        {
            int middle = (left + right) / 2;
            MergeSort(ref x, left, middle);
            MergeSort(ref x, middle + 1, right);
            Merge(ref x, left, middle, middle + 1, right);
        }
    }

    public static void Merge(ref int[] x, int left, int middle, int middle1, int right)
    {
        int oldPosition = left;
        int size = right - left + 1;
        int[] temp = new int[size];
        int i = 0;

        while (left <= middle && middle1 <= right)
        {
            if (x[left] <= x[middle1])
                temp[i++] = x[left++];
            else
                temp[i++] = x[middle1++];
        }
        if (left > middle)
            for (int j = middle1; j <= right; j++)
                temp[i++] = x[middle1++];
        else
            for (int j = left; j <= middle; j++)
                temp[i++] = x[left++];
        Array.Copy(temp, 0, x, oldPosition, size);
    }
    #endregion

    #region Bucket Sort

    public static void BucketSort(ref int[] x)
    {
        //Verify input
        if (x == null || x.Length <= 1)
            return;

        //Find the maximum and minimum values in the array
        int maxValue = x[0];
        int minValue = x[0];

        for (int i = 1; i < x.Length; i++)
        {
            if (x[i] > maxValue)
                maxValue = x[i];

            if (x[i] < minValue)
                minValue = x[i];
        }

        //Create a temporary "bucket" to store the values in order
        //each value will be stored in its corresponding index
        //scooting everything over to the left as much as possible (minValue)
        LinkedList<int>[] bucket = new LinkedList<int>[maxValue - minValue + 1];

        //Move items to bucket
        for (int i = 0; i < x.Length; i++)
        {
            if (bucket[x[i] - minValue] == null)
                bucket[x[i] - minValue] = new LinkedList<int>();

            bucket[x[i] - minValue].AddLast(x[i]);
        }

        //Move items in the bucket back to the original array in order
        int k = 0; //index for original array
        for (int i = 0; i < bucket.Length; i++)
        {
            if (bucket[i] != null)
            {
                LinkedListNode<int> node = bucket[i].First; //start add head of linked list

                while (node != null)
                {
                    x[k] = node.Value; //get value of current linked node
                    node = node.Next; //move to next linked node
                    k++;
                }
            }
        }
    }
    #endregion

    #region Heap Sort

    public static void Heapsort(ref int[] x)
    {
        int i;
        int temp;
        int n = x.Length;

        for (i = (n / 2) - 1; i >= 0; i--)
        {
            siftDown(ref x, i, n);
        }

        for (i = n - 1; i >= 1; i--)
        {
            temp = x[0];
            x[0] = x[i];
            x[i] = temp;
            siftDown(ref x, 0, i - 1);
        }
    }

    public static void siftDown(ref int[] x, int root, int bottom)
    {
        bool done = false;
        int maxChild;
        int temp;

        while ((root * 2 <= bottom) && (!done))
        {
            if (root * 2 == bottom)
                maxChild = root * 2;
            else if (x[root * 2] > x[root * 2 + 1])
                maxChild = root * 2;
            else
                maxChild = root * 2 + 1;

            if (x[root] < x[maxChild])
            {
                temp = x[root];
                x[root] = x[maxChild];
                x[maxChild] = temp;
                root = maxChild;
            }
            else
            {
                done = true;
            }
        }
    }
    #endregion

    #region Count Sort

    public static void Count_Sort(ref int[] x)
    {
        try
        {
            int i = 0;
            int k = FindMax(x); //Finds max value of input array

            // output array holds the sorted output
            int[] output = new int[x.Length];

            // provides temperarory storage 
            int[] temp = new int[k + 1];
            for (i = 0; i < k + 1; i++)
            {
                temp[i] = 0;
            }

            for (i = 0; i < x.Length; i++)
            {
                temp[x[i]] = temp[x[i]] + 1;
            }

            for (i = 1; i < k + 1; i++)
            {
                temp[i] = temp[i] + temp[i - 1];
            }

            for (i = x.Length - 1; i >= 0; i--)
            {
                output[temp[x[i]] - 1] = x[i];
                temp[x[i]] = temp[x[i]] - 1;
            }

            for (i = 0; i < x.Length; i++)
            {
                x[i] = output[i];
            }
        }

        catch (System.Exception e)
        {
            Console.WriteLine(e.ToString());
            Console.ReadLine();
        }
    }
    #endregion

    #region Radix Sort

    //RadixSort takes an array and the number of bits used as 
    //the key in each iteration.
    public static void RadixSort(ref int[] x, int bits)
    {
        //Use an array of the same size as the original array 
        //to store the result of each iteration.
        int[] b = new int[x.Length];
        int[] b_orig = b;

        //Mask is the bitmask used to extract the sort key. 
        //We start with the bits least significant bits and
        //left-shift it the same amount at each iteration. 
        //When all the bits are shifted out of the word, we are done.
        int rshift = 0;
        for (int mask = ~(-1 << bits); mask != 0; mask <<= bits, rshift += bits)
        {
            //An array is needed to store the count for each key value.
            int[] cntarray = new int[1 << bits];

            //Count each key value
            for (int p = 0; p < x.Length; ++p)
            {
                int key = (x[p] & mask) >> rshift;
                ++cntarray[key];
            }

            //Sum up how many elements there are with lower 
            //key values, for each key.
            for (int i = 1; i < cntarray.Length; ++i)
                cntarray[i] += cntarray[i - 1];

            //The values in cntarray are used as indexes 
            //for storing the values in b. b will then be
            //completely sorted on this iteration's key. 
            //Elements with the same key value are stored 
            //in their original internal order.
            for (int p = x.Length - 1; p >= 0; --p)
            {
                int key = (x[p] & mask) >> rshift;
                --cntarray[key];
                b[cntarray[key]] = x[p];
            }

            //Swap the a and b references, so that the 
            //next iteration works on the current b, 
            //which is now partially sorted.
            int[] temp = b; b = x; x = temp;
        }
    }

    #endregion

    #region Linear Search
    public static int LinearSearch(ref int[] x, int valueToFind)
    {
        for (int i = 0; i < x.Length; i++)
        {
            if (valueToFind == x[i])
            {
                return i;
            }
        }
        return -1;
    }
    #endregion

    #region Binary Search

    public static int BinSearch(ref int[] x, int searchValue)
    {
        // Returns index of searchValue in sorted array x, or -1 if not found
        int left = 0;
        int right = x.Length;
        return binarySearch(ref x, searchValue, left, right);
    }

    public static int binarySearch(ref int[] x, int searchValue, int left, int right)
    {
        if (right < left)
        {
            return -1;
        }
        int mid = (left + right) >> 1;
        if (searchValue > x[mid])
        {
            return binarySearch(ref x, searchValue, mid + 1, right);
        }
        else if (searchValue < x[mid])
        {
            return binarySearch(ref x, searchValue, left, mid - 1);
        }
        else
        {
            return mid;
        }
    }
    #endregion

    #region Interpolation Search

    public static int InterpolationSearch(ref int[] x, int searchValue)
    {
        // Returns index of searchValue in sorted input data
        // array x, or -1 if searchValue is not found
        int low = 0;
        int high = x.Length - 1;
        int mid;

        while (x[low] < searchValue && x[high] >= searchValue)
        {
            mid = low + ((searchValue - x[low]) * (high - low)) / (x[high] - x[low]);

            if (x[mid] < searchValue)
                low = mid + 1;
            else if (x[mid] > searchValue)
                high = mid - 1;
            else
                return mid;
        }

        if (x[low] == searchValue)
            return low;
        else
            return -1; // Not found
    }
    #endregion

    #region Nth Largest

    public static int NthLargest1(int[] array, int n)
    {
        //Copy input data array into a temporary array
        //so that original array is unchanged
        int[] tempArray = new int[array.Length];
        array.CopyTo(tempArray, 0);
        //Sort the array
        QuickSort(ref tempArray);
        //Return the n-th largest value in the sorted array
        return tempArray[tempArray.Length - n];
    }

    public static int NthLargest2(int[] array, int k)
    {
        int maxIndex;
        int maxValue;

        //Copy input data array into a temporary array
        //so that original array is unchanged
        int[] tempArray = new int[array.Length];
        array.CopyTo(tempArray, 0);

        for (int i = 0; i < k; i++)
        {
            maxIndex = i;       // index of minimum element
            maxValue = tempArray[i];// assume minimum is the first array element
            for (int j = i + 1; j < tempArray.Length; j++)
            {
                // if we've located a higher value
                if (tempArray[j] > maxValue)
                {   // capture it
                    maxIndex = j;
                    maxValue = tempArray[j];
                }
            }
            Swap(ref tempArray[i], ref tempArray[maxIndex]);
        }
        return tempArray[k - 1];
    }
    #endregion

    #region Mth Smallest

    public static int MthSmallest1(int[] array, int m)
    {
        //Copy input data array into a temporary array
        //so that original array is unchanged
        int[] tempArray = new int[array.Length];
        array.CopyTo(tempArray, 0);
        //Sort the array
        QuickSort(ref tempArray);
        //Return the m-th smallest value in the sorted array
        return tempArray[m - 1];
    }

    public static int MthSmallest2(int[] array, int m)
    {
        int minIndex;
        int minValue;

        //Copy input data array into a temporary array
        //so that original array is unchanged
        int[] tempArray = new int[array.Length];
        array.CopyTo(tempArray, 0);

        for (int i = 0; i < m; i++)
        {
            minIndex = i;      // index of minimum element
            minValue = tempArray[i];// assume minimum is the first array element
            for (int j = i + 1; j < array.Length; j++)
            {
                if (tempArray[j] < minValue)
                {   // capture it
                    minIndex = j;
                    minValue = tempArray[j];
                }
            }
            Swap(ref tempArray[i], ref tempArray[minIndex]);
        }
        return tempArray[m - 1];
    }
    #endregion

    #region Miscellaneous Utilities

    public static int FindMax(int[] x)
    {
        int max = x[0];
        for (int i = 1; i < x.Length; i++)
        {
            if (x[i] > max) max = x[i];
        }
        return max;
    }

    public static int FindMin(int[] x)
    {
        int min = x[0];
        for (int i = 1; i < x.Length; i++)
        {
            if (x[i] < min) min = x[i];
        }
        return min;
    }

    static void MixDataUp(ref int[] x, Random rdn)
    {
        for (int i = 0; i <= x.Length - 1; i++)
        {
            x[i] = (int)(rdn.NextDouble() * x.Length);
        }
    }

    static void Swap(ref int left, ref int right)
    {
        int temp = left;
        left = right;
        right = temp;
    }

    // Determines if int array is sorted from 0 -> Max
    public static bool IsSorted(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i - 1] > arr[i])
            {
                return false;
            }
        }
        return true;
    }

    // Determines if string array is sorted from A -> Z
    public static bool IsSorted(string[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i - 1].CompareTo(arr[i]) > 0) // If previous is bigger, return false
            {
                return false;
            }
        }
        return true;
    }

    // Determines if int array is sorted from Max -> 0
    public static bool IsSortedDescending(int[] arr)
    {
        for (int i = arr.Length - 2; i >= 0; i--)
        {
            if (arr[i] < arr[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    // Determines if string array is sorted from Z -> A
    public static bool IsSortedDescending(string[] arr)
    {
        for (int i = arr.Length - 2; i >= 0; i--)
        {
            if (arr[i].CompareTo(arr[i + 1]) < 0) // If previous is smaller, return false
            {
                return false;
            }
        }
        return true;
    }

    public static void DisplayElements(ref int[] xArray, char status, string sortname)
    {
        if (status == 'a')
            Console.WriteLine("After sorting using algorithm: " + sortname);
        else
            Console.WriteLine("Before sorting");
        for (int i = 0; i <= xArray.Length - 1; i++)
        {
            if ((i != 0) && (i % 10 == 0))
                Console.Write("\n");
            Console.Write(xArray[i] + " ");
        }
        Console.ReadLine();
    }
    #endregion

    static void Main(string[] args)
    {
        Console.WriteLine("Sorting Algorithms Demo Code\n\n");

        const int nItems = 20;
        Random rdn = new Random(nItems);
        int[] xdata = new int[nItems];

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");
        bubbleSort1(ref xdata);
        DisplayElements(ref xdata, 'a', "bubbleSort1");
        Console.WriteLine("\n\n");

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");
        bubbleSort2(ref xdata);
        DisplayElements(ref xdata, 'a', "bubbleSort2");
        Console.WriteLine("\n\n");

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");
        bubbleSort3(ref xdata);
        DisplayElements(ref xdata, 'a', "bubbleSort3");
        Console.WriteLine("\n\n");

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");
        bubbleSortRange(ref xdata);
        DisplayElements(ref xdata, 'a', "bubbleSortRange");
        Console.WriteLine("\n\n");

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");
        CocktailSort(ref xdata);
        DisplayElements(ref xdata, 'a', "CocktailSort");
        Console.WriteLine("\n\n");

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");
        OddEvenSort(ref xdata);
        DisplayElements(ref xdata, 'a', "OddEvenSort");
        Console.WriteLine("\n\n");

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");
        CombSort(ref xdata);
        DisplayElements(ref xdata, 'a', "CombSort");
        Console.WriteLine("\n\n");

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");
        GnomeSort(ref xdata);
        DisplayElements(ref xdata, 'a', "GnomeSort");
        Console.WriteLine("\n\n");

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");
        InsertionSort(ref xdata);
        DisplayElements(ref xdata, 'a', "InsertionSort");
        Console.WriteLine("\n\n");

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");
        QuickSort(ref xdata);
        DisplayElements(ref xdata, 'a', "QuickSort");
        Console.WriteLine("\n\n");

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");
        ShellSort(ref xdata);
        DisplayElements(ref xdata, 'a', "ShellSort");
        Console.WriteLine("\n\n");

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");
        SelectionSort(ref xdata);
        DisplayElements(ref xdata, 'a', "SelectionSort");
        Console.WriteLine("\n\n");

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");
        MergeSort(ref xdata, 0, xdata.Length - 1);
        DisplayElements(ref xdata, 'a', "MergeSort");
        Console.WriteLine("\n\n");

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");
        BucketSort(ref xdata);
        DisplayElements(ref xdata, 'a', "BucketSort");
        Console.WriteLine("\n\n");

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");
        Heapsort(ref xdata);
        DisplayElements(ref xdata, 'a', "HeapSort");
        Console.WriteLine("\n\n");

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");
        Count_Sort(ref xdata);
        DisplayElements(ref xdata, 'a', "CountSort");
        Console.WriteLine("\n\n");

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");
        int bits = 4;
        RadixSort(ref xdata, bits);
        DisplayElements(ref xdata, 'a', "RadixSort");
        Console.WriteLine("\n\n");

        //The search tests that follow are divided into two steps
        //(1) Tries to find the 4th data entry in a randomized list. 
        //Since this data value always exist, the result will always be successful
        //(2) Tries to find a numerical value of 100 in a randomized list.
        //Since this data value is beyond the maximum
        //value that the random generator is setup 
        //to produce, the result will always fail.
        //This way all possible outcomes are fully checked.
        //Note that the linear search strategy
        //is the out method that accepts randomized data.
        //For all other searches, the data must be sorted first.

        Console.WriteLine("Search Algorithms Demo Code\n\n");

        MixDataUp(ref xdata, rdn); //Randomize data to be searched
        DisplayElements(ref xdata, 'b', ""); //Display random data

        Console.WriteLine("Using LINEAR SEARCH ALGORITHM " +
                "to look for 4th data entry in randomized list");
        //Look for the 4th data entry in the list
        int location = LinearSearch(ref xdata, xdata[4]);
        if (location == -1)
            Console.WriteLine("Value was not found in list");
        else
            Console.WriteLine("Found it at location = {0}", location);
        location = LinearSearch(ref xdata, 100); //Look for the number 100 in the list.
        if (location == -1)
            Console.WriteLine("Value of 100 was not found in list");
        else
            Console.WriteLine("Value of 100 was found at at location = {0}", location);

        Console.WriteLine("\n\n");

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', ""); //Display random data
        QuickSort(ref xdata);
        Console.WriteLine("Using INTERPOLATION SEARCH ALGORITHM " +
                "to look for 4th data entry in randomized list");

        location = InterpolationSearch(ref xdata, xdata[4]);
        if (location == -1)
            Console.WriteLine("Value was not found in list");
        else
            Console.WriteLine("Found it at location = {0}", location);

        location = InterpolationSearch(ref xdata, 100);
        if (location == -1)
            Console.WriteLine("Value of 100 was not found in list");
        else
            Console.WriteLine("Value of 100 was found at at location = {0}", location);

        Console.WriteLine("\n\n");

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', ""); //Display random data
        QuickSort(ref xdata);
        Console.WriteLine("Using BINARY SEARCH ALGORITHM to " +
                          "look for 4th data entry in randomized list");

        location = BinSearch(ref xdata, xdata[4]);
        if (location == -1)
            Console.WriteLine("Value was not found in list");
        else
            Console.WriteLine("Found it at location = {0}", location);

        location = InterpolationSearch(ref xdata, 100);
        if (location == -1)
            Console.WriteLine("Value of 100 was not found in list");
        else
            Console.WriteLine("Value of 100 was found at at location = {0}", location);

        Console.WriteLine("\n\n");

        //The ArrayList collection in C# comes with its own built-in search algorithm.
        //And can be called up to perform a search as shown below.

        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");    //Display random data
        Console.WriteLine("Using the built-in BINARY " +
                "SEARCH ALGORITHM in ArrayList data structure");
        ArrayList alist = new ArrayList();      //Set up an ArrayList object
        for (int i = 0; i < xdata.Length; i++)
            alist.Add(xdata[i]);                //and add some radomized data to it

        location = alist.BinarySearch(xdata[4]); //Call up its BinarySearch method
        if (location == -1)                     //and run the examples
            Console.WriteLine("Value was not found in list");
        else
            Console.WriteLine("Found it at location = {0}", location);

        location = alist.BinarySearch(100);
        if (location < 0)
            Console.WriteLine("Value was not found in list");
        else
            Console.WriteLine("Found it at location = {0}", location);

        Console.WriteLine("Testing to find the n-th largest " +
                "value in a random array\n\nOriginal Data (method 1): \n");
        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");

        int nthMathIndex1 = 8;

        int nthMaxValue1 = NthLargest1(xdata, nthMathIndex1);

        Console.WriteLine("\nThe " + nthMathIndex1 +
          " largest value in the array above is: " +
          nthMaxValue1 + "\n");

        Console.WriteLine("Verifying result... \nFirst verify " +
                          "that original data array is not changed.\n");
        DisplayElements(ref xdata, 'b', "");
        Console.WriteLine("\nThen sort the array and count the " +
                "requested position from the largest value at the top\n");
        QuickSort(ref xdata);
        DisplayElements(ref xdata, 'a', "QuickSort");

        //////

        Console.WriteLine("\n\nTesting to find the n-th largest " +
                "value in a random array\n\nOriginal Data (method 2): \n");
        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");

        int nthMathIndex2 = 4;

        int nthMinValue2 = NthLargest2(xdata, nthMathIndex2);

        Console.WriteLine("\nThe " + nthMathIndex2 +
           " largest value in the array above is: " +
           nthMinValue2 + "\n");

        Console.WriteLine("Verifying result... \nFirst verify " +
                "that original data array is not changed.\n");
        DisplayElements(ref xdata, 'b', "");
        Console.WriteLine("\nThen sort the array and count the " +
                "requested position from the smallest value at the bottom\n");
        QuickSort(ref xdata);
        DisplayElements(ref xdata, 'a', "QuickSort");

        Console.WriteLine("\n\nTesting to find the m-th smallest " +
                "value in a random array\n\nOriginal Data (method 1): \n");
        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");

        int mthMathIndex1 = 3;

        int mthMinValue1 = MthSmallest1(xdata, mthMathIndex1);

        Console.WriteLine("\nThe " + mthMathIndex1 +
                " smallest value in the array above is: " +
                mthMinValue1 + "\n");

        Console.WriteLine("Verifying result... \nFirst verify " +
                "that original data array is not changed.\n");
        DisplayElements(ref xdata, 'b', "");
        Console.WriteLine("\nThen sort the array and count the " +
                "requested position from the smallest value at the bottom\n");
        QuickSort(ref xdata);
        DisplayElements(ref xdata, 'a', "QuickSort");

        Console.WriteLine("\n\nTesting to find the m-th smallest " +
                "value in a random array\n\nOriginal Data (method 2): \n");
        MixDataUp(ref xdata, rdn);
        DisplayElements(ref xdata, 'b', "");

        int mthMathIndex2 = 3;

        int mthMinValue2 = MthSmallest2(xdata, mthMathIndex2);

        Console.WriteLine("\nThe " + mthMathIndex2 +
           " smallest value in the array above is: " +
           mthMinValue2 + "\n");

        Console.WriteLine("Verifying result... \nFirst " +
                "verify that original data array is not changed.\n");
        DisplayElements(ref xdata, 'b', "");
        Console.WriteLine("\nThen sort the array and count the " +
                "requested position from the smallest value at the bottom\n");
        QuickSort(ref xdata);
        DisplayElements(ref xdata, 'a', "QuickSort");

        Console.WriteLine("\n\nTesting sorting utitlities\n");
        int[] sortedInts = new int[] { 1, 5, 20, 50 };
        int[] unsortedInts = new int[] { 35, 2, 56, 1 };
        int[] reversedInts = new int[] { 10, 9, 8, 7 };
        string[] sortedStrings = new string[] { "monkey", "duck", "bird" };
        string[] unsortedStrings = new string[] { "duck", "monkey", "dog" };
        string[] reversedStrings = new string[] { "dog", "duck", "monkey" };

        Console.WriteLine(IsSorted(sortedInts));                // True
        Console.WriteLine(IsSortedDescending(sortedInts));      // False
        Console.WriteLine(IsSorted(unsortedInts));              // False
        Console.WriteLine(IsSortedDescending(unsortedInts));    // False
        Console.WriteLine(IsSorted(reversedInts));              // False
        Console.WriteLine(IsSortedDescending(reversedInts));    // True
        Console.WriteLine(IsSorted(sortedStrings));             // True
        Console.WriteLine(IsSortedDescending(sortedStrings));   // False
        Console.WriteLine(IsSorted(unsortedStrings));           // False
        Console.WriteLine(IsSortedDescending(unsortedStrings)); // False
        Console.WriteLine(IsSorted(reversedStrings));           // False
        Console.WriteLine(IsSortedDescending(reversedStrings)); // True
        Console.ReadLine();

        Console.WriteLine("\n\nTesting Conversion from List to Array\n");
        List<string> myList = new List<string>();
        myList.Add("dog");
        myList.Add("cat");
        myList.Add("duck");
        myList.Add("monkey");
        myList.Add("bird");
        string[] myString = myList.ToArray();
        foreach (string s in myString)
            Console.WriteLine(s);

        Console.WriteLine("\n\nTesting Conversion from Array to List\n");
        string[] str = new string[] { "duck", "cat", "dog", "monkey", "bird" };
        List<string> myOtherList = new List<string>(str);
        myOtherList = str.ToList();
        foreach (string s in myOtherList)
            Console.WriteLine(s);

        Console.ReadLine();
    }
}
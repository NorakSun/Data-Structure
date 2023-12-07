
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class SortingUtility<T> where T : IComparable<T>
    {
        public static void QuickSortAscending(List<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            QuickSort(list, 0, list.Count - 1, true);
        }

        public static void QuickSortDescending(List<T> list)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            QuickSort(list, 0, list.Count - 1, false);
        }

        private static void QuickSort(List<T> list, int low, int high, bool ascending)
        {
            if (low < high)
            {
                int partitionIndex = Partition(list, low, high, ascending);

                QuickSort(list, low, partitionIndex - 1, ascending);
                QuickSort(list, partitionIndex + 1, high, ascending);
            }
        }

        private static int Partition(List<T> list, int low, int high, bool ascending)
        {
            T pivot = list[high];
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if ((ascending && list[j].CompareTo(pivot) <= 0) || (!ascending && list[j].CompareTo(pivot) >= 0))
                {
                    i++;

                    T temp = list[i];
                    list[i] = list[j];
                    list[j] = temp;
                }
            }

            T temp1 = list[i + 1];
            list[i + 1] = list[high];
            list[high] = temp1;

            return i + 1;
        }
    }

}
/*class Program
{
    static void Main()
    {
        List<int> intList = new List<int> { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 };

        // Sorting in Ascending Order
        Console.WriteLine("Original List: " + string.Join(", ", intList));
        SortingUtility<int>.QuickSortAscending(intList);
        Console.WriteLine("Ascending Order: " + string.Join(", ", intList));

        // Sorting in Descending Order
        SortingUtility<int>.QuickSortDescending(intList);
        Console.WriteLine("Descending Order: " + string.Join(", ", intList));
    }
}*/

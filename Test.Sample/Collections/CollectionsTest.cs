using NUnit.Framework;
using System.Collections;

namespace Test.Sample.Collections
{
    [TestFixture]
    public class CollectionsTest
    {
        [Test]
        public void CollectionsTypes()
        {
            int[] nums = new int[] { 1, 2, 3, 10, 12, 23 };
            nums[2] = 4;
            foreach (int l in nums)
            {
                Console.WriteLine($"The value of array element is: '{l}'");
            }

            Array.Reverse(nums);
            foreach (int l in nums)
            {
                Console.WriteLine($"The sorted value of array element is: '{l}'");
            }

            Array.Sort(nums);
            Array.Clear(nums, 3, 3);

            foreach (int l in nums)
            {
                Console.WriteLine($"The sorted value of array element is: '{l}'");
            }

            Console.WriteLine("-------------------------------------------------------------------------------------");
            // List
            List<string> list = new List<string> { "30", "40", "50" };
            list.Add("10");
            list.Add("20");
            List<int> list2 = new List<int>();
            foreach (string l in list)
            {
                list2.Add(list.IndexOf(l));
            }

            //Array List
            ArrayList arr = new ArrayList();
            arr.Add("Hello");
            arr.Add(20);
            arr.Add(35.5);
            foreach (var a in arr)
            {
                Console.WriteLine($"The value '{a}' is in the Index of '{arr.IndexOf(a)}'");
            }

            Console.WriteLine("-------------------------------------------------------------------------------------");

            // Dictionary

            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("Ten", 10);
            dict.Add("Twenty", 20);
            dict.Add("Thirty", 30);
            dict.Add("Thirty Five", 35);

            foreach (KeyValuePair<string, int> a in dict)
            {
                Console.WriteLine($"The Key '{a.Key}' has the value as '{a.Value}'");
            }
            Console.WriteLine("-------------------------------------------------------------------------------------");

            List<int> ValuesList = dict.Values.ToList();

            foreach (int a in ValuesList)
            {
                Console.WriteLine($"The value '{a}' is in the Index of '{ValuesList.IndexOf(a)}'");
            }
            Console.WriteLine("-------------------------------------------------------------------------------------");

            // SortedList

            SortedList<string, int> srtList = new SortedList<string, int>();
            srtList.Add("Ten", 10);
            srtList.Add("Thirty Five", 35);
            srtList.Add("Twenty", 20);
            srtList.Add("Thirty", 30);

            foreach (KeyValuePair<string, int> a in srtList)
            {
                Console.WriteLine($"The Key '{a.Key}' has the value as '{a.Value}'");
            }
            Console.WriteLine("-------------------------------------------------------------------------------------");

            //Queue

            Queue queue = new Queue();
            queue.Enqueue(10);
            queue.Enqueue("Hello");
            queue.Enqueue(35);
            queue.Dequeue();

            foreach (var a in queue)
            {
                Console.WriteLine($"The value '{a}' is in the type of {a.GetType()}");
            }
            Console.WriteLine("-------------------------------------------------------------------------------------");

            //Stack
            Stack stack = new Stack();
            stack.Push(10);
            stack.Push("Hello");
            stack.Push(3000);
            Console.WriteLine("Next element to get removed: " + stack.Peek());
            stack.Pop();
            foreach (var a in queue)
            {
                Console.WriteLine($"The value '{a}' is in the type of {a.GetType()}");
            }
            Console.WriteLine("-------------------------------------------------------------------------------------");

            //BitArray
            BitArray bitarr = new BitArray(new int[] { 100, 32, 56 });
            Console.WriteLine(bitarr.Count);
            Console.WriteLine(bitarr.Length);
            foreach (var a in bitarr)
            {
                Console.WriteLine($"The value '{a}' is in the type of {a.GetType()}");
            }
            Console.WriteLine("-------------------------------------------------------------------------------------");

            //HashTable
            Hashtable hash = new Hashtable();
            hash.Add(1, "Hello");
            hash.Add("Hi", 32);

            foreach (DictionaryEntry a in hash)
            {
                Console.WriteLine($"The Key '{a.Key}' has the value as '{a.Value}'");
            }
            Console.WriteLine("-------------------------------------------------------------------------------------");
        }
    }
}

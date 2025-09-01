using System.Collections;

namespace Assignment_2
{
    internal class Program
    {

        #region question 4
        static bool IsBalanced(string str)
        {
            // push to stack if opening and pop if closing the same as the top
            // should be empty at the end
            // check to not pop an empty stack
            Stack<char> stack = new Stack<char>();

            foreach (char ch in str)
            {
                if (ch == '(' || ch == '[' || ch == '{')
                {
                    stack.Push(ch);
                }
                else if (ch == ')' || ch == ']' || ch == '}')
                {
                    if (stack.Count == 0) return false;

                    char top = stack.Pop();

                    if ((ch == ')' && top != '(') ||
                        (ch == ']' && top != '[') ||
                        (ch == '}' && top != '{'))
                    {
                        return false;
                    }
                }
            }
            return stack.Count == 0;
        }
        #endregion
        #region question 5
        static T[] RemoveDuplicates<T>(T[] arr)
        {
            HashSet<T> unique = new HashSet<T>(arr);
            T[] result = new T[unique.Count];
            unique.CopyTo(result);
            return result;
        }
        #endregion
        #region question 6
        static void RemoveOddNumbers(ArrayList list)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                int num = (int)list[i]; 
                if (num % 2 != 0)
                {
                    list.RemoveAt(i);
                }
            }
        }
        #endregion
        #region question 8
        // Function to push integers to the stack
        static Stack<int> PushIntegers(int[] numbers)
        {
            Stack<int> stack = new Stack<int>();
            foreach (int num in numbers)
            {
                stack.Push(num);
            }
            return stack;
        }

        // Function to search for a target in the stack
        static void SearchTarget(Stack<int> stack, int target)
        {
            int count = 0;
            bool found = false;

            foreach (int item in stack)
            {
                count++;
                if (item == target)
                {
                    Console.WriteLine($"Target was found successfully and the count = {count}");
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Target was not found");
            }
        }
        #endregion
        #region question 9
        static List<int> FindIntersection(int[] arr1, int[] arr2)
        {
            List<int> result = new List<int>();
            Dictionary<int, int> freq = new Dictionary<int, int>();

            foreach (int num in arr1)
            {
                if (freq.ContainsKey(num))
                    freq[num]++;
                else
                    freq[num] = 1;
            }

            foreach (int num in arr2)
            {
                if (freq.ContainsKey(num) && freq[num] > 0)
                {
                    result.Add(num);
                    freq[num]--; 
                }
            }

            return result;
        }
        #endregion
        #region question 10
        static List<int> FindSubArrayWithSum(List<int> arr, int target)
        {
            int start = 0, currentSum = 0;

            for (int end = 0; end < arr.Count; end++)
            {
                currentSum += arr[end];

                while (currentSum > target && start <= end)
                {
                    currentSum -= arr[start];
                    start++;
                }

                if (currentSum == target)
                {
                    List<int> subArray = new List<int>();
                    for (int i = start; i <= end; i++)
                        subArray.Add(arr[i]);

                    return subArray;
                }
            }

            return new List<int>();
        }
        #endregion
        #region question 11
        static Queue<int> ReverseFirstK(Queue<int> q, int k)
        {
            if (q.Count == 0 || k > q.Count || k <= 0)
                return q;

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < k; i++)
            {
                stack.Push(q.Dequeue());
            }

            while (stack.Count > 0)
            {
                q.Enqueue(stack.Pop());
            }

            int remaining = q.Count - k;
            for (int i = 0; i < remaining; i++)
            {
                q.Enqueue(q.Dequeue());
            }

            return q;
        }
        #endregion
        static void Main(string[] args)
        {
            #region question 1
            {   
                bool isparsed  = false;
                int n = 0 , q = 0 ;

                do
                {
                    Console.WriteLine("enter n");
                    isparsed = int.TryParse(Console.ReadLine(), out n);
                }
                while (!isparsed);
                do
                {
                    Console.WriteLine("enter q");
                    isparsed = int.TryParse(Console.ReadLine(), out q);
                }
                while (!isparsed);

                
                int[] arr = new int[n];
                Console.WriteLine("enter the array");
                for (int i = 0; i < n; i++)
                {
                    do
                    {
                        isparsed = int.TryParse(Console.ReadLine(), out arr[i]);
                    }
                    while (!isparsed);
                }

                Array.Sort(arr); // sorting the array so can find the number of elements less than required linearly faster
                Console.WriteLine("enter number to search for");
                for (int i = 0; i < q; i++)
                {
                    int x = int.Parse(Console.ReadLine());
                    int idx = Array.BinarySearch(arr, x + 1);
                    if (idx < 0) idx = ~idx; 
                    int result = n - idx;
                    Console.WriteLine(result);
                }
            }
            #endregion
            #region question 2
            {
                bool isparsed = false;
                int n = 0;
                do
                {
                    Console.WriteLine("enter n");
                    isparsed = int.TryParse(Console.ReadLine(), out n);
                }
                while (!isparsed);

                int[] arr = new int [n];
                Console.WriteLine("enter array elements");
                for(int i = 0; i < n; i++)
                {
                    do
                    {

                        isparsed = int.TryParse(Console.ReadLine(), out arr[i]);
                    }
                    while (!isparsed);
                }
                
                bool isPalindrome = true;
                for (int i = 0; i < n / 2; i++)
                {
                    if (arr[i] != arr[n - i - 1])
                    {
                        isPalindrome = false;
                        break;
                    }
                }

                Console.WriteLine(isPalindrome ? "YES" : "NO");
            }
            #endregion
            #region question 3
            {
                Queue<int> q = new Queue<int>();
                bool isparsed = false;
                int n = 0;

                do
                {
                    Console.Write("Enter number of elements in queue: ");
                    isparsed = int.TryParse(Console.ReadLine(), out n);
                }
                while (!isparsed);

                Console.WriteLine("Enter the elements:");
                for (int i = 0; i < n; i++)
                {
                    int element = int.Parse(Console.ReadLine());
                    q.Enqueue(element);
                }

                Console.WriteLine("Original Queue: " + string.Join(", ", q));

                Stack<int> stack = new Stack<int>();

                while (q.Count > 0)
                {
                    stack.Push(q.Dequeue());
                }

                while (stack.Count > 0)
                {
                    q.Enqueue(stack.Pop());
                }

                Console.WriteLine("Reversed Queue: " + string.Join(", ", q));
            }
            #endregion
            #region question 4
            {
                Console.Write("Enter a string of parentheses: ");
                string input = Console.ReadLine();

                if (IsBalanced(input))
                    Console.WriteLine("Balanced");
                else
                    Console.WriteLine("Not Balanced");
            }
            #endregion
            #region question 5
            {
                bool isparsed = false;
                int n = 0;
                Console.Write("Enter size of array: ");
                do
                {
                    isparsed = int.TryParse(Console.ReadLine(), out n);
                }
                while (!isparsed);

                int[] numbers = new int[n];
                Console.WriteLine("Enter array elements:");
                for (int i = 0; i < n; i++)
                {
                    numbers[i] = int.Parse(Console.ReadLine());
                }

                int[] noDuplicates = RemoveDuplicates(numbers);

                Console.WriteLine("Array after removing duplicates:");
                foreach (var num in noDuplicates)
                {
                    Console.Write(num + " ");
                }
            }
            #endregion
            #region question 6
            {
                Console.Write("Enter size of array list: ");
                bool isparsed = false;
                int n = 0;
                do
                {
                    isparsed = int.TryParse(Console.ReadLine(), out n);
                }
                while (!isparsed);

                ArrayList numbers = new ArrayList();
                Console.WriteLine("Enter elements:");
                for (int i = 0; i < n; i++)
                {
                    numbers.Add(int.Parse(Console.ReadLine()));
                }

                RemoveOddNumbers(numbers);

                Console.WriteLine("ArrayList after removing odd numbers:");
                foreach (var num in numbers)
                {
                    Console.Write(num + " ");
                }
            }
            #endregion
            #region question 7
            {
                // Queue that can hold any type (int, string, double, etc.)
                Queue<object> queue = new Queue<object>();

                // Insert different types of data
                queue.Enqueue(1);          // int
                queue.Enqueue("Apple");    // string
                queue.Enqueue(5.28);       // double

                Console.WriteLine("Queue elements:");

                foreach (var item in queue)
                {
                    Console.WriteLine(item + " (Type: " + item.GetType().Name + ")");
                }
            }
            #endregion
            #region question 8
            {
                // Example: pushing these numbers into the stack
                int[] numbers = { 10, 20, 30, 40, 50 };

                Stack<int> stack = PushIntegers(numbers);

                Console.Write("Enter target to search: ");
                int target = int.Parse(Console.ReadLine());

                SearchTarget(stack, target);
            }
            #endregion
            #region question 9
            {
                Console.Write("Enter size of first array: ");
                int n1 = int.Parse(Console.ReadLine());

                Console.Write("Enter size of second array: ");
                int n2 = int.Parse(Console.ReadLine());

                int[] arr1 = new int[n1];
                int[] arr2 = new int[n2];

                Console.WriteLine("Enter elements of first array:");
                for (int i = 0; i < n1; i++)
                    arr1[i] = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter elements of second array:");
                for (int i = 0; i < n2; i++)
                    arr2[i] = int.Parse(Console.ReadLine());

                List<int> intersection = FindIntersection(arr1, arr2);

                Console.WriteLine("Intersection:");
                Console.WriteLine("[" + string.Join(", ", intersection) + "]");
            }
            #endregion
            #region question 10
            {
                List<int> arr = new List<int> { 1, 2, 3, 7, 5 };

                Console.Write("Enter target sum: ");
                int target = int.Parse(Console.ReadLine());

                List<int> result = FindSubArrayWithSum(arr, target);

                if (result.Count > 0)
                    Console.WriteLine("Subarray with sum {0}: [{1}]", target, string.Join(", ", result));
                else
                    Console.WriteLine("No subarray found with sum " + target);
            }
            #endregion
            #region question 11
            {
                Queue<int> q = new Queue<int>();
                Console.WriteLine("Enter elements of queue separated by space:");
                string[] input = Console.ReadLine().Split();

                foreach (string s in input)
                    q.Enqueue(int.Parse(s));

                Console.Write("Enter K: ");
                int k = int.Parse(Console.ReadLine());

                Queue<int> result = ReverseFirstK(q, k);

                Console.WriteLine("Output: [" + string.Join(", ", result) + "]");
            }
            #endregion
        }
    }
}

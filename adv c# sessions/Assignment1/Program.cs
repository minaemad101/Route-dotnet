using System.Collections;

namespace Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region question 2
            ArrayList arr = new ArrayList() { 1, 2, 3, 4, 5 };
            MyReverse(arr);
            foreach (var ff in arr) Console.WriteLine(ff);
            #endregion
            Console.WriteLine();
            #region question 3
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            List<int> evens = GetEvens(list);
            foreach (int ff in evens) Console.WriteLine(ff);
            #endregion
            Console.WriteLine();
            #region question 4
            FixedSizeList<int?> fsl = new FixedSizeList<int?>(3);
            fsl.Add(1);
            fsl.Add(2);
            fsl.Add(3);
            fsl.Add(4);
            #endregion
            #region question 5
            string test = "aabccddeffgg";
            int pos = FirstUniqueChar(test);
            if(pos==-1) Console.WriteLine("no unique characters");
            else
            {
                Console.WriteLine($"the cahracter {test[pos]} at {pos} is the first unique");
            }
            #endregion

        }

        static void MyReverse(ArrayList arrayList)
        {
            int i = arrayList.Count;
            while (i > 0) {
                arrayList.Add(arrayList[i - 1]);
                arrayList.RemoveAt(i-1);
                i--;
            }
        }
        static List<int> GetEvens(List<int> list)
        {
            List<int> evens = new List<int>();
            foreach (int i in list)
            {
                if (i % 2 == 0)
                    evens.Add(i);
            }
            return evens;
        }
        public static int FirstUniqueChar(string s)
        {

            Dictionary<char, int> freq = new Dictionary<char, int>();
            foreach (char c in s)
            {
                if (freq.ContainsKey(c))
                    freq[c]++;
                else
                    freq[c] = 1;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (freq[s[i]] == 1)
                    return i;
            }

            return -1;
        }
    }
}

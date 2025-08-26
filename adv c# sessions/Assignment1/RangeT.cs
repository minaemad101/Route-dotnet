using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    internal class RangeT<T> where T : IComparable<T>
    {
        public T Min { get; set; }
        public T Max { get; set; }
        public RangeT (T min, T max) 
        {
            if(min.CompareTo(max) <= 0)
            {
                Min = min;
                Max = max;
            }
            else
            {
                Min = max; Max = min;
            }
        }
        public RangeT(){}
        public bool IsInRange(T value)
        {
            return (value.CompareTo(Max)<=0 && value.CompareTo(Min)>=0);
            
        }
        public string Length()
        {
            return $"this starts at {Min} and end at {Max}"; // the difference is not working cus T is not really defined
        }
    }
}

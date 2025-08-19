using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_6
{

    internal class _3DPoint:ICloneable,IComparable< _3DPoint>
    {
        private int x;
        private int y;
        private int z;

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        // constructors
        public _3DPoint() :this(0,0,0){ }
        public _3DPoint(int x, int y, int z) 
        {
            X = x;
            Y = y;
            Z = z;
        }
        // helper functions
        public static _3DPoint ReadPoint()
        {
            int x, y, z;
            Console.Write("Enter X: ");
            while (!int.TryParse(Console.ReadLine(), out x))
                Console.Write("Invalid input! Enter X again: ");

            Console.Write("Enter Y: ");
            while (!int.TryParse(Console.ReadLine(), out y))
                Console.Write("Invalid input! Enter Y again: ");

            Console.Write("Enter Z: ");
            while (!int.TryParse(Console.ReadLine(), out z))
                Console.Write("Invalid input! Enter Z again: ");

            return new _3DPoint(x, y, z);
        }

        // overriden functions and overloaded operators and implemented interfaces
        public override string ToString()
        {
            return $"Point Coordinates: ({X}, {Y}, {Z})";
        }

        public override bool Equals(object? obj)
        {
            if(obj == null || !(obj is _3DPoint)) return false;
            return X == ((_3DPoint)obj).X && Y == ((_3DPoint)obj).Y && Z == ((_3DPoint)obj).Z ; 
        }

        public static bool operator ==(_3DPoint p1, _3DPoint p2)
        { 
            return p1.Equals(p2);            
        }
        public static bool operator !=(_3DPoint p1, _3DPoint p2)
        {
            return !(p1==p2);
        }


        public object Clone()
        {
            return new _3DPoint(X, Y, Z);
        }

        public int CompareTo(_3DPoint other)
        {
            if (X != other.X) return X.CompareTo(other.X);
            return Y.CompareTo(other.Y);
        }
    }
}

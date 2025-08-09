using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assignment_5
{
    internal interface iShape
    {
        public double Area { get; }
        public void DisplayShapeInfo();
    }

    internal interface iCircle : iShape
    {
        public double Radius {  get; set; }
    }
    internal interface iRectangel: iShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

    }
}

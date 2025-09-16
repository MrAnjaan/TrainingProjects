using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2StudentMarksAnalyser
{
    internal class Student
    {
        public string name;
        public int[] marks = new int[5];// size ni
        public int total
        {
            get
            {
                int sum = 0;
                foreach (var mark in marks)
                {
                    sum += mark;
                }
                return sum;
            }
        }
    }
}

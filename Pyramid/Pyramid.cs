using System;
using System.Linq;

/*
 
    *
   ***
  *****
 *******
*********

ACCEPTANCE CRITERIA:
Write a script to output this pyramid on console (with leading spaces)

*/
namespace Pyramid
{
    public class Program
    {
        private static void Pyramid(int height)
        {
            for (int row = 1; row <= height; row++)
            {
                string layer = string.Join(" ", Enumerable.Repeat("*", row));
                Console.WriteLine(layer.PadLeft(height - row + layer.Length));
            }
        }

        public static void Main(string[] args)
        {
            Pyramid(10);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This \"Problem List\" application details a list of problems encountered through the years.");
            Console.WriteLine("These problems are all problems given to me thru some of the interviews that I've taken" + '\n');

            string oSelectedChoice = string.Empty;
            while (DisplayTheList(out oSelectedChoice))
            {
                RunSelectedProblem(oSelectedChoice);
            }

        }

        static bool DisplayTheList(out string oSelection)
        {
            Console.WriteLine("Select a Test Case from the Following List:");
            Console.WriteLine(" 1-Determine if an integer is in a sorted array of integers");
            Console.WriteLine(" 2-Determine if 3 integer values represent equilateral (3 equal sides),");
            Console.WriteLine("   isoceles (2 equal sides) or scalene triangle.");
            Console.WriteLine(" 3-Parse an input string for a valid set of '({[ ... ]})");
            Console.WriteLine(" 4-Enter integers to sort.");
            // Console.WriteLine(" 5-Next problem to Add");
            Console.WriteLine("");
            Console.WriteLine(" Any other key to exit:");

            var selectedChoice = Console.ReadLine();
            oSelection = selectedChoice;

            return selectedChoice != "1" ?  
                   selectedChoice != "2" ?
                   selectedChoice != "3" ?
                   selectedChoice == "4" /*?*/      // To add entry #1 UNCOMMENT the question mark, change equality comparison from '==' to not equal '!='
                   // selectedChoice == "5"         //              #2 Add 'selectedChoice == "5"
                   : true : true  : true;           //              #3 ADD A ' : true' to the front of this line to keep the order
        }

        static void RunSelectedProblem(string inChoice)
        {
            switch (inChoice)
            {
                case "1":
                    IntegerInArray();
                    break;
                case "2":
                    Triangle();
                    break;
                case "3":
                    break;
                default:
                    break;
            }
        }

        #region - Integer value in an Integer Array
        static void IntegerInArray()
        {
            int[] int_array = new int[] { 0, 2, 8, 10, 12, 13, 15, 17, 19, 20, 22, 23, 25 };
            string oStr = string.Empty;

            for (int i = 0; i < int_array.Length; i++)
               oStr += oStr == string.Empty ? "Here is your list of integers: \n" + int_array[i].ToString() : ", " + int_array[i].ToString();
            
            Console.WriteLine(oStr + '\n');
            Console.Write("Select a Number:");
            var choice = Console.ReadLine();

            Console.WriteLine("Choose your search method:");
            Console.WriteLine("  1-Use List.Contains:");
            Console.WriteLine("  2-Binary Search Algorithm: \n");
            // Other Search Algorithms: Sequential, Hashing

            var searchMethod = Console.ReadLine();
            bool result = false;
            switch (searchMethod)
            {
                case "1":
                    result = UseListContains(choice, int_array);
                    break;
                case "2":
                    result = UseBinarySearch(choice, int_array);
                    break;
                case "3":
                    break;
                default:
                    break;
            }

            string oResult = string.Empty;

            oResult = "Your selection " + choice + " was NOT FOUND!!\n\n";
            if (result == true)
                oResult = "Your selection " + choice + " was found on the list!!" + '\n' + '\n';

            Console.WriteLine(oResult);
        }

        // Use a List<T> object
        static bool UseListContains(string inValue, int[] inArray)
        {
            List<int> _list = inArray.ToList<int>();
            return _list.Contains(Convert.ToInt32(inValue));
        }

        // Use a Binary Search Algorithm
        // - A binary search searches a specific 'key' against a sorted list/array
        // - the 'key' is compared against the middle entry in the array
        // - if key < middle entry, then key is in the lower array
        // - if key > middle entry, then key is in the upper array

        static bool UseBinarySearch(string inValue, int[] inArray)
        {
            return BinarySearch(Convert.ToInt32(inValue), inArray, 0, inArray.Length - 1) > 0;
        }
        static int BinarySearch(int inKey, int[] inArray, int minIdx, int maxIdx)
        {
            if (minIdx > maxIdx)
                return 0;
            else
            {
                int midIdx = (minIdx + maxIdx) / 2;
                int midValue = inArray[midIdx];

                if (midValue > inKey)
                    return BinarySearch(inKey, inArray, minIdx, midIdx-1);
                else if (midValue < inKey)
                    return BinarySearch(inKey, inArray, midIdx+1, maxIdx);
                else if (inKey == midValue)
                    return midIdx;
            }

            return 0;
        }

        #endregion

        #region - Triangle Type (Isosceles, Equilateral, Scalene)
        static void Triangle()
        {
            Console.WriteLine("Enter 3 values representing 3 sides of a triangle:");
            Console.Write("Value 1:");
            var val1 = Console.ReadLine();
            Console.Write("Value 2:");
            var val2 = Console.ReadLine();
            Console.Write("Value 3:");
            var val3 = Console.ReadLine();

            Console.WriteLine("Processing your values!!");
            Console.WriteLine(ProcessTriangleValues(Convert.ToInt32(val1), Convert.ToInt32(val2), Convert.ToInt32(val3)) + "\n\n");
        }

        static string ProcessTriangleValues(int inSide1, int inSide2, int inSide3)
        {
            // Step 1 - determine if any of the sides are 0
            if (inSide1 < 1 || inSide2 < 1 || inSide3 < 1)
                return "Invalid values";

            // Triangle inequality Theorem - "the sum of the lengths of any 2 sides of a triangle must be greater than the third side"
            if (((inSide2 + inSide3) < inSide1) || ((inSide1 + inSide3) < inSide2) || ((inSide1 + inSide2) < inSide3))
                return "Triangle Inequality Theorem NOT SATISFIED";

            // determine if all the sides are equal
            if ((inSide1 == inSide2) && (inSide1 == inSide3))
                return "Equilateral Triangle";

            // determine if 2 sides are equal
            if (inSide1 == inSide2 || inSide2 == inSide3 || inSide3 == inSide1)
                return "Isosceles Triangle";

            // otherwise, all sides have different lengths
            return "Scalene Triangle";
        }
        #endregion

        #region - Valid set of Order/Grouping/Indexing characters - {[()]}
        #endregion

        #region - Sorting algorithm
        #endregion



    }
}

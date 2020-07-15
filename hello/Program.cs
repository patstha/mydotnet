using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

    /*
     * Complete the 'fetchItemsToDisplay' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. 2D_STRING_ARRAY items
     *  2. INTEGER sortParameter
     *  3. INTEGER sortOrder
     *  4. INTEGER itemsPerPage
     *  5. INTEGER pageNumber
     */

    public static List<string> fetchItemsToDisplay(List<List<string>> items, int sortParameter, int sortOrder, int itemsPerPage, int pageNumber)
    {
        // foreach (var x in items)
        // {
        //     foreach (var y in x)
        //     {
        //         Console.Write(y);
        //         Console.Write(" ");
        //     }
        //     Console.WriteLine();
        // }
        // Console.WriteLine($"{items.Count}");
        // Console.WriteLine($"{sortParameter}");
        // Console.WriteLine($"{sortOrder}");
        // Console.WriteLine($"{itemsPerPage}");
        // Console.WriteLine($"{pageNumber}");
        IEnumerable<List<string>> orderedItems;
        if (sortOrder == 0)
        {
            if (sortParameter > 0)
            {
                orderedItems = items.OrderBy(x => Int32.Parse(x[sortParameter]));
            } else 
            {
                orderedItems = items.OrderBy(x => x[sortParameter]);
            }
        }
        else
        {
            if (sortParameter > 0)
            {
                orderedItems = items.OrderByDescending(x => Int32.Parse(x[sortParameter]));
            } else 
            {
                orderedItems = items.OrderByDescending(x => x[sortParameter]);
            }
        }
        IEnumerable<List<string>> filteredItems = orderedItems.Skip(pageNumber * itemsPerPage).Take(itemsPerPage);
        List<string> result = new List<string>();
        foreach (var item in filteredItems)
        {
            result.Add(item[0]);
        }
        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("potato.txt", true);

        // int itemsRows = 2;
        // int itemsColumns = 3;

        List<List<string>> items = new List<List<string>>();

        // for (int i = 0; i < itemsRows; i++)
        // {
        //     items.Add(Console.ReadLine().TrimEnd().Split(' ').ToList());
        // }

        items.Add("p1 1 2".Split(' ').ToList());
        items.Add("p2 2 1".Split(' ').ToList());

        int sortParameter = 0;

        int sortOrder = 0;

        int itemsPerPage = 1;

        int pageNumber = 0;

        // items.Add("owjevtkuyv 58584272 62930912".Split(' ').ToList());
        // items.Add("rpaqgbjxik 9425650 96088250".Split(' ').ToList());
        // items.Add("dfbkasyqcn 37469674 46363902".Split(' ').ToList());
        // items.Add("vjrrisdfxe 18666489 88046739".Split(' ').ToList());

        // int sortParameter = 1;

        // int sortOrder = 0;

        // int itemsPerPage = 1;

        // int pageNumber = 1;

        List<string> result = Result.fetchItemsToDisplay(items, sortParameter, sortOrder, itemsPerPage, pageNumber);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}

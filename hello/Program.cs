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
     * Complete the 'bestTrio' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts UNWEIGHTED_INTEGER_GRAPH friends as parameter.
     */

    /*
     * For the unweighted graph, <name>:
     *
     * 1. The number of nodes is <name>Nodes.
     * 2. The number of edges is <name>Edges.
     * 3. An edge exists between <name>From[i] and <name>To[i].
     *
     */

    public static int bestTrio(int friendsNodes, List<int> friendsFrom, List<int> friendsTo)
    {
        int result = -1;
        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter("tomato.txt", true);

        string[] friendsNodesEdges = "6 6".TrimEnd().Split(' ');

        int friendsNodes = Convert.ToInt32(friendsNodesEdges[0]);
        int friendsEdges = Convert.ToInt32(friendsNodesEdges[1]);

        List<int> friendsFrom = new List<int>{1, 2, 2, 3, 4, 5};
        List<int> friendsTo = new List<int>{2, 4, 5, 5, 5, 6};

        // for (int i = 0; i < friendsEdges; i++)
        // {
        //     string[] friendsFromTo = Console.ReadLine().TrimEnd().Split(' ');

        //     friendsFrom.Add(Convert.ToInt32(friendsFromTo[0]));
        //     friendsTo.Add(Convert.ToInt32(friendsFromTo[1]));
        // }

        int result = Result.bestTrio(friendsNodes, friendsFrom, friendsTo);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

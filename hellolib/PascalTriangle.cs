namespace hellolib;

public class PascalTriangle
{
    public static List<List<int>> GeneratePascalsTriangle(int rows)
    {
        var triangle = new List<List<int>>();

        for (int i = 0; i < rows; i++)
        {
            var row = new List<int> { 1 };

            for (int j = 1; j < i; j++)
            {
                row.Add(triangle[i - 1][j - 1] + triangle[i - 1][j]);
            }

            if (i > 0)
            {
                row.Add(1);
            }

            triangle.Add(row);
        }

        return triangle;
    }
}

namespace hellolib;

public static class PascalTriangle
{
    public static List<List<int>> GeneratePascalsTriangle(int rows)
    {
        List<List<int>> triangle = [];

        for (int i = 0; i < rows; i++)
        {
            List<int> row = [1];

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

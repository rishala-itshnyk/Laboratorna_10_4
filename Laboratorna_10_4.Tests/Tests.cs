namespace Laboratorna_10_4.Tests;

[TestFixture]
public class Tests
{
    [Test]
    public void FindMaxInRow()
    {
        int[,] matrix = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

        int max = Program.FindMaxInRow(matrix, 1);

        Assert.AreEqual(6, max);
    }
    
    [Test]
    public void Write()
    {
        string fileName = "test_matrix.txt";
        int[,] matrix = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

        Program.Write(fileName, matrix);

        string expectedOutput = "3 3\n1 2 3 3\n4 5 6 6\n7 8 9 9\n";
        Assert.AreEqual(expectedOutput, File.ReadAllText(fileName));
    }
}
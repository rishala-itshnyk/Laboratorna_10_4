using System;
using System.IO;

public class Program
{
    static void Main()
    {
        Console.WriteLine("Введіть ім'я вихідного файлу:");
        string outputFileName = Console.ReadLine();

        ProcessMatrixFile(outputFileName);

        Console.WriteLine("Операція завершена успішно.");
    }

    public static void ProcessMatrixFile(string outputFileName)
    {
        try
        {
            int[,] matrix = Read();

            Write(outputFileName, matrix);

            Console.WriteLine("Максимальні значення записано у новий файл.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    static int[,] Read()
    {
        Console.WriteLine("Введіть кількість рядків матриці:");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Введіть кількість стовпців матриці:");
        int m = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, m];

        Console.WriteLine("Введіть елементи матриці:");

        for (int i = 0; i < n; i++)
        {
            string[] rowValues = Console.ReadLine().Split(' ');
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = int.Parse(rowValues[j]);
            }
        }

        return matrix;
    }


    public static void Write(string fileName, int[,] matrix)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            int n = matrix.GetLength(0);
            int m = matrix.GetLength(1);

            writer.WriteLine($"{n} {m}");

            for (int i = 0; i < n; i++)
            {
                int maxInRow = FindMaxInRow(matrix, i);
                for (int j = 0; j < m; j++)
                {
                    writer.Write($"{matrix[i, j]} ");
                }
                writer.WriteLine(maxInRow);
            }
        }
    }

    public static int FindMaxInRow(int[,] matrix, int row)
    {
        int max = matrix[row, 0];
        int m = matrix.GetLength(1);

        for (int j = 1; j < m; j++)
        {
            if (matrix[row, j] > max)
            {
                max = matrix[row, j];
            }
        }

        return max;
    }
}

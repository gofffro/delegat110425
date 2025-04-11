using System;

namespace MatrixApp
{
  internal class Program
  {
    private delegate Matrix DiagonalizeDelegate(Matrix matrix);
    static void Main(string[] args)
    {

      try
      {
        Console.Write("Матрица A");
        Matrix matrixA = CreateMatrix();
        Matrix cloneMatrixA = matrixA.DeepCopy();
        Console.WriteLine(matrixA);

        Console.Write("Матрица B");
        Matrix matrixB = CreateMatrix();
        Matrix cloneMatrixB = matrixB.DeepCopy();
        Console.WriteLine(matrixB);

        DiagonalizeDelegate diagonalize = (Matrix m) =>
        {
          double[,] array = new double[m.matrixRow, m.matrixColumn];
          for (int row = 0; row < m.matrixRow; ++row)
          {
            for (int column = 0; column < m.matrixColumn; ++column)
            {
              array[row, column] = m.matrix[row, column];
            }
          }

          double[,] diagonalizedArray = QRDecomposition.Diagonalize(array);

          Matrix diagonalizedMatrix = new Matrix(diagonalizedArray.GetLength(0), diagonalizedArray.GetLength(1));
          for (int row = 0; row < diagonalizedArray.GetLength(0); ++row)
          {
            for (int column = 0; column < diagonalizedArray.GetLength(1); ++column)
            {
              diagonalizedMatrix.matrix[row, column] = diagonalizedArray[row, column];
            }
          }

          return diagonalizedMatrix;
        };

        string menuMethod;
        while (true)
        {
          Console.WriteLine();
          Console.WriteLine($"Matrix A:\n{matrixA}\n");
          Console.WriteLine($"Matrix B:\n{matrixB}\n");
          Console.WriteLine("Меню:");
          Console.WriteLine("1 - Сложить матрицы");
          Console.WriteLine("2 - Умножить матрицы");
          Console.WriteLine("3 - Умножить A на число");
          Console.WriteLine("4 - Умножить B на число");
          Console.WriteLine("5 - Сравнить A и B (A > B)");
          Console.WriteLine("6 - Сравнить A и B (A < B)");
          Console.WriteLine("7 - Определитель A");
          Console.WriteLine("8 - Определитель B");
          Console.WriteLine("9 - GetHashCode A");
          Console.WriteLine("10 - GetHashCode B");
          Console.WriteLine("11 - Проверить A.Equals(B)");
          Console.WriteLine("12 - Обратная матрица A");
          Console.WriteLine("13 - Обратная матрица B");
          Console.WriteLine("14 - Демонстрация глубокого копирования");
          Console.WriteLine("15 - Найти след матриц (сумма элементов диагонали)");
          Console.WriteLine("16 - Привести матрицу A к диагональному виду");
          Console.WriteLine("17 - Привести матрицу B к диагональному виду");
          Console.WriteLine("0 - Выход");
          Console.Write("Ввод: ");
          menuMethod = Console.ReadLine();
          Console.Clear();

          switch (menuMethod)
          {
            case "0":
              Console.WriteLine("Программа завершила работу");
              return;
            case "1":
              Console.WriteLine("Сумма A + B:\n" + (cloneMatrixA + cloneMatrixB));
              break;
            case "2":
              Console.WriteLine("Произведение A * B:\n" + (cloneMatrixA * cloneMatrixB));
              break;
            case "3":
              Console.Write("Введите число - множитель для A: ");
              double scalarA = Convert.ToDouble(Console.ReadLine());
              Console.WriteLine("A * число:\n" + (cloneMatrixA * scalarA));
              break;
            case "4":
              Console.Write("Введите число - множитель для B: ");
              double scalarB = Convert.ToDouble(Console.ReadLine());
              Console.WriteLine("B * число:\n" + (cloneMatrixB * scalarB));
              break;
            case "5":
              Console.WriteLine($"A > B: {matrixA > matrixB}");
              break;
            case "6":
              Console.WriteLine($"A < B: {matrixA < matrixB}");
              break;
            case "7":
              Console.WriteLine($"det(A): {matrixA.Determinant()}");
              break;
            case "8":
              Console.WriteLine($"det(B): {matrixB.Determinant()}");
              break;
            case "9":
              Console.WriteLine($"HashCode A: {matrixA.GetHashCode()}");
              break;
            case "10":
              Console.WriteLine($"HashCode B: {matrixB.GetHashCode()}");
              break;
            case "11":
              Console.WriteLine($"A == B: {matrixA == matrixB}");
              break;
            case "12":
              Console.WriteLine("Обратная A:\n" + matrixA.Inverse());
              break;
            case "13":
              Console.WriteLine("Обратная B:\n" + matrixB.Inverse());
              break;
            case "14":
              Console.WriteLine("Демонстрация глубокого копирования: ");
              Console.WriteLine("Изначальная матрица A:\n" + matrixA);
              Console.WriteLine("Клон матрицы (перед изменением):\n" + cloneMatrixA);
              Console.WriteLine("Изменяем изначальную матрицу A");
              matrixA.EntryMatrix();
              Console.WriteLine("Матрица A(после изменения):\n" + matrixA);
              Console.WriteLine("Клон матрицы (после изменения):\n" + cloneMatrixA);
              break;
            case "15":
              Console.WriteLine($"След матрицы A = {matrixA.TraceMatrix()}");
              Console.WriteLine($"След матрицы B = {matrixB.TraceMatrix()}");
              break;
            case "16":
              Console.WriteLine("Матрица A в диагональном виде:\n" + diagonalize(matrixA));
              break;
            case "17":
              Console.WriteLine("Матрица B в диагональном виде:\n" + diagonalize(matrixB));
              break;
            default:
              Console.WriteLine("Некорректный ввод.");
              break;
          }
        }
      }
      catch (MatrixException ex)
      {
        Console.WriteLine($"Ошибка: {ex.Message}");
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Ошибка: {ex.Message}");
      }
    }

    public static Matrix CreateMatrix()
    {
      try
      {
        Console.Write("\nРазмерность квадратной матрицы: ");
        int matrixSize = Convert.ToInt32(Console.ReadLine());

        Console.Write("Способ заполнения (1 - вручную, 2 - генерация): ");
        string method = Console.ReadLine();

        Matrix matrix;
        if (method == "1")
        {
          matrix = new Matrix(matrixSize, matrixSize);
          matrix.EntryMatrix();
        }
        else if (method == "2")
        {
          Console.Write("Минимальное значение: ");
          int minValue = Convert.ToInt32(Console.ReadLine());
          Console.Write("Максимальное значение: ");
          int maxValue = Convert.ToInt32(Console.ReadLine());
          matrix = MatrixGenerator.Generate(matrixSize, minValue, maxValue);
        }
        else
        {
          throw new InvalidOperationException("Неверный метод создания");
        }
        return matrix;
      }
      catch (Exception ex)
      {
        throw new MatrixException($"Ошибка создания матрицы, {ex.Message}");
      }
    }
  }
}
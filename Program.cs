using System;

namespace MatrixApp
{
  public delegate Matrix DiagonalizeDelegate(Matrix matrix);
  internal class Program
  {

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

        var handlerChain = BuildHandlerChain(diagonalize);

        while (true)
        {
          Console.WriteLine();
          Console.WriteLine($"Matrix A:\n{matrixA}\n");
          Console.WriteLine($"Matrix B:\n{matrixB}\n");
          PrintMenu();

          string menuMethod = Console.ReadLine();
          Console.Clear();


          handlerChain.Handle(matrixA, matrixB, cloneMatrixA, cloneMatrixB, menuMethod);
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

    private static IMatrixHandler BuildHandlerChain(DiagonalizeDelegate diagonalize)
    {
      var addHandler = new AddMatricesHandler();

      var multiplyHandler = new MultiplyMatricesHandler();
      var scalarMultiplyAHandler = new ScalarMultiplyAHandler();
      var scalarMultiplyBHandler = new ScalarMultiplyBHandler();

      var compareGreaterHandler = new CompareGreaterHandler();
      var compareLessHandler = new CompareLessHandler();
      var equalsHandler = new EqualsHandler();

      var determinantAHandler = new DeterminantAHandler();
      var determinantBHandler = new DeterminantBHandler();

      var traceHandler = new TraceHandler();

      var hashCodeAHandler = new HashCodeAHandler();
      var hashCodeBHandler = new HashCodeBHandler();

      var inverseAHandler = new InverseAHandler();
      var inverseBHandler = new InverseBHandler();

      var deepCopyDemoHandler = new DeepCopyDemoHandler();

      var diagonalizeAHandler = new DiagonalizeAHandler(diagonalize);
      var diagonalizeBHandler = new DiagonalizeBHandler(diagonalize);

      var exitHandler = new ExitHandler();

      addHandler.SetNext(multiplyHandler)
               .SetNext(scalarMultiplyAHandler)
               .SetNext(scalarMultiplyBHandler)
               .SetNext(compareGreaterHandler)
               .SetNext(compareLessHandler)
               .SetNext(determinantAHandler)
               .SetNext(determinantBHandler)
               .SetNext(hashCodeAHandler)
               .SetNext(hashCodeBHandler)
               .SetNext(equalsHandler)
               .SetNext(inverseAHandler)
               .SetNext(inverseBHandler)
               .SetNext(deepCopyDemoHandler)
               .SetNext(traceHandler)
               .SetNext(diagonalizeAHandler)
               .SetNext(diagonalizeBHandler)
               .SetNext(exitHandler);

      return addHandler;
    }

    private static void PrintMenu()
    {
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
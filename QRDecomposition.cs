using System;

namespace MatrixApp
{
  public static class QRDecomposition
  {
    public static double[,] Diagonalize(double[,] matrix, double epsilon = 1e-10, int maxIterations = 1000)
    {
      int matrixSize = matrix.GetLength(0);
      double[,] workingMatrix = (double[,])matrix.Clone();

      for (int iteration = 0; iteration < maxIterations; ++iteration)
      {
        var (orthogonalMatrix, upperTriangularMatrix) = DecomposeQR(workingMatrix);
        workingMatrix = MultiplyMatrices(upperTriangularMatrix, orthogonalMatrix);

        if (IsUpperTriangular(workingMatrix, epsilon))
        {
          break;
        }
      }

      return workingMatrix;
    }

    private static bool IsUpperTriangular(double[,] matrix, double epsilon)
    {
      int matrixSize = matrix.GetLength(0);
      for (int rowIndex = 1; rowIndex < matrixSize; ++rowIndex)
      {
        for (int columnIndex = 0; columnIndex < rowIndex; ++columnIndex)
        {
          if (Math.Abs(matrix[rowIndex, columnIndex]) > epsilon)
          {
            return false;
          }
        }
      }
      return true;
    }

    private static (double[,] Q, double[,] R) DecomposeQR(double[,] matrix)
    {
      int rowCount = matrix.GetLength(0);
      int columnCount = matrix.GetLength(1);
      double[,] orthogonalMatrix = new double[rowCount, columnCount];
      double[,] upperTriangularMatrix = new double[columnCount, columnCount];

      for (int column = 0; column < columnCount; ++column)
      {
        for (int row = 0; row < rowCount; ++row)
        {
          orthogonalMatrix[row, column] = matrix[row, column];
        }

        for (int previousColumn = 0; previousColumn < column; ++previousColumn)
        {
          double dotProduct = 0;
          for (int row = 0; row < rowCount; ++row)
          {
            dotProduct += orthogonalMatrix[row, previousColumn] * matrix[row, column];
          }
          upperTriangularMatrix[previousColumn, column] = dotProduct;

          for (int row = 0; row < rowCount; ++row)
          {
            orthogonalMatrix[row, column] -= orthogonalMatrix[row, previousColumn] * dotProduct;
          }
        }

        double norm = 0;
        for (int row = 0; row < rowCount; ++row)
        {
          norm += orthogonalMatrix[row, column] * orthogonalMatrix[row, column];
        }
        norm = Math.Sqrt(norm);

        upperTriangularMatrix[column, column] = norm;
        for (int row = 0; row < rowCount; ++row)
        {
          orthogonalMatrix[row, column] /= norm;
        }
      }

      return (orthogonalMatrix, upperTriangularMatrix);
    }

    private static double[,] MultiplyMatrices(double[,] leftMatrix, double[,] rightMatrix)
    {
      int leftMatrixRowCount = leftMatrix.GetLength(0);
      int rightMatrixColumnCount = rightMatrix.GetLength(1);
      int commonDimension = leftMatrix.GetLength(1);
      double[,] resultMatrix = new double[leftMatrixRowCount, rightMatrixColumnCount];

      for (int row = 0; row < leftMatrixRowCount; ++row)
      {
        for (int column = 0; column < rightMatrixColumnCount; ++column)
        {
          double sum = 0;
          for (int index = 0; index < commonDimension; ++index)
          {
            sum += leftMatrix[row, index] * rightMatrix[index, column];
          }
          resultMatrix[row, column] = sum;
        }
      }

      return resultMatrix;
    }
  }
}
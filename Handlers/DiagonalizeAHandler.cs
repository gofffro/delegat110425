namespace MatrixApp
{
  public class DiagonalizeAHandler : AbstractMatrixHandler
  {
    private readonly DiagonalizeDelegate _diagonalize;

    public DiagonalizeAHandler(DiagonalizeDelegate diagonalize)
    {
      _diagonalize = diagonalize;
    }

    public override void Handle(Matrix matrixA, Matrix matrixB, Matrix cloneMatrixA, Matrix cloneMatrixB, string choice)
    {
      if (choice == "16")
      {
        Console.WriteLine("Матрица A в диагональном виде:\n" + _diagonalize(matrixA));
      }
      else
      {
        base.Handle(matrixA, matrixB, cloneMatrixA, cloneMatrixB, choice);
      }
    }
  }
}
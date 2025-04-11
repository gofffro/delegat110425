namespace MatrixApp
{
  public class DiagonalizeBHandler : AbstractMatrixHandler
  {
    private readonly DiagonalizeDelegate _diagonalize;

    public DiagonalizeBHandler(DiagonalizeDelegate diagonalize)
    {
      _diagonalize = diagonalize;
    }

    public override void Handle(Matrix matrixA, Matrix matrixB, Matrix cloneMatrixA, Matrix cloneMatrixB, string choice)
    {
      if (choice == "17")
      {
        Console.WriteLine("Матрица B в диагональном виде:\n" + _diagonalize(matrixB));
      }
      else
      {
        base.Handle(matrixA, matrixB, cloneMatrixA, cloneMatrixB, choice);
      }
    }
  }
}
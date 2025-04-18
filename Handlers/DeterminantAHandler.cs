namespace MatrixApp
{
  public class DeterminantAHandler : AbstractMatrixHandler
  {
    public override void Handle(Matrix matrixA, Matrix matrixB, Matrix cloneMatrixA, Matrix cloneMatrixB, string choice)
    {
      if (choice == "7")
      {
        Console.WriteLine($"det(A): {matrixA.Determinant()}");
      }
      else
      {
        base.Handle(matrixA, matrixB, cloneMatrixA, cloneMatrixB, choice);
      }
    }
  }
}
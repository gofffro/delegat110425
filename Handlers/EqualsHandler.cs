namespace MatrixApp
{
  public class EqualsHandler : AbstractMatrixHandler
  {
    public override void Handle(Matrix matrixA, Matrix matrixB, Matrix cloneMatrixA, Matrix cloneMatrixB, string choice)
    {
      if (choice == "11")
      {
        Console.WriteLine($"A == B: {matrixA == matrixB}");
      }
      else
      {
        base.Handle(matrixA, matrixB, cloneMatrixA, cloneMatrixB, choice);
      }
    }
  }
}
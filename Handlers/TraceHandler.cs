namespace MatrixApp
{
  public class TraceHandler : AbstractMatrixHandler
  {
    public override void Handle(Matrix matrixA, Matrix matrixB, Matrix cloneMatrixA, Matrix cloneMatrixB, string choice)
    {
      if (choice == "15")
      {
        Console.WriteLine($"След матрицы A = {matrixA.TraceMatrix()}");
        Console.WriteLine($"След матрицы B = {matrixB.TraceMatrix()}");
      }
      else
      {
        base.Handle(matrixA, matrixB, cloneMatrixA, cloneMatrixB, choice);
      }
    }
  }
}
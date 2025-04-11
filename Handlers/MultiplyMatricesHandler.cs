namespace MatrixApp
{
  public class MultiplyMatricesHandler : AbstractMatrixHandler
  {
    public override void Handle(Matrix matrixA, Matrix matrixB, Matrix cloneMatrixA, Matrix cloneMatrixB, string choice)
    {
      if (choice == "2")
      {
        Console.WriteLine("Произведение A * B:\n" + (cloneMatrixA * cloneMatrixB));
      }
      else
      {
        base.Handle(matrixA, matrixB, cloneMatrixA, cloneMatrixB, choice);
      }
    }
  }
}
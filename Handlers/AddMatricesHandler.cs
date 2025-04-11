namespace MatrixApp
{
  public class AddMatricesHandler : AbstractMatrixHandler
  {
    public override void Handle(Matrix matrixA, Matrix matrixB, Matrix cloneMatrixA, Matrix cloneMatrixB, string choice)
    {
      if (choice == "1")
      {
        Console.WriteLine("Сумма A + B:\n" + (cloneMatrixA + cloneMatrixB));
      }
      else
      {
        base.Handle(matrixA, matrixB, cloneMatrixA, cloneMatrixB, choice);
      }
    }
  }
}
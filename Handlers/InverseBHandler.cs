namespace MatrixApp
{
  public class InverseBHandler : AbstractMatrixHandler
  {
    public override void Handle(Matrix matrixA, Matrix matrixB, Matrix cloneMatrixA, Matrix cloneMatrixB, string choice)
    {
      if (choice == "13")
      {
        Console.WriteLine("Обратная B:\n" + matrixB.Inverse());
      }
      else
      {
        base.Handle(matrixA, matrixB, cloneMatrixA, cloneMatrixB, choice);
      }
    }
  }
}
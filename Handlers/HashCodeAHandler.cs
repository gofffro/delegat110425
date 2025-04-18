namespace MatrixApp
{
  public class HashCodeAHandler : AbstractMatrixHandler
  {
    public override void Handle(Matrix matrixA, Matrix matrixB, Matrix cloneMatrixA, Matrix cloneMatrixB, string choice)
    {
      if (choice == "9")
      {
        Console.WriteLine($"HashCode A: {matrixA.GetHashCode()}");
      }
      else
      {
        base.Handle(matrixA, matrixB, cloneMatrixA, cloneMatrixB, choice);
      }
    }
  }
}
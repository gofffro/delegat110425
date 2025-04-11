namespace MatrixApp
{
  public class ScalarMultiplyAHandler : AbstractMatrixHandler
  {
    public override void Handle(Matrix matrixA, Matrix matrixB, Matrix cloneMatrixA, Matrix cloneMatrixB, string choice)
    {
      if (choice == "3")
      {
        Console.Write("Введите число - множитель для A: ");
        double scalarA = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("A * число:\n" + (cloneMatrixA * scalarA));
      }
      else
      {
        base.Handle(matrixA, matrixB, cloneMatrixA, cloneMatrixB, choice);
      }
    }
  }
}
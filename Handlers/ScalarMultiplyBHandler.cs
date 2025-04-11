namespace MatrixApp
{
  public class ScalarMultiplyBHandler : AbstractMatrixHandler
  {
    public override void Handle(Matrix matrixA, Matrix matrixB, Matrix cloneMatrixA, Matrix cloneMatrixB, string choice)
    {
      if (choice == "4")
      {
        Console.Write("Введите число - множитель для B: ");
        double scalarB = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("B * число:\n" + (cloneMatrixB * scalarB));
      }
      else
      {
        base.Handle(matrixA, matrixB, cloneMatrixA, cloneMatrixB, choice);
      }
    }
  }
}
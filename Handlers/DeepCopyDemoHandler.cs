namespace MatrixApp
{
  public class DeepCopyDemoHandler : AbstractMatrixHandler
  {
    public override void Handle(Matrix matrixA, Matrix matrixB, Matrix cloneMatrixA, Matrix cloneMatrixB, string choice)
    {
      if (choice == "14")
      {
        Console.WriteLine("Демонстрация глубокого копирования: ");
        Console.WriteLine("Изначальная матрица A:\n" + matrixA);
        Console.WriteLine("Клон матрицы (перед изменением):\n" + cloneMatrixA);
        Console.WriteLine("Изменяем изначальную матрицу A");
        matrixA.EntryMatrix();
        Console.WriteLine("Матрица A(после изменения):\n" + matrixA);
        Console.WriteLine("Клон матрицы (после изменения):\n" + cloneMatrixA);
      }
      else
      {
        base.Handle(matrixA, matrixB, cloneMatrixA, cloneMatrixB, choice);
      }
    }
  }
}
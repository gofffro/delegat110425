namespace MatrixApp
{
  public interface IMatrixHandler
  {
    IMatrixHandler SetNext(IMatrixHandler handler);
    void Handle(Matrix matrixA, Matrix matrixB, Matrix cloneMatrixA, Matrix cloneMatrixB, string choice);
  }

  public abstract class AbstractMatrixHandler : IMatrixHandler
  {
    private IMatrixHandler _nextHandler;

    public IMatrixHandler SetNext(IMatrixHandler handler)
    {
      _nextHandler = handler;
      return handler;
    }

    public virtual void Handle(Matrix matrixA, Matrix matrixB, Matrix cloneMatrixA, Matrix cloneMatrixB, string choice)
    {
      if (_nextHandler != null)
      {
        _nextHandler.Handle(matrixA, matrixB, cloneMatrixA, cloneMatrixB, choice);
      }
      else
      {
        Console.WriteLine("Некорректный ввод.");
      }
    }
  }
}
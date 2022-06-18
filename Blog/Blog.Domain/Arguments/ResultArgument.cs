namespace Blog.Domain.Arguments;

public class ResultArgument<T>
{
  public List<string> Messages { get; set; } = new List<string>();
  public T Data { get; set; }
  public ResultArgument(T Data)
  {
    this.Data = Data;
  }
  public ResultArgument(T Data, List<string> messages)
  {
    this.Data = Data;
    this.Messages = messages;
  }
  
  public ResultArgument(List<string> messages)
  {
    this.Messages = messages;
  }

  public ResultArgument(string message)
  {
    Messages.Add(message);
  }
  
  
  
}
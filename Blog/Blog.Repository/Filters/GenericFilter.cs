namespace Blog.Repository.Filters;

public class GenericFilter
{
  public List<GenericFilterItem> filtesItems { get; set; }

  public GenericFilter()
  {
    filtesItems = new List<GenericFilterItem>();
  }



  public class GenericFilterItem {
    public GenericFilterItem(string field, string operation, string value)
    {
      this.field = field;
      this.operation = operation;
      this.value = value;
    }

    public string field { get; private set; }
    public string operation { get; private set; }
    public string value { get; private set; }
    
  }
}
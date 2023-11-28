namespace TaskManager.models;

public class UTask
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Title { get;  set; } = string.Empty;
    public string Note { get;  set; } = string.Empty;
    public DateTime DueDate { get;  set; }
    
    public ICollection<User>? User { get; set; }
}
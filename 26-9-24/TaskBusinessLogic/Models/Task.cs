public class TaskModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }

    public string Comment { get; set; }

    public string Status { get; set; }

    public string AssignedTo { get; set; }
    public string  Priority { get; set; }
    
}
using System.Text.Json.Serialization;

namespace webapi.Models;
public class ToDoTask
{
    public Guid TaskId { get; set; }
    public Guid CategoryId { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public Priority TaskPriority { get; set; }
    public DateTime CreatedDate { get; set; }
    public virtual Category? Category { get; set; }
    [JsonIgnore]
    public string Resumen { get; set; } = "";

}

public enum Priority
{
    Low = 1,
    Medium = 2,
    High = 3
}
using System.Text.Json.Serialization;

namespace webapi.Models;

public class Category
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public int Level { get; set; }
    [JsonIgnore]
    public virtual ICollection<ToDoTask> Tasks { get; set; } = new List<ToDoTask>();
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Task
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    public bool IsComplete { get; set; } = false;

    public Guid PriorityId { get; set; }

    [Required]
    public Guid GroupId { get; set; }

    [Required]
    public Guid UserId { get; set; }

    public Guid ParentTaskId { get; set; }

    [ForeignKey("PriorityId")]
    public Priority Priority { get; set; } = new Priority();

    [ForeignKey("GroupId")]
    public Group Group { get; set; } = new Group();

    [ForeignKey("UserId")]
    public User User { get; set; } = new User();

    [ForeignKey("ParentTaskId")]
    public Task ParentTask { get; set; } = new Task();

    public List<Task> SubTasks { get; set; } = new List<Task>();
}

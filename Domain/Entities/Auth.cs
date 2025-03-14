using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Auth
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string RefreshToken { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    [ForeignKey("UserId")]
    public virtual User User { get; set; } = new User();
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Auth
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string RefreshToken { get; set; } = string.Empty;

    [Required]
    public Guid UserId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; } = new User();
}

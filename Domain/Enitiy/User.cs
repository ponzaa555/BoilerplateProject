using System.ComponentModel.DataAnnotations;

namespace Domain.Entity;

public class User
{
    [Required]
    [Length(36,36)]
    public string Id { get; set; } 
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;
    
}
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Authentication.Commands.Login;

public class LoginCommandRequest
{
    [Required]
    [MinLength(6 , ErrorMessage = "Username must be at least 6 characters long.")]
    public string Username {get; set;}  = null!;

    [Required]
    [MinLength(6 , ErrorMessage = "Password must be at least 6 characters long.")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+=\[{\]};:<>|./?,-]).+$", 
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit and one special character.")]
    public string Password {get; set;} = null!;

}
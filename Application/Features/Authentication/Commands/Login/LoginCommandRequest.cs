using System.ComponentModel.DataAnnotations;

namespace Application.Features.Authentication.Commands.Login;

public class LoginCommandRequest
{
    [Required]
    public string Username {get; set;} 

    [Required]
    public string Password {get; set;}

}
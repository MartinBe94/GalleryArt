using Data.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class Login :IEntity
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Username or email is required")]
    public string UsernameOrEmail { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; }
}

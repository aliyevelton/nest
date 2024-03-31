using System.ComponentModel.DataAnnotations;

namespace Nest.ViewModels;

public class RegisterViewModel
{
    [Required]
    public string FullName { get; set; }
    [Required]
    public string Username { get; set; }
    [Required, DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    [Required, DataType(DataType.Password)]
    public string Password { get; set; }
    [Required, DataType(DataType.Password), Compare(nameof(Password))]
    public string PasswordConfirm { get; set; }
}

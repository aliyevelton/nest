using System.ComponentModel.DataAnnotations;

namespace Nest.ViewModels;

public class ForgotPasswordViewModel
{
    [Required, DataType(DataType.EmailAddress)]
    public string Email { get; set; }
}
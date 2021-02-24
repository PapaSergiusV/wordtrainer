using System.ComponentModel.DataAnnotations;

namespace Vocabulary.ViewModels
{
  public class SignInViewModel
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
  }
}

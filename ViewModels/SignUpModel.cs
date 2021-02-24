using System.ComponentModel.DataAnnotations;

namespace Vocabulary.ViewModels
{
  public class SignUpViewModel
  {
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Text)]
    [StringLength(20)]
    public string Username { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
  }
}

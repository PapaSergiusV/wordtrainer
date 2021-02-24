using Microsoft.AspNetCore.Identity;

namespace Vocabulary.Models
{
  public class User : IdentityUser<int>
  {
    public User() : base()
    { }

    public User(string userName) : base(userName)
    { }
  }
}

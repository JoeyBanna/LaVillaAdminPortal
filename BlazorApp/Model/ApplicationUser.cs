using Microsoft.AspNetCore.Identity;

namespace BlazorApp.Model
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {

        }
        public ApplicationUser(string userName) : base(userName)
        {

        }
    }
}

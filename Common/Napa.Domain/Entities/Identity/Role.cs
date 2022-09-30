using Microsoft.AspNetCore.Identity;

namespace Napa.Domain.Entities.Identity
{
    public class Role : IdentityRole<Guid>
    {
        public Role()
        { }
        public Role(string roleName) : base(roleName) => NormalizedName = roleName.ToUpper();
    }
}
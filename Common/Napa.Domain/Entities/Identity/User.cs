using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Napa.Domain.Entities.Identity
{
    public class User : IdentityUser<Guid>
    {
        [Column(TypeName = "character varying(25)")]
        public string FirstName { get; set; } = null!;

        [Column(TypeName = "character varying(25)")]
        public string LastName { get; set; } = null!;
    }
}
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DefectTracking.Models
{
    public class User : IdentityUser
    {
        [NotMapped]
        public IList<string> RoleNames { get; set; }
    }
}

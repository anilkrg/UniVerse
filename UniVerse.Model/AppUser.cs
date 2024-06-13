using Microsoft.AspNetCore.Identity;

namespace UniVerse.Model
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}

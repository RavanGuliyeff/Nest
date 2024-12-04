namespace NestWebApp.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool RememberMe { get; set; }
    }
}

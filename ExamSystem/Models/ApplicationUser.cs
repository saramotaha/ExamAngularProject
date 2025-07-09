using Microsoft.AspNetCore.Identity;

namespace ExamSystem.Models;

public class ApplicationUser : IdentityUser
{
    public int ID { get; set; }
    public string Name { get; set; }

    public string Role { get; set; }

}

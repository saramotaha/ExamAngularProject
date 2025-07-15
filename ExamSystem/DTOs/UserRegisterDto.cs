using System.ComponentModel.DataAnnotations;

namespace ExamSystem.DTO
{
    public class UserRegisterDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string role { get; set; }




    }
}

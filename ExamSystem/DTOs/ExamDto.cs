using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSystem.DTOs
{
    public class ExamDto
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]

        public int Duration { get; set; }
        [Required]

        public int TotalScore { get; set; }


        
        //public int UsersId { get; set; }
    }
}

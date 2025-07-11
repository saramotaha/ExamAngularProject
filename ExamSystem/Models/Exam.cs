using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSystem.Models
{
    public class Exam
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]

        public int Duration { get; set; }
        [Required]

        public int TotalScore { get; set; }


        [ForeignKey("User")]
        public int UsersId { get; set; }
        public virtual AppUser User { get; set; }



        public virtual List<StudentExam> studentExams { get; set; }=new List<StudentExam>();
        public virtual List<Question> Questions { get; set; }=new List<Question>();







    }
}

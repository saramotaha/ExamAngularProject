using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSystem.Models
{
    public class StudentExam
    {

        public int Id { get; set; }

        [ForeignKey("User")]
        public int UsersId { get; set; } 
        public virtual AppUser User { get; set; }


        [ForeignKey("Exam")]

        public int ExamId { get; set; }


        public virtual Exam? Exam { get; set; }


        public int score { get; set; }
    }
}

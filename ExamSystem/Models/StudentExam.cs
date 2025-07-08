using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSystem.Models
{
    public class StudentExam
    {

        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; } 
        public Student Student { get; set; }


        [ForeignKey("Exam")]

        public int ExamId { get; set; }

        public Exam Exam { get; set; }


        public int score { get; set; }
    }
}

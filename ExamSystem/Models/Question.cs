using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSystem.Models
{
    public class Question
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string QuestionBody { get; set; }

        [Required]

        public int QuestionDegree { get; set; }

        [ForeignKey("Exam")]
        public int ExamID { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual List<Answers> Choices { get; set; }=new List<Answers>();

    }
}

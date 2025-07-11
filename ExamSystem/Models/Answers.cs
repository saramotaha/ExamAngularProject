using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSystem.Models
{
    public class Answers
    {
        public int ID { get; set; }
        [Required]

        public string AnswerText { get; set; }
        [Required]

        public bool IsCorrect { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }


        
    }
}

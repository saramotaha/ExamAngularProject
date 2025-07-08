using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSystem.Models
{
    public class Answers
    {
        public int ID { get; set; }
        public string AnswerText { get; set; }
        public bool IsCorrect { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }


        
    }
}

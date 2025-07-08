using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSystem.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string QuestionBody { get; set; }

        public int QuestionDegree { get; set; }

        [ForeignKey("Exam")]
        public int ExamID { get; set; }
        public Exam Exam { get; set; }
        public List<Answers> Choices { get; set; }

    }
}

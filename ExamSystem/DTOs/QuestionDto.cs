using ExamSystem.Models;

namespace ExamSystem.DTOs
{
    public class QuestionDto
    {
        public int ID { get; set; }
        public string Text { get; set; }

        //public List<Answers> Choices { get; set; }
        //public string CorrectAnswer { get; set; }

        public int ExamId { get; set; }

        public List<AnswerDTO> Choices { get; set; } = new();
    }
}

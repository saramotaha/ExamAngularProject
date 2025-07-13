using ExamSystem.Models;

namespace ExamSystem.DTOs;

public class QuestionDto
{
    public int ID { get; set; }
    public string Text { get; set; }
    public int Degree { get; set; }
    public int ExamId { get; set; }

    public List<AnswerDTO> Choices { get; set; } = new();
}

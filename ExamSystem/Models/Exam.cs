using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSystem.Models;

public class Exam
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }   
    public int Duration { get; set; }   
    public int TotalScore { get; set; }

    public int UserId { get; set; }

    public virtual List<StudentExam> studentExams { get; set; }=new List<StudentExam>();
    public virtual List<Question> Questions { get; set; }=new List<Question>();
}

namespace ExamSystem.Models
{
    public class Teacher:User
    {
        public List<Exam> Exams { get; set; }
    }
}

namespace ExamSystem.Models
{
    public class Student : User
    {

        public List<StudentExam> studentExams { get; set; } = new List<StudentExam>();
    }
}

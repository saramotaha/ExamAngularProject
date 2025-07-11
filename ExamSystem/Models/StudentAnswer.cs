using System.ComponentModel.DataAnnotations.Schema;

namespace ExamSystem.Models
{
    public class StudentAnswer
    {

        public int ID { get; set; }

        [ForeignKey("StudentExam")]
        public int StudentId { get; set; }
        public virtual StudentExam StudentExam { get; set; }

        [ForeignKey("Question")]
        public int QuestionID { get; set; }

        public virtual Question Question { get; set; }


        [ForeignKey("Answers")]
        public int AnswerSID { get; set; }

        public virtual Answers Answers { get; set; }

    }
}

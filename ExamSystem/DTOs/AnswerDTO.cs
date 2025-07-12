namespace ExamSystem.DTOs
{
    public class AnswerDTO
    {
        public int ID { get; set; }

        public string AnswerText { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
        //public int QuestionId { get; set; }



        // Navigation property
        //public virtual QuestionDTO? Question { get; set; }
    }
}

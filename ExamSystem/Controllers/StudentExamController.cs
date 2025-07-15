using ExamSystem.DTOs;
using ExamSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExamSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentExamController : ControllerBase
    {
        private readonly ExamContext context;
        private readonly UserManager<AppUser> userManager;

        public StudentExamController(ExamContext context , UserManager<AppUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }


        [HttpPost]
        public async Task<IActionResult> AddStudentExam(UserExamDTO studentExam)
        {

            var u = userManager.GetUserAsync(User);

            studentExam = new UserExamDTO()
            {
                ExamId = studentExam.ExamId,
                UsersId = u.Id,
                score=studentExam.score,
            };


            StudentExam student = new StudentExam()
            {
                ExamId = studentExam.ExamId,
                UsersId = studentExam.UsersId,
                score= studentExam.score,


            };



            context.StudentExams.Add(student);
            context.SaveChanges();

            return Ok("done");




        }


        //[HttpGet]

        //public IActionResult GetStudentExam(int id)
        //{
            
        //    var AllStudExams = context.StudentExams.Where(s => s.UsersId == id).Select(new { UsersId =}).ToList();
             

        //    return Ok(AllStudExams);
        //}




        [HttpGet("AllResults")]
        public IActionResult GetAllResultsInEachExam()
        {

            List<UserExamDTO> AllResults = context.StudentExams.Include(x => x.Exam).ToList();
            return Ok(AllResults);
        }
    }

}

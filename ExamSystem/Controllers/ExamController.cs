using AutoMapper;
using ExamSystem.DTOs;
using ExamSystem.Models;
using ExamSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExamSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        //private readonly ExamContext exam;


        public IExamRepo Reps { get; }
        public IMapper _Map;

        public ExamController(IMapper _map,IExamRepo _reps, UserManager<AppUser> userManager  ) //add imapper _map
        {
            //this.exam = exam;
            _Map = _map;
            Reps = _reps;
            UserManager = userManager;
        }

        public UserManager<AppUser> UserManager { get; }

        [HttpPost]
        [EndpointDescription("We add exam here ")]
        [EndpointSummary("AddExam ")]

        public async Task<IActionResult> AddExam(ExamDto examDto )
        {
            var user = await UserManager.GetUserAsync(User);



            #region Legacy code 

            //if(user == null)
            //{
            //    return BadRequest("User not found");
            //}

            //else
            //{

            //Exam _exam = new Exam()
            //{
            //    Name = examDto.Name,
            //    Description = examDto.Description,
            //    Duration = examDto.Duration,
            //    TotalScore = examDto.TotalScore,
            //    UsersId = 1
            //};

            //exam.Exams.Add (_exam);
            //exam.SaveChanges();
            //} 
            #endregion

            Exam _exam = _Map.Map<Exam>(examDto);
            
            await  Reps.AddAsync(_exam);
           
            await Reps.SaveChangesAsync();
        
            return Ok("done");
        }




        //[HttpGet("{id}")]

        //public async Task<ExamDto> GetExamById(int id)
        //{
        //    //  Exam e=  exam.Exams.SingleOrDefault(e=>e.ID == id);

        //    Exam e= await Reps.GetByIdAsync(id);

        //    if (e == null)
        //    {
        //        return null;
        //    }

        //    #region Before Optimization
        //    //ExamDto examDto = new ExamDto()
        //    //{
        //    //    Name = e.Name,
        //    //    Description = e.Description,
        //    //    Duration = e.Duration,
        //    //    TotalScore = e.TotalScore,
        //    //    ID = e.ID
        //    //};


        //    //return examDto; 
        //    #endregion

        //    return _Map.Map<ExamDto>(e);


        //}

        [EndpointDescription("We get exam here by id")]
        [EndpointSummary("Get Exam by id")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamById(int id)
        {
        

            Exam e = await Reps.GetByIdAsync(id);

            if (e == null)
            {
                return NotFound($"Exam with ID {id} not found");
            }

            return Ok(_Map.Map<ExamDto>(e));


        }




        //[HttpPut]
        [EndpointDescription("We edit exam here ")]
        [EndpointSummary("Edit Exam ")]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditExam(int id , ExamDto examDto)
        {

            #region legacy 


            //Exam exam1 = _Map.Map<Exam>(examDto);

            //ExamDto exam = GetExamById(id);

            //await Reps.GetByIdAsync(id); /*exam.Exams.SingleOrDefault(e=>e.ID == id);*/



            //exam1.Name = examDto.Name;
            //exam1.Duration = examDto.Duration;
            //exam1.TotalScore = examDto.TotalScore;
            //exam1.Description = examDto.Description;
            //exam.SaveChanges();

            #endregion

            if (examDto == null || examDto.ID != id)
            {
                return BadRequest("ExamDto cannot be null nor id mismatch");
            }

            Exam? existingExam = await Reps.GetByIdAsync(id);

            if (existingExam == null)
            {
                return NotFound($"Exam with ID {id} not found");
            }

            // Map changes from DTO to existing entity
            _Map.Map(examDto, existingExam);

            await Reps.Update(existingExam);
            
            await Reps.SaveChangesAsync();

            return Ok("Exam updated successfully");

        }
        




        [HttpGet]
        [EndpointDescription("We here get all exams here ")]
        [EndpointSummary("Get all Exams ")]
        public async Task<IActionResult> GetAllExams()
        {
            #region legacy
            //v0
            //List<Exam> exams = exam.Exams.ToList();

            //v1
            //IEnumerable<Exam> exams = await Reps.GetAllAsync(); 

            //List<ExamDto> examDtos = [];


            //foreach (var item in exams)
            //{

            //    examDtos.Add(new ExamDto()
            //    {
            //        ID = item.ID,
            //        Name = item.Name,
            //        Description = item.Description,
            //        Duration = item.Duration,
            //        TotalScore = item.TotalScore,
            //    });
            //}

            #endregion
           
            
            //return Ok(examDtos);
            
            return Ok(_Map.Map<IEnumerable<ExamDto>>(await Reps.GetAllAsync()));

        }


        [HttpDelete("{id:int}")]
        [EndpointDescription("We delete exam here ")]
        [EndpointSummary("delete Exam ")]
        public async Task<IActionResult> Delete(int id)
        {
            Exam E = await Reps.GetByIdAsync(id);

            if (E == null)
            {
                return NotFound(); 
            }

            //can check if the existing exam is related to a student or not  =>not coded yet 
            
            //could be soft delete too

            await  Reps.Delete(E);
            
            await  Reps.SaveChangesAsync();
            
            return NoContent();

        }


    }
}

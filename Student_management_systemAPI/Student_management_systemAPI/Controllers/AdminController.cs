using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Student_management_systemAPI.Data;
using Student_management_systemAPI.Models;

namespace Student_management_systemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DataDbContext dataDbContext;

        public AdminController(DataDbContext dataDbContext)
        {
            this.dataDbContext = dataDbContext;
        }





        [HttpPost]

        public async Task<IActionResult> Addstu(Student student)
        {

            try
            {
                var localvar = new Student()
                {
                    StudentId = Guid.NewGuid(),
                    Name = student.Name,
                    Age = student.Age,
                    Grade = student.Grade

                };

                await dataDbContext.Students.AddAsync(localvar);
                await dataDbContext.SaveChangesAsync();
                return Ok(localvar);
            }



            catch (Exception ex)
            {
                
                return StatusCode(500, "Internal server error");
            }

        }




        [HttpGet("GetStudentDetails")]

        public async Task<IActionResult> GetStudent()
        {
            try
            {
                var localvar = await dataDbContext.Students.ToListAsync();
                return Ok(localvar);
            }


            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }





    


        [HttpGet]
        [Route("{StudentId:guid}")]

        public async Task<IActionResult> GetStudent(Guid StudentId)
        {
            try
            {

                var localvar = await dataDbContext.Students.FindAsync(StudentId);
                if (localvar != null)
                {
                    return Ok(localvar);
                }
                return NotFound();
            }


            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }




        [HttpPut]
        [Route("{StudentId:guid}")]

        public async Task<IActionResult> Update([FromRoute] Guid StudentId, Student student)
        {
            try
            {
                var localvar = await dataDbContext.Students.FindAsync(StudentId);

                if (localvar != null)
                {

                    localvar.Name = student.Name;
                    localvar.Age = student.Age;
                    localvar.Grade = student.Grade;


                    await dataDbContext.SaveChangesAsync();
                    return Ok(localvar);


                }

                return NotFound();
            }


            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }
        }





        [HttpDelete]
        [Route("{StudentId:guid}")]


        public async Task<IActionResult> DeleteStudent(Guid StudentId)
        {
            try
            {

                var localvar = await dataDbContext.Students.FindAsync(StudentId);

                if (localvar != null)
                {

                    dataDbContext.Remove(localvar);
                    await dataDbContext.SaveChangesAsync();
                    return Ok(localvar);
                }

                return NotFound();
            }


            catch (Exception ex)
            {

                return StatusCode(500, "Internal server error");
            }

        }




    }
}

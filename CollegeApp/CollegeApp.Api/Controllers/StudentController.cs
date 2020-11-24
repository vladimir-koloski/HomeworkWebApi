using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeApp.Services;
using CollegeApp.Models;
using System.Diagnostics;

namespace CollegeApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            this._studentService = studentService;
        }
        [HttpPost("register")]
        public IActionResult RegisterStudent([FromBody]StudentModel request)
        {
            try
            {
                _studentService.CreateStudent(request);
                Debug.WriteLine($"User registered with {request.FullName}");
                return Ok("Success");
            }
            catch (Exception ex)
            {               
                return BadRequest(ex.Message);
            }

        }
    }
}

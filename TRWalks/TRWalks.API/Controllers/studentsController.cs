using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TRWalks.API.Controllers {


    [Route("api/[controller]")]
    [ApiController]
    public class studentsController : ControllerBase {

        [HttpGet]
        public IActionResult getAllStudents() {
            String[] studentsName = new String[] { "shady", "Ashraf", "Alaa" };
            return Ok(studentsName);    
        }
    }
}

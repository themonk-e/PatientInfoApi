using Bussiness_Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Models;

namespace Patient_Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        ILogic? _logic;

        public TestController(ILogic logic) { 
            _logic = logic;
        }




        [HttpPost("AddTest")]
        public IActionResult AddTest([FromBody] Test_M test)
        {
            try
            {
               var createdTest= _logic.AddTest(test);
               return Ok(createdTest);
            }
            catch (SqlException sqlE)
            {
                return BadRequest(sqlE.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 

        }

        [HttpGet("GetTestList/ByVisitId")]
        public IActionResult GetTestListbyVisitId(int visitId)
        {
            try
            {
                if (_logic.GetTestList(visitId) != null)
                {
                    return Ok(_logic.GetTestList(visitId));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(SqlException sqlE)
            {
                return BadRequest(sqlE.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetTestId/ByName")]
        
        public IActionResult GetTestIdByName(string name)
        {
            try
            {
                if (_logic.GetTestIdByName(name) != 0)
                {
                    return Ok(_logic.GetTestIdByName(name));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(SqlException sqlE)
            {
                return BadRequest(sqlE.Message);    
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("UpdateTest")]

        public IActionResult UpdateTest(Test_M test,int id)
        {
            try
            {
                if (_logic.UpdateTest(test,id) != null)
                {
                    return Ok(_logic.UpdateTest(test,id));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(SqlException sqlE)
            {
                return BadRequest(sqlE.Message);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }


      



    }
}

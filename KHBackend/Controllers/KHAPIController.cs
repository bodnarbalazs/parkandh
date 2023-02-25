using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KHBackend.Models;

namespace KHBackend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class KHAPIController : ControllerBase
    {
        [HttpGet]
        [Route("getUserByEmail/{Email}/{Password}")]
        public IActionResult GetUserByEmail(string email,string password)
        {
            ParkContext parkContext = new ParkContext();
            User? user =parkContext.Users.Where(u => u.Email == email).ToList().FirstOrDefault();
            if (user==null)
            {
                return NotFound("Hibás felhasználónév vagy jelszó.");
            }
            else if(password != user.Password)
            {
                return NotFound("Hibás felhasználónév vagy jelszó.");
            }
            return Ok(user);
        }
        
        [HttpGet]
        [Route("getReservationsByUserId/{UserId}")]
        public IActionResult GetReservationsByUserId(int UserId)
        {
            return Ok(UserId);
        }
        [HttpGet]
        [Route("getAvailableCarPools/{UserId}")]
        public IActionResult GetAvailableCarPools(int UserId)
        {

            return Ok(UserId);
        }
        [HttpPost]
        [Route("postParkingRequest/{UserId}/{FromDate}/{ToDate}")]
        public IActionResult PostParkingRequest(int UserId,DateTime fromDate,DateTime toDated)
        {

            return Ok(UserId);
        }
        [HttpPost]
        [Route("postReservationSubmission/{UserId}/{FromDate}/{ToDate}/{Beneficiary}")]
        public IActionResult PostReservationSubmission(int UserId, DateTime fromDate, DateTime toDate, int BeneficiaryId)
        {

            return Ok(UserId);
        }
        [HttpPost]
        [Route("postReservationSubmissionCancellation/{UserId}/{FromDate}/{ToDate}")]
        public IActionResult PostReservationSubmissionCancellation(int UserId, DateTime fromDate, DateTime toDate, int BeneficiaryId)
        {

            return Ok(UserId);
        }
        [HttpPost]
        [Route("postUserSettingsUpdate/{UserId}/{UserSetting}")]
        
        public IActionResult PostUserSettingsUpdate(int UserId, string userSettings)
        {

            return Ok(UserId);
        }
    }
}

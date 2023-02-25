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
            if (user == null)
            {
                return Problem();
            }
            else if (user.Password!=password)
            {
                return Problem();
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
        [HttpGet]
        [Route("getAvailableParkingSpaces/{FromDate}/{ToDate}")]
        public IActionResult GetAvailableParkingSpaces(DateTime fromDate, DateTime toDate)
        {
            ParkContext parkContext = new ParkContext();
            var availableSpaces=parkContext.ParkingReservations.Where(r => r.Surrogated == null && r.FromDate <= fromDate && r.ToDate >= toDate).ToList();
            return Ok(availableSpaces);
        }
        [HttpPost]
        [Route("postParkingRequest/{UserId}/{FromDate}/{ToDate}")]
        public IActionResult PostParkingRequest(int UserId,DateTime fromDate,DateTime toDated)
        {
            ParkContext parkContext = new ParkContext();

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
        [HttpPost]
        [Route("postCarPoolDriverSubmission/{UserId}/{Limit}/{StartDate}")]

        public IActionResult PostCarPoolDriverSubmission(int UserId, string userSettings,DateTime startDate)
        {

            return Ok(UserId);
        }
        [HttpPost]
        [Route("postCarPoolMemberRequest/{UserId}/{CarPoolId}")]

        public IActionResult PostCarPoolMemberRequest(int UserId, int CarPoolId)
        {

            return Ok(UserId);
        }
        [HttpPost]
        [Route("postCarPoolMemberAccepted/{UserId}/{CarPoolId}")]

        public IActionResult PostCarPoolMemberAccepted(int UserId, int CarPoolId)
        {

            return Ok(UserId);
        }
        [HttpPost]
        [Route("postCancelCarpool/{CarPoolId}/{UserId}")]

        public IActionResult PostCancelCarpool(int UserId, int CarPoolId)
        {

            return Ok(UserId);
        }
        [HttpPost]
        [Route("postCreateUser/{UserId}/")]

        public IActionResult PostCreateUser(string FirstName,string LastName,string Email,string? PrivateParking,string Password,string HomeAddress)
        {
            ParkContext parkContext = new ParkContext();
            User newUser=new User();
            newUser.FirstName = FirstName;
            newUser.LastName = LastName;
            newUser.Email = Email;
            newUser.PrivateParking = PrivateParking;
            newUser.Password = Password;
            newUser.HomeAddress=HomeAddress;
            newUser.Coin = 0;
            newUser.UserSettings = "y;y;n";
              try
            {
                newUser.Id = parkContext.Users.OrderByDescending(u => u.Id).First().Id + 1;
                parkContext.Users.Add(newUser);
                parkContext.SaveChanges();
                return Ok("Sikeres Felhasználó Létrehozás");
            }
            catch (Exception ex)
            {
                return BadRequest("Nem sikerült a felhasználó létrehozása.");
            }
        }
        [HttpDelete]
        [Route("deleteUser/{UserId}")]

        public IActionResult DeleteUser(int UserId)
        {
            ParkContext parkContext = new ParkContext();
            try
            {
                parkContext.Users.Remove(parkContext.Users.Where(u=>u.Id==UserId).First());
                parkContext.SaveChanges();
                return Ok("Felhasználó sikeresen eltávolítva.");
            }
            catch (Exception)
            {
                return BadRequest("Nem sikerült a felhasználó törlése.");
            }
        }
    }
}

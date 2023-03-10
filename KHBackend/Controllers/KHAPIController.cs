using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using KHBackend.Models;
using KHBackend.Automations;

namespace KHBackend.Controllers
{
    [Route("api/")]
    [ApiController]
    public class KHAPIController : ControllerBase
    {
        [HttpGet]
        [Route("getUserByEmail/{Email}/{Password}")]
        public IActionResult GetUserByEmail(string Email,string Password)
        {
            ParkContext parkContext = new ParkContext();
            int c=parkContext.Users.Count();
            User? user =parkContext.Users.Where(u => u.Email == Email).ToList().FirstOrDefault();
            if (user == null)
            {
                return Problem();
            }
            else if (user.Password!=Password)
            {
                return Problem();
            }
            return Ok(user);
        }
        
        [HttpGet]
        [Route("getReservationsByUserId/{UserId}")]
        public IActionResult GetReservationsByUserId(int UserId)
        {
            ParkContext parkContext = new ParkContext();
            try
            {
                return Ok(parkContext.ParkingReservations.Where(r=>r.Owner.Id==UserId&&r.Surrogated==UserId).ToList());
            }
            catch (Exception)
            {
                return Problem();
            }
            
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
            ParkContext parkContext = new ParkContext();
            return Ok(UserId);
        }
        [HttpPost]
        [Route("postReservationSubmissionWithId/{ClickedElementId}/{UserId}")]
        public IActionResult PostReservationSubmissionWithId(string ClickedElementId,int UserId)
        {
            ParkContext parkContext = new ParkContext();
            int year = int.Parse(ClickedElementId.Split('-')[0]);
            int month = int.Parse(ClickedElementId.Split('-')[1]);
            int day = int.Parse(ClickedElementId.Split('-')[2]);
            var res=parkContext.ParkingReservations.Where(r => r.FromDate.Year==year&& r.FromDate.Month == month && r.FromDate.Day == day).FirstOrDefault();
            var u = parkContext.Users.Where(u => u.Id == UserId).FirstOrDefault();
            if (res == null||u==null) { return BadRequest(); }
            res.Surrogated = null;
            u.Coin++;
            parkContext.SaveChanges();
            return Ok();
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
        [HttpPost]
        [Route("postAdmin/{magic}")]

        public IActionResult PostAdmin(string magic)
        {
            if (magic=="unga")
            {
                GenerateReservations.Setup();
                return Ok("bunga");
            }
            return BadRequest();
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

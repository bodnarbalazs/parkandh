using KHBackend.Models;
namespace KHBackend.Automations
{
    public class GenerateReservations
    {
        public void Setup()
        {
            DateTime currentDate = DateTime.Now;
            ParkContext parkContext = new ParkContext();
            int dayLimit = 30;

            parkContext.Users.Where(u => u.PrivateParking != "null").ToList().ForEach(user =>
               {
                   for (int i = 0; i < dayLimit; i++)
                   {
                       
                   }
               });
        }
            public void Daily()
        {
            DateTime currentDate=DateTime.Now;
            ParkContext parkContext = new ParkContext();

            parkContext.Users.ToList().ForEach(user =>parkContext.ParkingReservations.Add(new )
        }
    }
}

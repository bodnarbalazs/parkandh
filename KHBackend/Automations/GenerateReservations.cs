using KHBackend.Models;
namespace KHBackend.Automations
{
    public static class GenerateReservations
    {
        public static void Setup()
        {
            DateTime currentDate = DateTime.Now;
            ParkContext parkContext = new ParkContext();
            int dayLimit = 30;

            parkContext.Users.Where(u => u.PrivateParking != "null").ToList().ForEach(user =>
               {
                   for (int i = 0; i < dayLimit+1; i++)
                   {
                       ParkingReservation res=new ParkingReservation();
                       DateTime dt=currentDate.AddDays(i);
                       res.FromDate = new DateTime(dt.Year,dt.Month,dt.Day,0,0,0);
                       res.ToDate = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
                       res.OwnerId = user.Id;
                       res.Surrogated = user.Id;
                       res.Id = parkContext.ParkingReservations.OrderByDescending(r=>r.Id).FirstOrDefault()==null?0:parkContext.ParkingReservations.OrderByDescending(r => r.Id).FirstOrDefault().Id+1;
                       parkContext.ParkingReservations.Add(res);

                   }
               });
            parkContext.ParkingSpaces.Where(p => parkContext.Users.All(u => p.Id != u.PrivateParking)).ToList().ForEach(p =>
            {
                for (int i = 0; i < dayLimit + 1; i++)
                {
                    ParkingReservation res = new ParkingReservation();
                    DateTime dt = currentDate.AddDays(i);
                    res.FromDate = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
                    res.ToDate = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59);
                    res.OwnerId = null;
                    res.Surrogated = null;
                    res.Id = parkContext.ParkingReservations.OrderByDescending(r => r.Id).FirstOrDefault() == null ? 0 : parkContext.ParkingReservations.OrderByDescending(r => r.Id).FirstOrDefault().Id + 1;
                    parkContext.ParkingReservations.Add(res);
                }
            });
            parkContext.SaveChanges();
        }
        public static void ResetReservations()
        {
            ParkContext parkContext = new ParkContext();
            parkContext.ParkingReservations.ToList().ForEach(r => parkContext.ParkingReservations.Remove(r));
            Setup();
        }
            public static void Daily()
        {
            DateTime currentDate=DateTime.Now;
            ParkContext parkContext = new ParkContext();

            //parkContext.Users.ToList().ForEach(user =>parkContext.ParkingReservations.Add(new )
        }
    }
}

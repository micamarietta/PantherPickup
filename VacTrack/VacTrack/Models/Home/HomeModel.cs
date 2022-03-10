using System;
namespace PantherPickup.Models.Home
{
    public class HomeModel
    {

        public HomeModel()
        {

        }

        public int pID { get; set; }
        public string Name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string grade { get; set; }
        public string major { get; set; }
        public int numRides { get; set; }
        public float rating { get; set; }

    }
}

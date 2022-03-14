using System;
namespace PantherPickup.Models.Account
{
    public class AccountModel
    {

        public AccountModel()
        {

        }

        public int pID { get; set; }
        public string Name { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string grade { get; set; }
        public string major { get; set; }
        public int year { get; set; }
        public int numRides { get; set; }
        public float rating { get; set; }
        public bool isPassenger { get; set; }

    }
}

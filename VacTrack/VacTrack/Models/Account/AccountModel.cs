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
        public string Password { get; set; }
        public string Email { get; set; }
        public string Grade { get; set; }
        public string Major { get; set; }
        public int Year { get; set; }
        public int NumRides { get; set; }
        public bool IsPassenger { get; set; }

    }
}

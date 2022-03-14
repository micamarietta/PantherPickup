using NUnit.Framework;
using VacTrack.Controllers;

namespace PantherPickupTesting
{
    public class AccountControllerTest
    {
        private AccountController _AccountController { get; set; } = null!; 

        [SetUp]
        public void Setup()
        {
            _AccountController = new AccountController();
        }

        
        //testing our create function in AccountController

        [Test]
        public void CreateTest()
        {
            Assert.Pass();
        }

        //testing our 
    }
}
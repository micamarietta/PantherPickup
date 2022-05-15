using NUnit.Framework;
using VacTrack.Controllers;
using PantherPickup.Controllers;
using PantherPickup.Models.RideRequest;
using PantherPickup.Models.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace PantherPickupTesting
{
    public class RideRequestControllerTest
    {
        private IConfiguration _configuration;

        private readonly ILogger<RideRequestController> _logger;
        private RideRequestController _RideRequestController { get; set; } = null!;
        private RideRequestModel RideRequestMod { get; set; } = null!;
        private AccountModel AccountMod { get; set; } = null!;

        [SetUp]
        public void Setup()
        {
            IServiceCollection services = new ServiceCollection();

            var builder = new ConfigurationBuilder().AddJsonFile($"testsettings.json", optional: false);
            _configuration = builder.Build();
            services.AddSingleton<IConfiguration>(_configuration);

            _RideRequestController = new RideRequestController(_logger, _configuration);
            RideRequestMod = new RideRequestModel();
            AccountMod = new AccountModel();
        }

        //testing our create function in AccountController
        //ensuring our input strings for login are accurately being added to the database



        //method for removing test entries from our database
        public void removeTestEntries()
        {
            var conn = new SqlConnection(_configuration.GetConnectionString("PantherPickup"));
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction(); ;

            try
            {
                var sql = string.Format("DELETE FROM rideRequest WHERE driverId" + 50);
                var command = new SqlCommand(sql, conn, trans);
                command.ExecuteNonQuery();
                trans.Commit();

            }
            catch (Exception ex)
            {
                trans.Rollback();

            }
            finally
            {
                conn.Close();
            }
        }

        [Test]
        public void CreateRideRequestTest()
        {
            AccountMod.Email = "marietta@chapman.edu";
            AccountMod.Password = "password";
            AccountMod.pID = 8;
            RideRequestMod.DriverID = 50;
            RideRequestMod.PassengerID = 8;
            RideRequestMod.Date = DateTime.Now;
            RideRequestMod.IsCancelled = false;
            RideRequestMod.NumPassengers = 3;
            RideRequestMod.PickupLoc = "Chapman University";
            RideRequestMod.DropOffLoc = "Orange Circle";
            RideRequestMod.IsCompleted = false;
            _RideRequestController.Create(RideRequestMod, AccountMod);
            bool dataAdded = false;

            //EDGE CASE #1: creates ride request and successfully adds to database 
            //read from our database to check name has been added to the table
            using (var connection = new SqlConnection(_configuration.GetConnectionString("PantherPickup")))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM rideRequest WHERE driverId = '" + RideRequestMod.DriverID + "'", connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();

                //if this reader executes, we know the name has been found in our database
                while (reader.Read())
                {
                    dataAdded = true;
                }
            }
            Assert.True(dataAdded);
            removeTestEntries();
        }
    }
}

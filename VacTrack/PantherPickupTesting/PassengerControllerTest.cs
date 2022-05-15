using NUnit.Framework;
using VacTrack.Controllers;
using PantherPickup.Controllers;
using PantherPickup.Models.RideRequest;
using PantherPickup.Models.Account;
using PantherPickup.Models.Passenger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using PantherPickup.Utilities;

namespace PantherPickupTesting
{
    public class PassengerControllerTest
    {
        private IConfiguration _configuration;

        private readonly ILogger<PassengerController> _logger;
        private readonly ILogger<RideRequestController> _logger1;
        private PassengerController _PassengerController { get; set; } = null!;
        private AccountModel AccountMod { get; set; } = null!;
        private RideRequestModel RideRequestMod { get; set; } = null!;
        private RideRequestController _RideRequestController { get; set; } = null!;

        [SetUp]
        public void Setup()
        {
            IServiceCollection services = new ServiceCollection();

            var builder = new ConfigurationBuilder().AddJsonFile($"testsettings.json", optional: false);
            _configuration = builder.Build();
            services.AddSingleton<IConfiguration>(_configuration);

            _PassengerController = new PassengerController(_logger, _configuration);
            _RideRequestController = new RideRequestController(_logger1, _configuration);
            AccountMod = new AccountModel();
            RideRequestMod = new RideRequestModel();
        }

        //method for removing test entries from our database
        public void removeTestEntries()
        {
            var conn = new SqlConnection(_configuration.GetConnectionString("PantherPickup"));
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction(); ;

            try
            {
                var sql = string.Format("DELETE FROM rideRequest WHERE ridesId" + 1000);
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
        public void CancelTest()
        {
            RideRequestMod.RideID = 1;
            _PassengerController.CancelRide(RideRequestMod.RideID);
            bool check = false;

            //EDGE CASE #1: creates ride request and successfully adds to database 
            //read from our database to check name has been added to the table
            using (var connection = new SqlConnection(_configuration.GetConnectionString("PantherPickup")))
            {
                SqlCommand command = new SqlCommand("SELECT isCancelled FROM rideRequest WHERE ridesId = '" + RideRequestMod.RideID + "'", connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();

                //if this reader executes, we know the name has been found in our database
                while (reader.Read())
                {
                    RideRequestMod.IsCancelled = reader["isCancelled"].ConvertFromDBVal<bool>();
                }
                if (RideRequestMod.IsCancelled == true)
                {
                    check = true;
                }
            }
            Assert.True(check);
            removeTestEntries();
        }
    }
}

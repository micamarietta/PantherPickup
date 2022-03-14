using NUnit.Framework;
using VacTrack.Controllers;
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
    public class AccountControllerTest
    {
        private IConfiguration _configuration;

        private readonly ILogger<AccountController> _logger;
        private AccountController _AccountController { get; set; } = null!;
        private AccountModel accountMod { get; set; } = null!;

        private static Random random = new Random();

        [SetUp]
        public void Setup()
        {
            IServiceCollection services = new ServiceCollection();

            var builder = new ConfigurationBuilder().AddJsonFile($"testsettings.json", optional: false);
            _configuration = builder.Build();
            services.AddSingleton<IConfiguration>(_configuration);

            _AccountController = new AccountController(_logger, _configuration);
            accountMod = new AccountModel();
        }

        //class for us to generate random name strings to test our database writing/reading
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //method for removing test entries from our database
        public void removeTestEntries()
        {
            var conn = new SqlConnection(_configuration.GetConnectionString("PantherPickup"));
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction(); ;

            try
            {
                var sql = string.Format("DELETE FROM person WHERE Name LIKE '%TEST%'");
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

        //testing our create function in AccountController
        //ensuring our input strings for login are accurately being added to the database

        [Test]
        public void CreateTest()
        {
            accountMod.Name = RandomString(7)  + "TEST";
            accountMod.Password = "testPassword";
            accountMod.Email = "test@chapman.edu";
            accountMod.Grade = "sophomore";
            accountMod.Major = "software engineeringTest";
            accountMod.IsPassenger = true;
            accountMod.Year = 2;
            _AccountController.Create(accountMod);
            bool dataAdded = false;

            //read from our database to check name has been added to the table
            using (var connection = new SqlConnection(_configuration.GetConnectionString("PantherPickup")))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM person WHERE name = '" + accountMod.Name + "'", connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();

                //if this reader executes, we know the name has been found in our database
                while (reader.Read())
                {
                    dataAdded = true;
                }
            }

            removeTestEntries();

            Assert.True(dataAdded);
            
        }
    }
}
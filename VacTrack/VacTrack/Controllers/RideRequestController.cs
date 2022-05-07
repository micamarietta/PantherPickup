using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using PantherPickup.Models;
using PantherPickup.Models.Account;
using PantherPickup.Utilities;
using PantherPickup.Models.RideRequest;

namespace PantherPickup.Controllers
{
    public class RideRequestController : Controller
    {
        private readonly ILogger<RideRequestController> _logger;
        private readonly IConfiguration Configuration;
        public static int passengerID = 0;

        public RideRequestController(ILogger<RideRequestController> logger, IConfiguration _configuration)
        {
            _logger = logger;
            Configuration = _configuration;
        }

        public ActionResult Index()
        {
            var model = new List<AccountModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM person WHERE email = 'marietta@chapman.edu' AND password = 'newPass'", connection);
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var item = new AccountModel();
                        item.pID = reader["pID"].ConvertFromDBVal<int>();
                        passengerID = item.pID;
                        item.Name = reader["name"].ConvertFromDBVal<string>();
                        item.Email = reader["email"].ConvertFromDBVal<string>();
                        item.IsPassenger = reader["isPassenger"].ConvertFromDBVal<bool>();
                        item.Major = reader["major"].ConvertFromDBVal<string>();

                        model.Add(item);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { ErrorMessage = ex.Message });
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(RideRequestModel model, AccountModel accModel)
        {
            var conn = new SqlConnection(Configuration.GetConnectionString("PantherPickup"));
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction(); ;
            try
            {
                //insert the new person
                Console.WriteLine(model.PassengerID);
                var sql = string.Format("INSERT INTO rideRequest (driverID, passengerId, dayTime, isCancelled, numPassengers, pickUpDest, dropOffDest, isCompleted) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}' ,'{5}', '{6}', '{7}')", model.DriverID, passengerID, model.Date, model.IsCancelled, model.NumPassengers, model.PickupLoc, model.DropOffLoc, model.IsCompleted);
                var command = new SqlCommand(sql, conn, trans);
                command.ExecuteNonQuery();
                trans.Commit();
                //redirect back to the list
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                trans.Rollback();
                return View("Error", new ErrorViewModel { ErrorMessage = ex.Message });
            }
            finally
            {
                conn.Close();
            }
        }


    }
}
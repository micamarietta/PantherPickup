using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using PantherPickup.Models.Account;
using PantherPickup.Utilities;
using PantherPickup.Models;
using PantherPickup.Models.RideRequest;
namespace VacTrack.Controllers
{
    public class DriverController : Controller
    {
        private readonly ILogger<DriverController> _logger;
        private readonly IConfiguration Configuration;
        public DriverController(ILogger<DriverController> logger, IConfiguration _configuration)
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
                    SqlCommand command = new SqlCommand("SELECT * FROM person WHERE email = 'chiggiechang@gmail.com' ", connection);
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var item = new AccountModel();
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

        public ActionResult Profile()
        {
            var model = new AccountModel();
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM person WHERE email = 'chiggiechang@gmail.com' ", connection);
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        model.Name = reader["name"].ConvertFromDBVal<string>();
                        model.Email = reader["email"].ConvertFromDBVal<string>();
                        model.IsPassenger = reader["isPassenger"].ConvertFromDBVal<bool>();
                        model.Major = reader["major"].ConvertFromDBVal<string>();
                        model.Year = reader["year"].ConvertFromDBVal<int>();
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { ErrorMessage = ex.Message });
            }
            return View(model);
        }

        public ActionResult Calendar()
        {
            //probably should take in a ride request model
            var model = new AccountModel();
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM person WHERE email = 'chiggiechang@gmail.com' ", connection);
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        model.Name = reader["name"].ConvertFromDBVal<string>();
                        model.Email = reader["email"].ConvertFromDBVal<string>();
                        model.IsPassenger = reader["isPassenger"].ConvertFromDBVal<bool>();
                        model.Major = reader["major"].ConvertFromDBVal<string>();
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { ErrorMessage = ex.Message });
            }
            return View(model);
        }


        [HttpGet]
        public ActionResult RideRate()
        {
            return View();
        }

        //passenger is rating the driver at the end of the ride
        [HttpPost]
        public ActionResult RideRate(int ID, RideRequestModel model)
        {
            //update ride to be completed 
            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
            {
                SqlCommand command = new SqlCommand("UPDATE rideRequest SET isCompleted = 1, passengerRating = " + model.PassengerRate + " WHERE ridesId = " + ID, connection);
                command.Connection.Open();
                var reader = command.ExecuteNonQuery();
            }

            int passengerId = 0;

            //grab the driver from the ride request, pass it in to our calculation for rating
            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
            {
                SqlCommand command3 = new SqlCommand("SELECT passengerId FROM rideRequest WHERE ridesId = " + ID, connection);
                command3.Connection.Open();
                var reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    passengerId = reader["passengerId"].ConvertFromDBVal<int>();
                }
            }

            //use the UpdatingRating method to calculate the aggregate for avg rating
            UpdateRating(passengerId);
            return RedirectToAction("Index", "Driver");
        }

        public ActionResult StartRide(int ID)
        {
            //return the correct view for the ride commencing
            var model = new RideRequestModel();

            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM rideRequest WHERE ridesId = " + ID, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.RideID = reader["ridesID"].ConvertFromDBVal<int>();
                    model.PickupLoc = reader["pickUpDest"].ConvertFromDBVal<string>();
                    model.Date = reader["dayTime"].ConvertFromDBVal<DateTime>();
                    model.DropOffLoc = reader["dropOffDest"].ConvertFromDBVal<string>();
                    model.DriverID = reader["driverId"].ConvertFromDBVal<int>();
                    model.NumPassengers = reader["numPassengers"].ConvertFromDBVal<int>();
                }
            }

            return View(model);
        }

        public ActionResult CancelRide(int ID)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
            {
                SqlCommand command = new SqlCommand("UPDATE rideRequest SET isCancelled = 1 WHERE ridesId = " + ID, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
            }
            return RedirectToAction("Index");
        }

        public void UpdateRating(int passengerId)
        {
            int avgRating = 0;

            //select all rides with specific driver to generate aggregate of average rides
            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
            {
                SqlCommand command = new SqlCommand("SELECT AVG(passengerRating) as averageRating FROM rideRequest WHERE passengerId = " + passengerId, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    avgRating = reader["averageRating"].ConvertFromDBVal<int>();
                }
            }

            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
            {
                SqlCommand command = new SqlCommand("UPDATE person SET rating = " + avgRating + "WHERE pID = " + passengerId, connection);
                command.Connection.Open();
                var reader = command.ExecuteNonQuery();
            }

        }

    }


}
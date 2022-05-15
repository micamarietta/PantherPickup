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
using PantherPickup.Models.Passenger;
using PantherPickup.Models.RideRequest;
using PantherPickup.Models.VaccinationLocation;

namespace PantherPickup.Controllers
{
    public class PassengerController : Controller
    {
        private readonly ILogger<PassengerController> _logger;
        private readonly IConfiguration Configuration;

        public PassengerController(ILogger<PassengerController> logger, IConfiguration _configuration)
        {
            _logger = logger;
            Configuration = _configuration;
        }

        public static int passengerID = 0;

        //pass in rideRequests for that specific person
        public ActionResult Index()
        {
            var model = new List<AccountModel>();
            var rideReqModel = new List<RideRequestModel>();
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

                using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
                {
                   
                    SqlCommand command = new SqlCommand("SELECT * FROM rideRequest WHERE passengerId = " + passengerID + "AND isCancelled = 0 AND isCompleted = 0", connection);
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var item = new RideRequestModel();
                        item.RideID = reader["ridesID"].ConvertFromDBVal<int>();
                        item.PickupLoc = reader["pickUpDest"].ConvertFromDBVal<string>();
                        item.Date = reader["dayTime"].ConvertFromDBVal<DateTime>();
                        item.DropOffLoc = reader["dropOffDest"].ConvertFromDBVal<string>(); 
                        item.DriverID = reader["driverId"].ConvertFromDBVal<int>();
                        item.NumPassengers = reader["numPassengers"].ConvertFromDBVal<int>();
                        item.PassengerRate = reader["passengerRating"].ConvertFromDBVal<int>();
                        item.DriverRate = reader["driverRating"].ConvertFromDBVal<int>();

                        rideReqModel.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { ErrorMessage = ex.Message });
            }
            return View(rideReqModel);
        }

        public ActionResult Profile()
        {
            var model = new AccountModel();
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM person WHERE email = 'marietta@chapman.edu' ", connection);
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
                    SqlCommand command = new SqlCommand("SELECT * FROM person WHERE email = 'marietta@chapman.edu' ", connection);
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
                SqlCommand command = new SqlCommand("UPDATE rideRequest SET isCompleted = 1, driverRating = " + model.DriverRate + " WHERE ridesId = " + ID, connection);
                command.Connection.Open();
                var reader = command.ExecuteNonQuery();
            }

            int driverID = 0;

            //grab the driver from the ride request, pass it in to our calculation for rating
            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
            {
                SqlCommand command3 = new SqlCommand("SELECT driverId FROM rideRequest WHERE ridesId = " + ID, connection);
                command3.Connection.Open();
                var reader = command3.ExecuteReader();
                while (reader.Read())
                {
                    driverID = reader["driverId"].ConvertFromDBVal<int>();
                }
            }

            //use the UpdatingRating method to calculate the aggregate for avg rating
            UpdateRating(driverID);
            return RedirectToAction("Index", "Passenger");
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

        public void UpdateRating(int driverId)
        {
            int avgRating = 0;

            //select all rides with specific driver to generate aggregate of average rides
            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
            {
                SqlCommand command = new SqlCommand("SELECT AVG(driverRating) as averageRating FROM rideRequest WHERE driverId = " + driverId, connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    avgRating = reader["averageRating"].ConvertFromDBVal<int>();
                }
            }

            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
            {
                SqlCommand command = new SqlCommand("UPDATE person SET rating = " + avgRating + "WHERE pID = 38", connection);
                command.Connection.Open();
                var reader = command.ExecuteNonQuery();
            }

        }

    }
}
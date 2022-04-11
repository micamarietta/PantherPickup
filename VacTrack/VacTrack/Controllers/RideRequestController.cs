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
using PantherPickup.Models.Patient;
using PantherPickup.Models.Passenger;
using PantherPickup.Models.VaccinationLocation;

namespace PantherPickup.Controllers
{
    public class RideRequestController : Controller
    {
        private readonly ILogger<RideRequestController> _logger;
        private readonly IConfiguration Configuration;

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
                    SqlCommand command = new SqlCommand("SELECT * FROM person WHERE email = 'marietta@chapman.edu' ", connection);
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

    }
}
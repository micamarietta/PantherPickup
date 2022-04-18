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
namespace VacTrack.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration Configuration;
        public AccountController(ILogger<AccountController> logger, IConfiguration _configuration)
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
                    SqlCommand command = new SqlCommand("SELECT * FROM person", connection);
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

        //create entry in our data base for a new account based on user info in the sign up page
        [HttpPost]
        public ActionResult Create(AccountModel model)
        {
            var conn = new SqlConnection(Configuration.GetConnectionString("PantherPickup"));
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction(); ;
            try
            {
                //insert the new person
                Console.WriteLine(model.Name);
                var sql = string.Format("INSERT INTO person (name, password, email, grade, major, isPassenger, year) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}' ,'{5}', '{6}')", model.Name, model.Password, model.Email, model.Grade, model.Major, model.IsPassenger, model.Year);
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
        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginModel());
        }
        [HttpPost]
        public ActionResult Login(LoginModel model, AccountModel accModel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM person WHERE email = '" + model.Email + "' AND password = '" + model.Password + "'", connection);
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (isPassenger(model))
                        {

                            return Redirect("~/Passenger/Index");
                        }
                        else
                        {
                            return Redirect("~/Driver/Index");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // return View("Error", new ErrorViewModel { ErrorMessage = ex.Message });
            }
            return View("Login", new LoginModel { Email = model.Email, ErrorMessage = "Username or password not found." });
        }
        public bool isPassenger(LoginModel model)
        {
            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
            {
                SqlCommand command = new SqlCommand("SELECT isPassenger FROM person WHERE email = '" + model.Email + "' AND password = '" + model.Password + "'", connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //if our user is a passenger
                    var item = new AccountModel();
                    String test;
                    test = Convert.ToString(reader["isPassenger"]);
                    
;
                    if (test == "True")
                    {

                       return true;
                    }
                    //if our user is a driver
                    else
                    {
                        return false;
                    }
                }
            }
           return false;
        }

       /* public AccountModel readModel(LoginModel model)
        {
            AccountModel returnModel = new AccountModel();

            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
            {
               SqlCommand command = new SqlCommand("SELECT * FROM person WHERE email = '" + model.Email + "' AND password = '" + model.Password + "'", connection);
               command.Connection.Open();
               var reader = command.ExecuteReader();
               while (reader.Read())
               {
                   returnModel.Name = (string)reader["name"];
                   returnModel.Email = (string)reader["email"];
                   returnModel.IsPassenger = (string)reader["isPassenger"];
                   returnModel.Major = (string)reader["major"];
                }
            }

            return returnModel;
    }*/

    }
}
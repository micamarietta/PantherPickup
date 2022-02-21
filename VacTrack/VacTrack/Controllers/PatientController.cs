using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using VacTrack.Models;
using VacTrack.Models.Common;
using VacTrack.Models.Patient;

namespace VacTrack.Controllers
{
    public class PatientController : Controller
    {
        private readonly IConfiguration Configuration;

        public PatientController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        // GET: Patient
        /// <summary>
        /// Show the index view with the list of records.
        /// </summary>
        public ActionResult Index()
        {
            //connect to our SQL database
            //display patient data that isnt deleted
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = "SELECT * FROM Patient WHERE IsDeleted != 1";
            var command = new MySqlCommand(sql, conn);
            var model = new List<PatientModel>();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();

                //display our data
                while (reader.Read())
                {
                    var item = new PatientModel();
                    item.PatientID = (int)reader["PatientID"];
                    item.FirstName = (string)reader["FirstName"];
                    item.LastName = (string)reader["LastName"];
                    item.Age = (int)reader["Age"];
                    item.ZipCode = (string)reader["ZipCode"];
                    model.Add(item);    
                }
            }

            //display our errors on the site in case the correct page doesn't load
            catch(Exception ex)
            {
                return View("Error", new ErrorViewModel { ErrorMessage = ex.Message });
            }
            finally
            {
                conn.Close();
            }

            return View(model);
        }

        // POST: Patient
        /// <summary>
        /// Show the index view with the list of records.
        /// </summary>
        [HttpPost]
        public ActionResult Index(SearchModel postModel)
        {
            //connect to our SQL database
            //display patient data that isnt deleted
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = string.Format(
                "SELECT * FROM Patient WHERE IsDeleted != 1 AND PatientID IN (SELECT PatientID FROM Patient WHERE FirstName LIKE '%{0}%' OR LastName LIKE '%{0}%') ",
                postModel.Query);

            var command = new MySqlCommand(sql, conn);
            var model = new List<PatientModel>();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();

                //display our data
                while (reader.Read())
                {
                    var item = new PatientModel();
                    item.PatientID = (int)reader["PatientID"];
                    item.FirstName = (string)reader["FirstName"];
                    item.LastName = (string)reader["LastName"];
                    item.Age = (int)reader["Age"];
                    item.ZipCode = (string)reader["ZipCode"];
                    model.Add(item);
                }
            }

            //display our errors on the site in case the correct page doesn't load
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { ErrorMessage = ex.Message });
            }
            finally
            {
                conn.Close();
            }

            return View(model);
        }

        // GET: Patient/Details/5
        /// <summary>
        /// Show the details view.
        /// </summary>
        [HttpGet]
        public ActionResult Details(int id)
        {
            //show details for a specific patient that the user has clicked on
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = string.Format("SELECT * FROM Patient WHERE PatientID = {0}", id);
            var command = new MySqlCommand(sql, conn);
            var model = new PatientModel();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.PatientID = (int)reader["PatientID"];
                    model.FirstName = (string)reader["FirstName"];
                    model.LastName = (string)reader["LastName"];
                    model.Age = (int)reader["Age"];
                    model.ZipCode = (string)reader["ZipCode"];
                }
            }
            catch(Exception ex)
            {
                return View("Error", new ErrorViewModel { ErrorMessage = ex.Message });
            }
            finally
            {
                conn.Close();
            }

            return View(model);
        }


        // GET: Patient/Create
        /// <summary>
        /// Show the create view.
        /// </summary>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        /// <summary>
        /// Insert a new record.
        /// </summary>
        [HttpPost]
        public ActionResult Create(PatientModel model)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();;
            try
            {
                // insert the new patient
                var sql = string.Format(
                    "INSERT INTO Patient (FirstName, LastName, Age, ZipCode) VALUES ('{0}', '{1}', {2}, '{3}')",
                    model.FirstName,
                    model.LastName,
                    model.Age,
                    model.ZipCode);
                var command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                trans.Commit();
                // redirect back to the patient list
                return RedirectToAction(nameof(Index));
            }

            //UTILIZE ROLLBACK in the case that there is an error
            catch(Exception ex)
            {
                trans.Rollback();
                return View("Error", new ErrorViewModel { ErrorMessage = ex.Message });

            }
            finally
            {
                conn.Close();
            }
        }

        // GET: Patient/Edit/5
        /// <summary>
        /// Show the edit view.
        /// </summary>
        public ActionResult Edit(int id)
        {

            //enable the user to edit patient data
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = string.Format("SELECT * FROM Patient WHERE PatientID = {0}", id);
            var command = new MySqlCommand(sql, conn);
            var model = new PatientModel();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.PatientID = (int)reader["PatientID"];
                    model.FirstName = (string)reader["FirstName"];
                    model.LastName = (string)reader["LastName"];
                    model.Age = (int)reader["Age"];
                    model.ZipCode = (string)reader["ZipCode"];
                }
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { ErrorMessage = ex.Message });
            }
            finally
            {
                conn.Close();
            }

            return View(model);
        }

        // POST: Patient/Edit/5
        /// <summary>
        /// Update the requested record.
        /// </summary>
        [HttpPost]
        public ActionResult Edit(int id, PatientModel model)
        {
            //enable the user to edit patient data
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                // update the existing record
                var sql = string.Format(
                    "UPDATE Patient SET FirstName = '{0}', LastName = '{1}', Age = {2}, ZipCode = '{3}' WHERE PatientID = {4}",
                    model.FirstName,
                    model.LastName,
                    model.Age,
                    model.ZipCode,
                    id);
                var command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                trans.Commit();

                // redirect back to the index
                return RedirectToAction(nameof(Index));
            }

            //utilize ROLLBACK in case there is an error
            catch(Exception ex)
            {
                trans.Rollback();
                return View("Error", new ErrorViewModel { ErrorMessage = ex.Message } );
            }
            finally
            {
                conn.Close();
            }
        }

        // GET: Patient/Delete/5
        /// <summary>
        /// Show the delete view.
        /// </summary>
        public ActionResult Delete(int id)
        {
            //enable the user to delete a pateint from the database
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = string.Format("SELECT * FROM Patient WHERE PatientID = {0}", id);
            var command = new MySqlCommand(sql, conn);
            var model = new PatientModel();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.PatientID = (int)reader["PatientID"];
                    model.FirstName = (string)reader["FirstName"];
                    model.LastName = (string)reader["LastName"];
                    model.Age = (int)reader["Age"];
                    model.ZipCode = (string)reader["ZipCode"];
                }
            }
            catch (Exception ex)
            {
                return View("Error", new ErrorViewModel { ErrorMessage = ex.Message });
            }
            finally
            {
                conn.Close();
            }

            return View(model);
        }

        // POST: Patient/Delete/5
        /// <summary>
        /// Delete the requested record. Redirect back to index.
        /// </summary>
        [HttpPost]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                // soft-delete the existing record
                var sql = string.Format("UPDATE Patient set IsDeleted = 1 where PatientID = {0}", id);
                var command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                trans.Commit();
                // redirect back to the vaccine list
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
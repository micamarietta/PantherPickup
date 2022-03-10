using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using PantherPickup.Models;
using PantherPickup.Models.Patient;
using PantherPickup.Models.Passenger;
using PantherPickup.Models.VaccinationLocation;

namespace PantherPickup.Controllers
{
    public class Passening PantherPickup.Models.PassengerController : Controller
    {
        private readonly IConfiguration Configuration;

        public PassengerController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }


        // GET: Appointment
        /// <summary>
        /// Show the index view with the list of records.
        /// </summary>
        public ActionResult Index()
        {
            
            var model = new List<PassengerModel>();
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM passengers", connection);
                    command.Connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var item = new PassengerModel();
                        item.PassengerName = (string)reader["pName"];
                        model.Add(item);
                    }
                }
            }
            catch(Exception ex)
            {
                return View("Error", new ErrorViewModel { ErrorMessage = ex.Message });
            }

            return View(model);
        }
        /*
        // GET: Appointment/Details/5
        /// <summary>
        /// Show the details view.
        /// </summary>
        [HttpGet]
        public ActionResult Details(int id)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("PantherPickup"));
            var sql = string.Format("SELECT * FROM appointment_view WHERE AppointmentID = {0}", id);
            var command = new MySqlCommand(sql, conn);
            var model = new PassengerModel();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.AppointmentID = (int)reader["AppointmentID"];
                    model.DateTime = (DateTime)reader["DateTime"];
                    model.VaccinationLocationID = (int)reader["VaccinationLocationID"];
                    model.PatientID = (int)reader["PatientID"];
                    model.Patient.FirstName = (string)reader["FirstName"];
                    model.Patient.LastName = (string)reader["LastName"];
                    model.VaccinationLocation.Location.LocationID = (int)reader["LocationID"];
                    model.VaccinationLocation.Vaccine.VaccineID = (int)reader["VaccineID"];
                    model.VaccinationLocation.LocationID = (int)reader["LocationID"];
                    model.VaccinationLocation.Location.LocationID = (int)reader["LocationID"];
                    model.VaccinationLocation.Location.LocationName = (string)reader["LocationName"];
                    model.VaccinationLocation.Location.Address = (string)reader["Address"];
                    model.VaccinationLocation.VaccineID = (int)reader["VaccineID"];
                    model.VaccinationLocation.Vaccine.VaccineID = (int)reader["VaccineID"];
                    model.VaccinationLocation.Vaccine.Name = (string)reader["Name"];
                }

                PopulateVaccinationLocations(model);
                PopulatePatients(model);
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


        // GET: Appointment/Create
        /// <summary>
        /// Show the create view.
        /// </summary>
        [HttpGet]
        public ActionResult Create()
        {
            var model = new PassengerModel();
            PopulateVaccinationLocations(model);
            PopulatePatients(model);
            return View(model);
        }

        // POST: Appointment/Create
        /// <summary>
        /// Insert a new record.
        /// </summary>
        [HttpPost]
        public ActionResult Create(PassengerModel model)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();;
            try
            {
                // insert the new appointment

                var sql = string.Format("INSERT INTO Appointment (PatientID, DateTime, VaccinationLocationID) VALUES ({0}, '{1}', {2})", model.PatientID, model.DateTime.ToString("yyyy-MM-dd HH:mm:ss"), model.VaccinationLocationID);
                var command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                trans.Commit();
                // redirect back to the appointment list
                return RedirectToAction(nameof(Index));
            }
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

        // GET: appointment/Edit/5
        /// <summary>
        /// Show the edit view.
        /// </summary>
        public ActionResult Edit(int id)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = string.Format("SELECT * FROM appointment_view WHERE AppointmentID = {0}", id);
            var command = new MySqlCommand(sql, conn);
            var model = new PassengerModel();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.AppointmentID = (int)reader["AppointmentID"];
                    model.DateTime = (DateTime)reader["DateTime"];
                    model.VaccinationLocationID = (int)reader["VaccinationLocationID"];
                    model.PatientID = (int)reader["PatientID"];
                    model.Patient.FirstName = (string)reader["FirstName"];
                    model.Patient.LastName = (string)reader["LastName"];
                    model.VaccinationLocation.Location.LocationID = (int)reader["LocationID"];
                    model.VaccinationLocation.Vaccine.VaccineID = (int)reader["VaccineID"];
                    model.VaccinationLocation.LocationID = (int)reader["LocationID"];
                    model.VaccinationLocation.Location.LocationID = (int)reader["LocationID"];
                    model.VaccinationLocation.Location.LocationName = (string)reader["LocationName"];
                    model.VaccinationLocation.Location.Address = (string)reader["Address"];
                    model.VaccinationLocation.VaccineID = (int)reader["VaccineID"];
                    model.VaccinationLocation.Vaccine.VaccineID = (int)reader["VaccineID"];
                    model.VaccinationLocation.Vaccine.Name = (string)reader["Name"];
                }

                PopulateVaccinationLocations(model);
                PopulatePatients(model);
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

        // POST: appointment/Edit/5
        /// <summary>
        /// Update the requested record.
        /// </summary>
        [HttpPost]
        public ActionResult Edit(int id, PassengerModel model)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                // update the existing record
                var sql = string.Format(
                    "UPDATE Appointment SET VaccinationLocationID = {0}, PatientID = {1}, DateTime = {2} WHERE AppointmentID = {3}",
                    model.VaccinationLocationID,
                    model.PatientID,
                    model.DateTime,
                    id);
                var command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                trans.Commit();

                // redirect back to the index
                return RedirectToAction(nameof(Index));
            }
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

        // GET: appointment/Delete/5
        /// <summary>
        /// Show the delete view.
        /// </summary>
        public ActionResult Delete(int id)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = string.Format("SELECT * FROM appointment_view WHERE AppointmentID = {0}", id);
            var command = new MySqlCommand(sql, conn);
            var model = new PassengerModel();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.AppointmentID = (int)reader["AppointmentID"];
                    model.DateTime = (DateTime)reader["DateTime"];
                    model.VaccinationLocationID = (int)reader["VaccinationLocationID"];
                    model.PatientID = (int)reader["PatientID"];
                    model.Patient.FirstName = (string)reader["FirstName"];
                    model.Patient.LastName = (string)reader["LastName"];
                    model.VaccinationLocation.Location.LocationID = (int)reader["LocationID"];
                    model.VaccinationLocation.Vaccine.VaccineID = (int)reader["VaccineID"];
                    model.VaccinationLocation.LocationID = (int)reader["LocationID"];
                    model.VaccinationLocation.Location.LocationID = (int)reader["LocationID"];
                    model.VaccinationLocation.Location.LocationName = (string)reader["LocationName"];
                    model.VaccinationLocation.Location.Address = (string)reader["Address"];
                    model.VaccinationLocation.VaccineID = (int)reader["VaccineID"];
                    model.VaccinationLocation.Vaccine.VaccineID = (int)reader["VaccineID"];
                    model.VaccinationLocation.Vaccine.Name = (string)reader["Name"];
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

        // POST: appointment/Delete/5
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
                var sql = string.Format("UPDATE Appointment set IsDeleted = 1 where AppointmentID = {0}", id);
                var command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                trans.Commit();
                // redirect back to the appointment list
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

        /// <summary>
        /// Populates the vaccination locations of a model
        /// </summary>
        /// <param name="model"></param>
        private void PopulateVaccinationLocations(PassengerModel model)
        {
            model.VaccinationLocations = new List<Models.VaccinationLocation.VaccinationLocationModel>();
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = "SELECT * FROM vacclocation_view";
            var command = new MySqlCommand(sql, conn);
            conn.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var item = new VaccinationLocationModel();
                item.VaccinationLocationID = (int)reader["VaccinationLocationID"];
                item.LocationID = (int)reader["LocationID"];
                item.Location.LocationName = (string)reader["LocationName"];
                item.Location.Address = (string)reader["Address"];
                item.Location.City = (string)reader["City"];
                item.Location.State = (string)reader["State"];
                item.Location.ZipCode = (string)reader["Zipcode"];
                item.VaccineID = (int)reader["VaccineID"];
                item.Vaccine.Name = (string)reader["Name"];
                model.VaccinationLocations.Add(item);
            }
            conn.Close();
        }

        private void PopulatePatients(PassengerModel model)
        {
            model.Patients = new List<Models.Patient.PatientModel>();
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = "SELECT * FROM Patient WHERE IsDeleted = 0";
            var command = new MySqlCommand(sql, conn);
            conn.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var item = new PatientModel();
                item.PatientID = (int)reader["PatientID"];
                item.FirstName = (string)reader["FirstName"];
                item.LastName = (string)reader["LastName"];
                item.Age = (int)reader["Age"];
                model.Patients.Add(item);
            }
            conn.Close();
        }
        */
    }
}
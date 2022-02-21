using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using VacTrack.Models;
using VacTrack.Models.Location;
using VacTrack.Models.VaccinationLocation;
using VacTrack.Models.Vaccine;

namespace VacTrack.Controllers
{
    public class VaccinationLocationController : Controller
    {
        private readonly IConfiguration Configuration;

        public VaccinationLocationController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        // GET: Vaccine
        /// <summary>
        /// Show the index view with the list of records.
        /// </summary>
        public ActionResult Index()
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = "SELECT * FROM vacclocation_view";
            var command = new MySqlCommand(sql, conn);
            var model = new List<VaccinationLocationModel>();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new VaccinationLocationModel();
                    item.VaccinationLocationID = (int)reader["VaccinationLocationID"];
                    item.Location.LocationName = (string)reader["LocationName"];
                    item.Location.Address = (string)reader["Address"];
                    item.Location.City = (string)reader["City"];
                    item.Location.State = (string)reader["State"];
                    item.Location.ZipCode = (string)reader["Zipcode"];
                    item.Vaccine.Name = (string)reader["Name"];

                    model.Add(item);    
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

        // GET: Vaccine/Details/5
        /// <summary>
        /// Show the details view.
        /// </summary>
        [HttpGet]
        public ActionResult Details(int id)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = string.Format("SELECT * FROM vacclocation_view WHERE VaccinationLocationID = {0}", id);
            var command = new MySqlCommand(sql, conn);
            var model = new VaccinationLocationModel();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.VaccinationLocationID = (int)reader["VaccinationLocationID"];
                    model.Location.LocationName = (string)reader["LocationName"];
                    model.Location.Address = (string)reader["Address"];
                    model.Location.City = (string)reader["City"];
                    model.Location.State = (string)reader["State"];
                    model.Location.ZipCode = (string)reader["Zipcode"];
                    model.Vaccine.Name = (string)reader["Name"];
                }

                PopulateLocations(model);
                PopulateVaccines(model);
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


        // GET: VaccineLocation/Create
        /// <summary>
        /// Show the create view.
        /// </summary>
        [HttpGet]
        public ActionResult Create()
        {
            var model = new VaccinationLocationModel();
            PopulateLocations(model);
            PopulateVaccines(model);
            return View(model);
        }

        // POST: VaccineLocation/Create
        /// <summary>
        /// Insert a new record.
        /// </summary>
        [HttpPost]
        public ActionResult Create(VaccinationLocationModel model)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();;
            try
            {
                // insert the new Vaccination location

                var sql = string.Format("INSERT INTO VaccinationLocation (LocationID, VaccineID) VALUES ('{0}', {1})", model.LocationID, model.VaccineID);
                var command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                trans.Commit();
                // redirect back to the vaccinelocation list
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

        // GET: VaccineLocation/Edit/5
        /// <summary>
        /// Show the edit view.
        /// </summary>
        public ActionResult Edit(int id)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = string.Format("SELECT * FROM vacclocation_view WHERE VaccinationLocationID = {0}", id);
            var command = new MySqlCommand(sql, conn);
            var model = new VaccinationLocationModel();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.VaccinationLocationID = (int)reader["VaccinationLocationID"];
                    model.LocationID = (int)reader["LocationID"];
                    model.Location.LocationID = (int)reader["LocationID"];
                    model.Location.LocationName = (string)reader["LocationName"];
                    model.Location.Address = (string)reader["Address"];
                    model.Location.City = (string)reader["City"];
                    model.Location.State = (string)reader["State"];
                    model.Location.ZipCode = (string)reader["Zipcode"];
                    model.VaccineID = (int)reader["VaccineID"];
                    model.Vaccine.VaccineID = (int)reader["VaccineID"];
                    model.Vaccine.Name = (string)reader["Name"];
                }

                PopulateLocations(model);
                PopulateVaccines(model);

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

        // POST: VaccineLocation/Edit/5
        /// <summary>
        /// Update the requested record.
        /// </summary>
        [HttpPost]
        public ActionResult Edit(int id, VaccinationLocationModel model)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                // update the existing record
                var sql = string.Format(
                    "UPDATE VaccinationLocation SET LocationID = {0}, VaccineID = {1} WHERE VaccinationLocationID = {2}",
                    model.LocationID,
                    model.VaccineID,
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

        // GET: VaccineLocation/Delete/5
        /// <summary>
        /// Show the delete view.
        /// </summary>
        public ActionResult Delete(int id)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = string.Format("SELECT * FROM vaccLocation_view WHERE VaccinationLocationID = {0}", id);
            var command = new MySqlCommand(sql, conn);
            var model = new VaccinationLocationModel();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.VaccinationLocationID = (int)reader["VaccinationLocationID"];
                    model.Location.LocationID = (int)reader["LocationID"];
                    model.Location.LocationName = (string)reader["LocationName"];
                    model.Location.Address = (string)reader["Address"];
                    model.Location.City = (string)reader["City"];
                    model.Location.State = (string)reader["State"];
                    model.Location.ZipCode = (string)reader["Zipcode"];
                    model.Vaccine.Name = (string)reader["Name"];
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

        // POST: VaccineLocation/Delete/5
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
                var sql = string.Format("DELETE from VaccinationLocation where VaccinationLocationID = {0}", id);
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

        /// <summary>
        /// Populates the locations of a model
        /// </summary>
        /// <param name="model"></param>
        private void PopulateLocations(VaccinationLocationModel model)
        {
            model.Locations = new List<Models.Location.LocationModel>();
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = "SELECT * FROM Location WHERE IsDeleted = 0";
            var command = new MySqlCommand(sql, conn);
            conn.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var item = new LocationModel();
                item.LocationID = (int)reader["LocationID"];
                item.LocationName = (string)reader["LocationName"];
                item.Address = (string)reader["Address"];
                item.City = (string)reader["City"];
                item.State = (string)reader["State"];
                item.ZipCode = (string)reader["Zipcode"];
                model.Locations.Add(item);
            }
            conn.Close();
        }

        /// <summary>
        /// Populates the vaccines of a model
        /// </summary>
        /// <param name="model"></param>
        private void PopulateVaccines(VaccinationLocationModel model)
        {
            model.Vaccines = new List<Models.Vaccine.VaccineModel>();
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = "SELECT * FROM Vaccine WHERE IsDeleted = 0";
            var command = new MySqlCommand(sql, conn);
            conn.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var item = new VaccineModel();
                item.VaccineID = (int)reader["VaccineID"];
                item.Name = (string)reader["Name"];
                model.Vaccines.Add(item);
            }
            conn.Close();
        }
    }
}
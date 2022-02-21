using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using VacTrack.Models;
using VacTrack.Models.Location;

namespace VacTrack.Controllers
{
    public class LocationController : Controller
    {
        private readonly IConfiguration Configuration;

        public LocationController(IConfiguration _configuration)
        {
            Configuration = _configuration;
        }

        // GET: Location
        /// <summary>
        /// Show the index view with the list of records.
        /// </summary>
        public ActionResult Index()
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = "SELECT * FROM location WHERE IsDeleted != 1";
            var command = new MySqlCommand(sql, conn);
            var model = new List<LocationModel>();
            try
            {
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

        // GET: Location/Details/5
        /// <summary>
        /// Show the details view.
        /// </summary>
        [HttpGet]
        public ActionResult Details(int id)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = string.Format("SELECT * FROM location WHERE LocationID = {0}", id);
            var command = new MySqlCommand(sql, conn);
            var model = new LocationModel();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.LocationID = (int)reader["LocationID"];
                    model.LocationName = (string)reader["LocationName"];
                    model.Address = (string)reader["Address"];
                    model.City = (string)reader["City"];
                    model.State = (string)reader["State"];
                    model.ZipCode = (string)reader["Zipcode"];
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


        // GET: Location/Create
        /// <summary>
        /// Show the create view.
        /// </summary>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create
        /// <summary>
        /// Insert a new record.
        /// </summary>
        [HttpPost]
        public ActionResult Create(LocationModel model)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();;
            try
            {
                // insert the new location

                var sql = string.Format("INSERT INTO Location (LocationName, Address, City, State, Zipcode) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}')", model.LocationName, model.Address, model.City, model.State, model.ZipCode);
                var command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                trans.Commit();
                // redirect back to the location list
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

        // GET: Location/Edit/5
        /// <summary>
        /// Show the edit view.
        /// </summary>
        public ActionResult Edit(int id)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = string.Format("SELECT * FROM Location WHERE LocationID = {0}", id);
            var command = new MySqlCommand(sql, conn);
            var model = new LocationModel();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.LocationID = (int)reader["LocationID"];
                    model.LocationName = (string)reader["LocationName"];
                    model.Address = (string)reader["Address"];
                    model.City = (string)reader["City"];
                    model.State = (string)reader["State"];
                    model.ZipCode = (string)reader["Zipcode"];
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

        // POST: Location/Edit/5
        /// <summary>
        /// Update the requested record.
        /// </summary>
        [HttpPost]
        public ActionResult Edit(int id, LocationModel model)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                // update the existing record
                var sql = string.Format(
                    "UPDATE Location SET LocationName = '{0}', Address = '{1}', City = '{2}', State = '{3}', Zipcode = '{4}' WHERE LocationID = {5}",
                    model.LocationName,
                    model.Address,
                    model.City,
                    model.State,
                    model.ZipCode,
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

        // GET: Location/Delete/5
        /// <summary>
        /// Show the delete view.
        /// </summary>
        public ActionResult Delete(int id)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = string.Format("SELECT * FROM location WHERE LocationID = {0}", id);
            var command = new MySqlCommand(sql, conn);
            var model = new LocationModel();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.LocationID = (int)reader["LocationID"];
                    model.LocationName = (string)reader["LocationName"];
                    model.Address = (string)reader["Address"];
                    model.City = (string)reader["City"];
                    model.State = (string)reader["State"];
                    model.ZipCode = (string)reader["Zipcode"];
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

        // POST: Location/Delete/5
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
                var sql = string.Format("UPDATE Location set IsDeleted = 1 where LocationID = {0}", id);
                var command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                trans.Commit();
                // redirect back to the location list
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
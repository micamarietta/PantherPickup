using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using VacTrack.Models;
using VacTrack.Models.Vaccine;

namespace VacTrack.Controllers
{
    public class VaccineController : Controller
    {
        private readonly IConfiguration Configuration;

        public VaccineController(IConfiguration _configuration)
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
            var sql = "SELECT * FROM vaccine WHERE IsDeleted != 1";
            var command = new MySqlCommand(sql, conn);
            var model = new List<VaccineModel>();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new VaccineModel();
                    item.VaccineID = (int)reader["VaccineID"];
                    item.Name = (string)reader["Name"];
                    if (reader["NumOfDoses"] != DBNull.Value)
                    {
                        item.NumOfDoses = (int)reader["NumOfDoses"];
                    }
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
            var sql = string.Format("SELECT * FROM vaccine WHERE VaccineID = {0}", id);
            var command = new MySqlCommand(sql, conn);
            var model = new VaccineModel();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.VaccineID = (int)reader["VaccineID"];
                    model.Name = (string)reader["Name"];
                    if(reader["NumOfDoses"] != DBNull.Value)
                    {
                        model.NumOfDoses = (int)reader["NumOfDoses"];
                    }
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


        // GET: Vaccine/Create
        /// <summary>
        /// Show the create view.
        /// </summary>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vaccine/Create
        /// <summary>
        /// Insert a new record.
        /// </summary>
        [HttpPost]
        public ActionResult Create(VaccineModel model)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();;
            try
            {
                // insert the new vaccine

                //if the numOfDoses is empty, set it equal to null

                var numOfDosesSQL = "null";
                if (model.NumOfDoses.HasValue) {
                    numOfDosesSQL = model.NumOfDoses.ToString();
                }

                var sql = string.Format("INSERT INTO Vaccine (Name, NumOfDoses) VALUES ('{0}', {1})", model.Name, numOfDosesSQL);
                var command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();
                trans.Commit();
                // redirect back to the vaccine list
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

        // GET: Vaccine/Edit/5
        /// <summary>
        /// Show the edit view.
        /// </summary>
        public ActionResult Edit(int id)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = string.Format("SELECT * FROM Vaccine WHERE VaccineID = {0}", id);
            var command = new MySqlCommand(sql, conn);
            var model = new VaccineModel();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.VaccineID = (int)reader["VaccineID"];
                    model.Name = (string)reader["Name"];
                    if (reader["NumOfDoses"] != DBNull.Value)
                    {
                        model.NumOfDoses = (int)reader["NumOfDoses"];
                    }
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

        // POST: Vaccine/Edit/5
        /// <summary>
        /// Update the requested record.
        /// </summary>
        [HttpPost]
        public ActionResult Edit(int id, VaccineModel model)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            conn.Open();
            MySqlTransaction trans = conn.BeginTransaction();
            try
            {
                // update the existing record
                var sql = string.Format(
                    "UPDATE Vaccine SET Name = '{0}', NumOfDoses = {1} WHERE VaccineID = {2}",
                    model.Name,
                    model.NumOfDoses,
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

        // GET: Vaccine/Delete/5
        /// <summary>
        /// Show the delete view.
        /// </summary>
        public ActionResult Delete(int id)
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            var sql = string.Format("SELECT * FROM vaccine WHERE VaccineID = {0}", id);
            var command = new MySqlCommand(sql, conn);
            var model = new VaccineModel();
            try
            {
                conn.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.VaccineID = (int)reader["VaccineID"];
                    model.Name = (string)reader["Name"];
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

        // POST: Vaccine/Delete/5
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
                var sql = string.Format("UPDATE Vaccine set IsDeleted = 1 where VaccineID = {0}", id);
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
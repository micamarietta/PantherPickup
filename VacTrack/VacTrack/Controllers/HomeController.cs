using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using VacTrack.Models;
using VacTrack.Models.Appointment;
using VacTrack.Models.Home;
using VacTrack.Models.Location;
using VacTrack.Models.Patient;
using VacTrack.Models.VaccinationLocationDownload;
using VacTrack.Models.Vaccine;

namespace VacTrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IConfiguration Configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration _configuration)
        {
            _logger = logger;
            Configuration = _configuration;
        }

        public IActionResult Index()
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            string sql;
            MySqlDataReader reader;
            MySqlCommand command;

            // model for the homepage
            var model = new HomeModel();
            try
            {
                // get vaccine count
                conn.Open();
                sql = "SELECT COUNT(*) AS VaccineCount FROM Vaccine WHERE IsDeleted != 1";
                command = new MySqlCommand(sql, conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.VaccineCount = (Int64)reader["VaccineCount"];
                }
                conn.Close();

                // get patient count
                conn.Open();
                sql = "SELECT COUNT(*) AS PatientCount FROM Patient WHERE IsDeleted != 1";
                command = new MySqlCommand(sql, conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.PatientCount = (Int64)reader["PatientCount"];
                }
                conn.Close();

                // get appointment count
                conn.Open();
                sql = "SELECT COUNT(*) AS AppointmentCount FROM Appointment WHERE IsDeleted != 1";
                command = new MySqlCommand(sql, conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    model.AppointmentCount = (Int64)reader["AppointmentCount"];
                }
                conn.Close();

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        /// <summary>
        /// Download function is used in order to generate excel files
        /// </summary>
        /// <returns></returns>
        public ActionResult Download()
        {
            var conn = new MySqlConnection(Configuration.GetConnectionString("VacTrack"));
            string sql;
            MySqlDataReader reader;
            MySqlCommand command;

            //data for for each of the tables
            var appData = new List<AppointmentDownloadModel>();
            var vaccLocData = new List<VaccinationLocationDownloadModel>();
            var vaccineData = new List<VaccineModel>();
            var locationData = new List<LocationModel>();
            var patientData = new List<PatientModel>();
            try
            {

                //read appointment data
                conn.Open();
                sql = "SELECT * FROM appointment_view";
                command = new MySqlCommand(sql, conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new AppointmentDownloadModel
                    {
                        AppointmentID = (int)reader["AppointmentID"],
                        DateTime = ((DateTime)reader["DateTime"]).ToString("MM/dd/yyyy h:mm tt"),
                        PatientID = (int)reader["PatientID"],
                        PatientFirstName = (string)reader["FirstName"],
                        PatientLastName = (string)reader["LastName"],
                        VaccineName = (string)reader["Name"],
                        LocationName = (string)reader["LocationName"]
                    };
                    appData.Add(item);
                }
                conn.Close();


                //read vaccination location data
                conn.Open();
                sql = "SELECT * FROM vaccLocation_view";
                command = new MySqlCommand(sql, conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new VaccinationLocationDownloadModel
                    {
                        VaccinationLocationID = (int)reader["VaccinationLocationID"],
                        LocationID = (int)reader["LocationID"],
                        LocationName = (string)reader["LocationName"],
                        VaccineID = (int)reader["VaccineID"],
                        VaccineName = (string)reader["Name"],

                    };
                    vaccLocData.Add(item);
                }
                conn.Close();


                //read vaccine data
                conn.Open();
                sql = "SELECT * FROM vaccine";
                command = new MySqlCommand(sql, conn);
                reader = command.ExecuteReader();
                while(reader.Read())
                {
                    var item = new VaccineModel
                    {
                        VaccineID = (int)reader["VaccineID"],
                        Name = (string)reader["Name"],
                        NumOfDoses = (int)reader["NumOfDoses"]
                    };
                    vaccineData.Add(item);
                }
                conn.Close();


                //read location data
                conn.Open();
                sql = "SELECT * FROM location";
                command = new MySqlCommand(sql, conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new LocationModel
                    {
                        LocationID = (int)reader["LocationID"],
                        LocationName = (string)reader["LocationName"],
                        Address = (string)reader["Address"],
                        City = (string)reader["City"],
                        State = (string)reader["State"],
                        ZipCode = (string)reader["Zipcode"],
                    };
                    locationData.Add(item);
                }
                conn.Close();

                //read patient data
                conn.Open();
                sql = "SELECT * FROM patient";
                command = new MySqlCommand(sql, conn);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var item = new PatientModel
                    {
                        PatientID = (int)reader["PatientID"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Age = (int)reader["Age"],
                        ZipCode = (string)reader["Zipcode"],
                    };
                    patientData.Add(item);
                }

                //add the data to respective tabs in an excel sheet
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage())
                {
                    var aSheet = package.Workbook.Worksheets.Add("Appointments");
                    aSheet.Cells["A1"].LoadFromCollection(appData, true, TableStyles.Medium9);

                    var vlSheet = package.Workbook.Worksheets.Add("Vaccination Locations");
                    vlSheet.Cells["A1"].LoadFromCollection(vaccLocData, true, TableStyles.Medium9);

                    var vSheet = package.Workbook.Worksheets.Add("Vaccines");
                    vSheet.Cells["A1"].LoadFromCollection(vaccineData, true, TableStyles.Medium9);

                    var lSheet = package.Workbook.Worksheets.Add("Locations");
                    lSheet.Cells["A1"].LoadFromCollection(locationData, true, TableStyles.Medium9);

                    var pSheet = package.Workbook.Worksheets.Add("Patients");
                    pSheet.Cells["A1"].LoadFromCollection(patientData, true, TableStyles.Medium9);

                    var stream = new MemoryStream(package.GetAsByteArray());
                    return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "VacTrack.xlsx");
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
        }

    }
}

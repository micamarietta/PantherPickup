using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PantherPickup.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;

namespace PantherPickup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideRequestApiController : ControllerBase
    {
        private readonly ILogger<RideRequestApiController> _logger;
        private readonly IConfiguration Configuration;

        public RideRequestApiController(ILogger<RideRequestApiController> logger, IConfiguration _configuration)
        {
            _logger = logger;
            Configuration = _configuration;
        }

        [HttpGet]
        public IEnumerable<object> Get(string passengerID)
        {
            var events = new List<Dictionary<string, object>>();
            using (SqlConnection connection = new SqlConnection(Configuration.GetConnectionString("PantherPickup")))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM rideRequest WHERE passengerId = (SELECT pId FROM person WHERE email = '" + HttpContext.Session.GetString("UserEmail") + "' ) AND isCancelled = 0 AND isCompleted = 0", connection);
                command.Connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DateTime eventDate = reader["dayTime"].ConvertFromDBVal<DateTime>();

                    var curEvent = new Dictionary<string, object>();
                    curEvent.Add("occasion", string.Format("Scheduled ride from {0} to {1}", reader["PickUpDest"].ConvertFromDBVal<string>(), reader["DropOffDest"].ConvertFromDBVal<string>()));
                    curEvent.Add("invited_count", reader["numPassengers"].ConvertFromDBVal<int>());
                    curEvent.Add("year", eventDate.Year);
                    curEvent.Add("month", eventDate.Month);
                    curEvent.Add("day", eventDate.Day);
                    curEvent.Add("cancelled", false);

                    events.Add(curEvent);
                }
            }

            return events;
        }
       
    }
}

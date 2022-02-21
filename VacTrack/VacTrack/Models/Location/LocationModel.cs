using System;
namespace VacTrack.Models.Location
{
    public class LocationModel
    {
        public LocationModel()
        {
            
        }

        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}

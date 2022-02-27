using System;
using System.Collections.Generic;
using PantherPickup.Models.Location;
using PantherPickup.Models.Vaccine;

namespace PantherPickup.Models.VaccinationLocationDownload
{
    public class VaccinationLocationDownloadModel
    {
        public int VaccinationLocationID { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
        public int VaccineID { get; set; }
        public string VaccineName { get; set; }
    }
}

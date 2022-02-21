using System;
using System.Collections.Generic;
using VacTrack.Models.Location;
using VacTrack.Models.Vaccine;

namespace VacTrack.Models.VaccinationLocationDownload
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

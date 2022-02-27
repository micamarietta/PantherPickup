using System;
using System.Collections.Generic;
using PantherPickup.Models.Location;
using PantherPickup.Models.Vaccine;

namespace PantherPickup.Models.VaccinationLocation
{
    public class VaccinationLocationModel
    {
        public VaccinationLocationModel()
        {
            this.Location = new LocationModel();
            this.Vaccine = new VaccineModel();
        }

        public int VaccinationLocationID { get; set; }
        public int LocationID { get; set; }
        public LocationModel Location { get; set; }
        public List<LocationModel> Locations { get; set; }
        public int VaccineID { get; set; }
        public VaccineModel Vaccine { get; set; }
        public List<VaccineModel> Vaccines { get; set; }
    }
}

using System;
using System.Collections.Generic;
using VacTrack.Models.Patient;
using VacTrack.Models.VaccinationLocation;

namespace VacTrack.Models.Appointment
{
    public class AppointmentModel
    {
        public AppointmentModel()
        {
            this.Patient = new PatientModel();
            this.VaccinationLocation = new VaccinationLocationModel();

        }

        public int AppointmentID { get; set; }
        public DateTime DateTime { get; set; }
        public int PatientID { get; set; }
        public PatientModel Patient { get; set; }
        public List<PatientModel> Patients { get; set; }
        public int VaccinationLocationID { get; set; }
        public VaccinationLocationModel VaccinationLocation { get; set; }
        public List<VaccinationLocationModel> VaccinationLocations { get; set; }

    }
}

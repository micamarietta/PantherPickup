namespace VacTrack.Models.Appointment
{
    public class AppointmentDownloadModel
    {
        public int AppointmentID { get; set; }
        public string DateTime { get; set; }
        public int PatientID { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string VaccineName { get; set; }
        public string LocationName { get; set; }

    }
}

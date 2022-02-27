using System;
namespace PantherPickup.Models.Patient
{
    public class PatientModel
    {
        public PatientModel()
        {
            
        }

        public int PatientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string ZipCode { get; set; }
    }
}

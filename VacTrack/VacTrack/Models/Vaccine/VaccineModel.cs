using System;
namespace VacTrack.Models.Vaccine
{
    public class VaccineModel
    {
        public VaccineModel()
        {
            
        }

        public int VaccineID { get; set; }
        public string Name { get; set; }
        public int? NumOfDoses { get; set; }
    }
}

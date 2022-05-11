using System;
namespace PantherPickup.Models.RideRequest
{
    public class RideRequestModel
    {
        public RideRequestModel()
        {
            
        }

        public int RideID { get; set; }
        public int PassengerID { get; set; }
        public int DriverID { get; set; }
        public string Date { get; set; }
        public bool IsCancelled { get; set; }
        public int NumPassengers { get; set; }
        public string PickupLoc { get; set; }
        public string DropOffLoc { get; set; }
        public bool IsCompleted { get; set; }

    }
}

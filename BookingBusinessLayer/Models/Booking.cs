using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingBusinessLayer.Models
{
    public class Booking
    {
        //GUID FOR SECURITY
        public string? BookingId { get; set; }
        public required string VenueId { get; set; }
        public int NumberOfGuest { get; set; }
        public required string BookingContactName {get;set;}
        public required string BookingContactPhone { get; set; }
        public DateTime BookingTime { get; set; }
        public bool Confirmed { get; set; }
    }
}

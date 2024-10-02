using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDataLayer.Models
{
    [Table("GuestBooking")]
    public class GuestBooking
    {
        [Key]
        [Column("Id")]
        public required string Id { get; set; }

        [Column("VenueId")]
        public required string VenueId { get; set; }

        [Column("BookingDateTime")]
        public DateTime BookingDateTime { get; set; }

        [Column("NumberOfGuests")]
        public int NumberOfGuests { get; set; }

        [Column("BookingContactName")]
        public required string BookingContactName { get; set; }

        [Column("BookingContactPhone")]
        public required string BookingContactPhone { get; set; }

        [Column("IsConfrimed")]
        public bool IsConfrimed { get; set; }

        [ForeignKey("VenueId")]
        public virtual Venue Venue { get; set; }


    }
}

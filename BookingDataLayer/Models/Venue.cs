using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingDataLayer.Models
{
    [Table("Venue")]
    public class Venue
    {
        [Key]
        [Column("Id")]
        public required string Id { get; set; }

        [Column("Name")]
        public required string Name { get; set; }

        [Column("AvailableSeats")]
        public int AvailableSeats { get; set; }

        [Column("OpenTime")]
        public DateTime OpenTime { get; set; }

        [Column("ClosedTime")]
        public DateTime ClosedTime { get; set; }
    }
}

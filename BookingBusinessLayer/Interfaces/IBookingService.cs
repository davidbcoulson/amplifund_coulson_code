using BookingBusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingBusinessLayer.Interfaces
{
    public interface IBookingService
    {
        public Task<Booking> GetBooking(string bookingId);
        public Task<List<Booking>> GetBookings(string venueId);
        public Task DeleteBooking(string bookingId);
        public Task<Booking> CreateBooking(Booking request);
        public Task UpdateBooking(Booking request);
    }
}

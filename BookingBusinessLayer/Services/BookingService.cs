using BookingBusinessLayer.Interfaces;
using BookingBusinessLayer.Models;
using BookingDataLayer;
using BookingDataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BookingBusinessLayer.Services
{
    public class BookingService : IBookingService
    {
        private readonly BookDB_Context _data;

        public BookingService(BookDB_Context data) {
            _data = data;
        }
        public async Task<Booking> CreateBooking(Booking request)
        {
            try
            {
                var mapped = MapToGuestBooking(request);
                var created = await _data.GuestBookings.AddAsync(mapped);
                await _data.SaveChangesAsync();
                return await MapToBooking(created.Entity);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task DeleteBooking(string bookingId)
        {
            try
            {
                var found = await _data.GuestBookings.FirstOrDefaultAsync(x => x.Id == bookingId);
                if (found != null)
                {
                    _data.GuestBookings.Remove(found);
                    await _data.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<Booking> GetBooking(string bookingId)
        {
            try
            {
                var found = await _data.GuestBookings.FirstOrDefaultAsync(x => x.Id == bookingId);
                if (found == null) { throw new ApplicationException("Booking Not Found"); }
                return await MapToBooking(found);
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<List<Booking>> GetBookings(string venueId)
        {
            try {
                var final = new List<Booking>();
                var found = await _data.GuestBookings.Where(x => x.VenueId == venueId).ToListAsync();
                if (found != null && found.Count > 0)
                {
                    foreach (var item in found)
                    {
                        final.Add(await MapToBooking(item));
                    }
                }
                return final;
            }
            catch (Exception ex) {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task UpdateBooking(Booking request)
        {
            try
            {
                var updating = MapToGuestBooking(request);
                if (!string.IsNullOrEmpty(request.BookingId)) {
                    updating.Id = request.BookingId;
                }

                var found = await _data.GuestBookings.FirstOrDefaultAsync(x => x.Id == updating.Id);
                if (found != null)
                {
                    found.BookingContactPhone = request.BookingContactPhone;
                    found.BookingContactName = request.BookingContactName;
                    found.BookingDateTime = request.BookingTime;
                    found.IsConfrimed = request.Confirmed;
                    await _data.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        private GuestBooking MapToGuestBooking(Booking request) {
            var mapped = new GuestBooking() { 
                Id = string.Empty,
                VenueId = request.VenueId,
                BookingContactName = request.BookingContactName,
                BookingDateTime = request.BookingTime,
                BookingContactPhone = request.BookingContactPhone,
            };
            return mapped;
        }

        private async Task<Booking> MapToBooking(GuestBooking request) {
            var mapped = new Booking()
            {
                BookingId = request.Id,
                VenueId = request.VenueId,
                NumberOfGuest = request.NumberOfGuests,
                BookingContactName = request.BookingContactName,
                BookingContactPhone= request.BookingContactPhone,
                BookingTime = request.BookingDateTime,
                Confirmed = request.IsConfrimed
            };
            return mapped;
        }
    }
}

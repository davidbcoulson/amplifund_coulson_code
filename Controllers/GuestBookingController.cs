using BookingBusinessLayer.Interfaces;
using BookingBusinessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmpliFund_Coulson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestBookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public GuestBookingController(IBookingService bookingService) 
        {
            _bookingService = bookingService;
        }

        //SUPPOTS THE GUESTS && VENUES BOOKING SPACE

        //GET ALL THE BOOKINGS
        [HttpGet]
        [Route("getBookings")]
        public async Task<IActionResult> GetBookings(string venueId)
        {
            var found = await _bookingService.GetBookings(venueId);
            return Ok(found);
        }

        //GET ALL THE BOOKINGS
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetBooking(string bookingId)
        {
            var found = await _bookingService.GetBooking(bookingId);
            return Ok(found);
        }

        //DELETE A BOOKING
        [HttpDelete]
        [Route("deleteBooking")]
        public async Task<IActionResult> DeleteBooking(string bookingId)
        {
            await _bookingService.DeleteBooking(bookingId);
            return Ok();
        }

        //ADD A BOOKING
        [HttpPost]
        [Route("createBooking")]
        public async Task<IActionResult> CreateBooking(Booking request)
        {
            var approved = await _bookingService.CreateBooking(request);
            return Ok(approved);
        }


        //EDIT A BOOKING
        [HttpPut]
        [Route("updateBooking")]
        public async Task<IActionResult> UpdateBooking(Booking request)
        {
            await _bookingService.UpdateBooking(request);
            return Ok("Booking Updated.");
        }
    }
}

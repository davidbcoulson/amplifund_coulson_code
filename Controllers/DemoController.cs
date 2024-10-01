using BookingBusinessLayer.Interfaces;
using BookingBusinessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AmpliFund_Coulson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public DemoController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [Route("getBookings")]
        public async Task<IActionResult> GetBookings(string venueId)
        {
            var demoList = new List<Booking>();
            Booking bookingOne = new Booking() { 
                BookingContactName = "david coulson",
                BookingContactPhone = "6302808715",
                BookingId = Guid.NewGuid().ToString(),
                BookingTime = DateTime.UtcNow.AddDays(2),
                VenueId = venueId,
                NumberOfGuest = 4,
                Confirmed = true
            };
            demoList.Add(bookingOne);
            Booking bookingTwo = new Booking()
            {
                BookingContactName = "David Bowie",
                BookingContactPhone = "5554257458",
                BookingId = Guid.NewGuid().ToString(),
                BookingTime = DateTime.UtcNow.AddDays(2).AddMinutes(4),
                VenueId = venueId,
                NumberOfGuest = 4,
                Confirmed = false
            };
            demoList.Add(bookingTwo);
            return Ok(demoList);
        }

        //GET ALL THE BOOKINGS
        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetBooking(string bookingId)
        {
            Booking bookingOne = new Booking()
            {
                BookingContactName = "david coulson",
                BookingContactPhone = "6302808715",
                BookingId = bookingId,
                BookingTime = DateTime.UtcNow.AddDays(2),
                VenueId = Guid.NewGuid().ToString(),
                NumberOfGuest = 4,
                Confirmed = true
            };
            return Ok(bookingOne);
        }

        //DELETE A BOOKING
        [HttpDelete]
        [Route("deleteBooking")]
        public async Task<IActionResult> DeleteBooking(string bookingId)
        {
            //pretending to do something.
            return Ok("success");
        }

        //ADD A BOOKING
        [HttpPost]
        [Route("createBooking")]
        public async Task<IActionResult> CreateBooking(Booking request)
        {
            //presenting to add it and return the new id attached.
            request.BookingId = Guid.NewGuid().ToString();
            return Ok(request);
        }


        //EDIT A BOOKING
        [HttpPut]
        [Route("updateBooking")]
        public async Task<IActionResult> UpdateBooking(Booking request)
        {
            request.BookingTime = request.BookingTime.AddHours(2);
            return Ok("Booking Updated.");
        }
    }
}

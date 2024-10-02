# a_m_p_l_i_f_u_n_d
For the purpose of coding assessment.

Hey - My name is David Coulson
davidbcoulson@gmail.com
630.280.8715

I wrote this simple API application using .NET 8
The APIs support Booking (say for a restaurant).

Note there are 2 Controllers, One for Demo and One for the implementation. 

NOTE there is NO DATABASE SETUP FOR THIS PROJECT so endpoint from the GuestBooking Controller will alway fail. These are intended to be references 
to my architecture style and skill set with C#, LINQ, .NET, and the SOLID principles. 

#DEMO ENDPOINTS 
api/demo/getBookings - return 2 bookings
api/demo/get - enter in a random guid, it will return a booking with guid as the id
api/demo/deleteBooking - enter a rando guid, it will pretend to delete for you.
api/demo/createBooking - enter a booking class request, it should return success with a new Guid for the booking ID
api/demo/updateBooking - enter the response from your createBooking call, change the datetime by an hour but will return the same message each time "Booking Updated"


#GuestBooking ENDPOINTS 
api/guestBooking/getBookings - will get the bookings for a venue using the venuesId
api/guestBooking/get - will get booking by bookingId
api/guestBooking/deleteBooking - will delete booking by Id
api/guestBooking/createBooking - will create booking using Booking class as the reference.
api/guestBooking/updateBooking - will update a booking from a booking class with a BookingId.

Notes: all services for booking are in the BookingService.cs and that inherits from he IBookingService interface. I broke the project down into the API project which has the controllers and such, a Business Layer which has the interfaces
services, and models. As well, there is the Data Layer which is in the BookingDataLayer project,  this is holding the Entity Framework DBContext and the Models mapping to the pretend database. 

	Thank you for your time and consideration!


	-David
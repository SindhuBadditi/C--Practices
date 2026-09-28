using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Ticket_Booking
{
    class BookingException : ApplicationException
    {
        public BookingException(string message) : base(message)
        {
        }
    }
}

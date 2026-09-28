using System;
using System.Collections.Generic;
using System.Text;

namespace Flight_Ticket_Booking
{
    class FlightException : ApplicationException
    {
        public FlightException(string message) : base(message)
        {
        }
    }
}

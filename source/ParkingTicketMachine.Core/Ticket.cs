using System;

namespace ParkingTicketMachine.Core
{
    public class Ticket
    {
        public string Location { get; set; }

        public int Money { get; set; }

        public Ticket(string location)
        {
            Location = location;
        }
    }
}

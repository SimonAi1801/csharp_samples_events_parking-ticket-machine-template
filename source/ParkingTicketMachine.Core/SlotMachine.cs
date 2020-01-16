using System;

namespace ParkingTicketMachine.Core
{
    public class SlotMachine
    {
        public event EventHandler<Ticket> LogTicket;
        private Ticket _ticket;


        public void Print()
        {
            LogTicket?.Invoke(this, _ticket);
        }

        public void Cancle()
        {
            throw new NotImplementedException();
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }
    }
}

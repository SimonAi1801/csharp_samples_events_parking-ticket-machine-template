using System;

namespace ParkingTicketMachine.Core
{
    public class SlotMachine
    {
        public event EventHandler<Ticket> LogTicket;
        private Ticket _ticket;

        public SlotMachine()
        {
            _ticket = new Ticket();
        }

        public void Print()
        {
            LogTicket?.Invoke(this, _ticket);
        }

        public void Cancle()
        {
            _ticket.Slot = 0;
        }

        public void Insert(int coin)
        {
            _ticket.Slot += coin;
            if (_ticket.Slot >= 50)
            {
                if (FastClock.Instance.Time >= Convert.ToDateTime("08:00") && 
                    FastClock.Instance.Time <= Convert.ToDateTime("18:00"))
                {
                    
                }
                else
                {

                }
            }
        }
    }
}

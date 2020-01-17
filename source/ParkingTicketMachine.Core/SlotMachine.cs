using System;

namespace ParkingTicketMachine.Core
{
    public class SlotMachine
    {
        public event EventHandler<Ticket> LogTicket;
        private int _slot;
        private Ticket _ticket;
        private string _name;


        public SlotMachine(string name)
        {
            _name = name;
        }

        public void Print()
        {
            _ticket = new Ticket();
            _ticket.Description = _name;
            _ticket.Amount = _slot;
            _slot = 0;
            LogTicket?.Invoke(this, _ticket);
        }

        public void Cancle()
        {
            _slot = 0;
        }

        public DateTime Insert(int coin)
        {
            DateTime parkingTime = FastClock.Instance.Time;
            _slot += coin;
            if (_slot >= 50)
            {
                if (_slot >= 50 && _slot < 100)
                {
                    parkingTime = parkingTime.AddHours(0.5);
                }
                else if (_slot >= 100 && _slot < 200)
                {
                    parkingTime = parkingTime.AddHours(1);
                }
                else if (_slot >= 200)
                {
                    parkingTime = parkingTime.AddHours(1.5);
                }
                //if (FastClock.Instance.Time >= Convert.ToDateTime("08:00") &&
                //    FastClock.Instance.Time <= Convert.ToDateTime("18:00"))
                //{

                //}


            }
            return parkingTime;
        }
    }
}

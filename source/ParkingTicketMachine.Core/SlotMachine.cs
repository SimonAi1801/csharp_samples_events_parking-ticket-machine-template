using System;

namespace ParkingTicketMachine.Core
{
    public class SlotMachine
    {
        public event EventHandler<Ticket> LogTicket;
        private readonly int _minAmount = 50;
        private readonly DateTime _startTime = DateTime.Parse("08:00");
        private readonly DateTime _endTime = DateTime.Parse("18:00");
        private int _slot;
        private Ticket _ticket;
        private string _name;
        private double _minutes = 0;
        public DateTime ValidUntil { get; private set; }



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

        public string Insert(int coin)
        {
            _slot += coin;
            string validTime = String.Empty;
            if (_slot >= _minAmount)
            {
                if (_slot >= 50 && _slot < 100)
                {
                    _minutes = 30;
                }
                else if (_slot >= 100 && _slot < 200)
                {
                    _minutes = 60;
                }
                else if(_slot >= 200)
                {
                    _minutes = 90;
                }

                if (FastClock.Instance.Time.TimeOfDay < _startTime.TimeOfDay)
                {
                    FastClock.Instance.Time.AddMinutes(_minutes + _startTime.TimeOfDay.TotalMinutes);
                }
                else if (FastClock.Instance.Time.TimeOfDay > _endTime.TimeOfDay)
                {
                    FastClock.Instance.Time.AddDays(1);
                    FastClock.Instance.Time.AddMinutes(_minutes + _startTime.TimeOfDay.TotalMinutes);
                }
                else
                {
                    ValidUntil = FastClock.Instance.Time.AddMinutes(_minutes);
                    if (ValidUntil > _endTime)
                    {
                        TimeSpan timeSpan = _endTime.TimeOfDay - ValidUntil.TimeOfDay;
                        FastClock.Instance.Time.AddDays(1);
                        FastClock.Instance.Time.AddMinutes(timeSpan.TotalMinutes + _startTime.TimeOfDay.TotalMinutes);
                    }
                }

                validTime = ValidUntil.ToShortTimeString();
            }
            return validTime;
        }
    }
}

using System;
using System.Windows;
using ParkingTicketMachine.Core;

namespace ParkingTicketMachine.Wpf
{
    /// <summary>
    /// Interaction logic for SlotMachineWindow.xaml
    /// </summary>
    public partial class SlotMachineWindow
    {
        private readonly SlotMachine _slotMachine = new SlotMachine();
        private Ticket _ticket = new Ticket();
        public SlotMachineWindow(string name, EventHandler<Ticket> ticketReady)
        {
            InitializeComponent();
            Title = name;
            _ticket.Location = name;
            _slotMachine.LogTicket += ticketReady;
        }

        private void ButtonInsertCoin_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxCoins.SelectedIndex < 0)
            {
                TextBoxTimeUntil.Text = "Bitte Münzen einwerfen!";
            }
            FastClock.Instance.IsRunning = false;
            int[] coins = { 10, 20, 50, 100, 200 };
            int coin = coins[ListBoxCoins.SelectedIndex];
            _slotMachine.Insert(coin);
        }

        private void ButtonPrintTicket_Click(object sender, RoutedEventArgs e)
        {
            _slotMachine.Print();
            FastClock.Instance.IsRunning = true;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            _slotMachine.Cancle();
            TextBoxTimeUntil.Text = "";
            FastClock.Instance.IsRunning = true;
        }
    }
}

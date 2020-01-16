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
        private SlotMachine _slotMachine;
        private Ticket _ticket;
        public SlotMachineWindow(string name, EventHandler<Ticket> ticketReady)
        {
            InitializeComponent();
            Title = name;
            
        }

        private void ButtonInsertCoin_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxCoins.SelectedIndex < 0)
            {

            }
        }

        private void ButtonPrintTicket_Click(object sender, RoutedEventArgs e)
        {
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
        }

    }
}

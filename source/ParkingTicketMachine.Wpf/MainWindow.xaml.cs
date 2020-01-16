﻿using ParkingTicketMachine.Core;
using System;
using System.Text;
using System.Windows;

namespace ParkingTicketMachine.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, EventArgs e)
        {
            FastClock.Instance.Factor = 360;
            FastClock.Instance.Time = DateTime.Parse("16:30:00");
            FastClock.Instance.IsRunning = true;
            SlotMachineWindow slotMachine1 = new SlotMachineWindow("Limesstarße", OnReadyTicket) { Owner = this };
            slotMachine1.Show();
            SlotMachineWindow slotMachine2 = new SlotMachineWindow("Landstarße", OnReadyTicket) { Owner = this };
            slotMachine2.Show();
            FastClock.Instance.OneMinuteIsOver += Instance_OneMinuteIsOver;
        }

        private void Instance_OneMinuteIsOver(object sender, DateTime e)
        {
            Title = FastClock.Instance.Time.ToShortTimeString();
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            SlotMachineWindow newSlotMachine = new SlotMachineWindow(TextBoxAddress.Text, OnReadyTicket);
            newSlotMachine.Show();
        }

        void AddLineToTextBox(string line)
        {
            StringBuilder text = new StringBuilder(TextBlockLog.Text);
            text.Append(line + "\n");
            text.Append(FastClock.Instance.Time.ToShortDateString() + " \t ");
            text.Append(FastClock.Instance.Time.ToShortTimeString() + "\t");
            TextBlockLog.Text = text.ToString();
        }

        private void OnReadyTicket(object sender, Ticket ticket)
        {
            string text = $"{TextBoxAddress.Text}";
            AddLineToTextBox(text);
        }

    }
}

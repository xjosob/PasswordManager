﻿using PasswordManager.AccountStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PasswordManager.Views
{
    /// <summary>
    /// Interaction logic for AddAccountWindow.xaml
    /// </summary>
    public partial class AddAccountWindow : Window
    {
        public Action AddAccountCallback { get; set; }
        public AccountStructure AccountContext { get => this.DataContext as AccountStructure; }
        public AddAccountWindow()
        {
            InitializeComponent();
            DataContext = new AccountStructure();
        }

        public void Reset()
        {
            DataContext = new AccountStructure();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter) { AddAccountCallback?.Invoke(); this.Hide(); }
            if(e.Key == Key.Escape) { this.Hide(); }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}

﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ST10084795_POE_Part2
{
    public partial class MainWindow : Window
    {
        //Timer object
        DispatcherTimer dt = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            //Timer - 3 second splash screen
            dt.Tick += new EventHandler(dt_Tick);
            dt.Interval = new TimeSpan(0, 0, 3);
            dt.Start();
        }

        private void dt_Tick(object sender, EventArgs e)
        {
            //Controlling the event 
            RegisterLogin rl = new RegisterLogin(); //Next page object
            rl.Show(); //Sets visability of next page
            dt.Stop(); //Stops the timer
            this.Close(); //Closes the splash screen
        }
    }
}

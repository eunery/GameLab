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

namespace MiniGame
{
    public partial class MainWindow : Window
    {
        private Random rnd = new Random();
        private int tickCounter = 10;
        private DispatcherTimer timer;
        private int rndNumber = 10;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,1);
            timer.Tick += timertick;
            timer.Start();
            Button.Click += Button_Click;

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rndNumber = rnd.Next(10,99);
            string sym = rndNumber.ToString();
            if (sym[0] == sym[1])
            {
                timer.Stop();
                Level2 lvl2 = new Level2();
                lvl2.Show();
                Level1.Close();
            }
        }
        private void timertick(object sender, EventArgs e)
        {
            if (tickCounter > 0)
            {
                tickCounter--;
                TimerBlockDown.Text = String.Format("00:0{0}:{1}", tickCounter/60, tickCounter%60);
            }
            else
            {
                timer.Stop();
                MessageBox.Show("Гуляй братишка");
            }
        }
    }
}

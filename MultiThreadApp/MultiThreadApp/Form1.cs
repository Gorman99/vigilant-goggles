using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MultiThreadApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThread1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(t =>
            {
                 int.TryParse(tbP1.Text, out int intPutVale);
                List<int> primeNumbers = GetPrimesUpTo(intPutVale);
                tb1.Invoke((MethodInvoker)(() => tb1.Text = string.Join(" ", primeNumbers)));
                 Thread.Sleep(100);
                
            })
            { IsBackground = true };
            thread.Start();
        }

        Random rd;

        

        private void btnThread_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(t =>
            {
                int.TryParse(tbP2.Text, out int intPutVale);
                List<int> primeNumbers = GetPrimesUpTo(intPutVale);
                tb1.Invoke((MethodInvoker)(() => tb2.Text = string.Join(" ", primeNumbers)));
                Thread.Sleep(100);
            })
            { IsBackground = true };

            thread.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rd = new Random();
        }

        private void tbP1_TextChanged(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbP2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;
            if (number <= 3)
                return true;
            if (number % 2 == 0 || number % 3 == 0)
                return false;

            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                    return false;
            }

            return true;
        }


        static List<int> GetPrimesUpTo(int maxNumber)
        {
            List<int> primes = new List<int>();

            for (int number = 2; number <= maxNumber; number++)
            {
                if (IsPrime(number))
                {
                    primes.Add(number);
                }
            }

            return primes;
        }

       
    }
}

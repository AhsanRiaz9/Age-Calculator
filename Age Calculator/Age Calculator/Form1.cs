using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Age_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string startDate = this.monthCalendar1.SelectionRange.Start.ToShortDateString();
            string endDate = this.monthCalendar2.SelectionRange.Start.ToShortDateString();
            int startDateDay = int.Parse(startDate[0].ToString() + startDate[1].ToString());
            int startDateMonth = int.Parse(startDate[3].ToString() + startDate[4].ToString());
            int startDateYear = int.Parse(startDate[6].ToString() + startDate[7].ToString() + startDate[8].ToString() + startDate[9].ToString());
            int endDateDay = int.Parse(endDate[0].ToString() + endDate[1].ToString());
            int endDateMonth = int.Parse(endDate[3].ToString() + endDate[4].ToString());
            int endDateYear = int.Parse(endDate[6].ToString() + endDate[7].ToString() + endDate[8].ToString() + endDate[9].ToString());
            DateTime date1 = new DateTime(startDateYear, startDateMonth, startDateDay);
            DateTime date2 = new DateTime(endDateYear, endDateMonth, endDateDay);
           
            try
            {
                Age cDate = new Age(date1);
                Age diff = cDate.Count(date1, date2);
                label6.Text = diff.Years.ToString();
                label7.Text = diff.Months.ToString();
                label8.Text = diff.Days.ToString();
            }
            catch(ArgumentException error)
            {
                MessageBox.Show(error.Message,"Warning Message!");
            }

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        public class Age
        {
            public int Years;
            public int Months;
            public int Days;

            public Age(DateTime Bday)
            {
                this.Count(Bday);
            }

            public Age(DateTime Bday, DateTime Cday)
            {
                this.Count(Bday, Cday);
            }

            public Age Count(DateTime Bday)
            {
                return this.Count(Bday, DateTime.Today);
            }

            public Age Count(DateTime Bday, DateTime Cday)
            {
                if ((Cday.Year - Bday.Year) > 0 ||
                    (((Cday.Year - Bday.Year) == 0) && ((Bday.Month < Cday.Month) ||
                      ((Bday.Month == Cday.Month) && (Bday.Day <= Cday.Day)))))
                {
                    int DaysInBdayMonth = DateTime.DaysInMonth(Bday.Year, Bday.Month);
                    int DaysRemain = Cday.Day + (DaysInBdayMonth - Bday.Day);

                    if (Cday.Month > Bday.Month)
                    {
                        this.Years = Cday.Year - Bday.Year;
                        this.Months = Cday.Month - (Bday.Month + 1) + Math.Abs(DaysRemain / DaysInBdayMonth);
                        this.Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                    }
                    else if (Cday.Month == Bday.Month)
                    {
                        if (Cday.Day >= Bday.Day)
                        {
                            this.Years = Cday.Year - Bday.Year;
                            this.Months = 0;
                            this.Days = Cday.Day - Bday.Day;
                        }
                        else
                        {
                            this.Years = (Cday.Year - 1) - Bday.Year;
                            this.Months = 11;
                            this.Days = DateTime.DaysInMonth(Bday.Year, Bday.Month) - (Bday.Day - Cday.Day);
                        }
                    }
                    else
                    {
                        this.Years = (Cday.Year - 1) - Bday.Year;
                        this.Months = Cday.Month + (11 - Bday.Month) + Math.Abs(DaysRemain / DaysInBdayMonth);
                        this.Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                    }
                }
                else
                {
                    throw new ArgumentException("Start Date and End Date are not Corrected!");
                }
                return this;

            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
    }
}

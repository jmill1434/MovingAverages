using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Stock
    {
        private Date date;
        private double open;
        private double high;
        private double low;
        private double close;
        private double adjClose;
        private double volume;

        public Stock()
        {
        }

        public double Open { get => open; set => open = value; }
        public Date Date { get => date; set => date = value; }
        public double High { get => high; set => high = value; }
        public double Low { get => low; set => low = value; }
        public double Close { get => close; set => close = value; }
        public double AdjClose { get => adjClose; set => adjClose = value; }
        public double Volume { get => volume; set => volume = value; }
    }
}

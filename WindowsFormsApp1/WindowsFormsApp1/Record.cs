using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    [Serializable]
    class Record
    {
        public Record(double shortterm, double longterm)
        {
            Shortterm = shortterm;
            Longterm = longterm;
        }

        public double Shortterm { get; set; }
        public double Longterm { get; set; }
    }
}

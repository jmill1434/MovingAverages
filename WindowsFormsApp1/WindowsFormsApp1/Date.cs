using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Date
    {
        private int yyyymmdd;
        private string yyyy_mm_dd;
        private int year;
        private int month;
        private int day;

        public Date()
        {
            yyyymmdd = 0;
            yyyy_mm_dd = "";
            year = 0;
            month = 0;
            day = 0;

        }
        public Date(string d)
        {
            yyyy_mm_dd = d;
            month = extractMonth(d);
        }


        public void toDate(string d)
        {
            yyyy_mm_dd = d;


        }

        public string getDate()
        {
            return yyyy_mm_dd;
        }

        /*converts string year to int with no dashes
          sets year, month, and day
          must be called before getYear, getMonth, and/or getDay are called
        **/
        public int StrToInt(string y_m_d)
        {
            string[] dashsplit = y_m_d.Split('-');
            year = Int32.Parse(dashsplit[0]);
            day = Int32.Parse(dashsplit[2]);
            month = Int32.Parse(dashsplit[1]);

            yyyymmdd = (year * 10000) + (month * 100) + day;
            return yyyymmdd;
        }

        public string IntToStr(int ymd)
        {
            int yr = ymd / 10000;
            int mo = (ymd / 100) % 10;
            int dy = ymd % 100;
            yyyy_mm_dd = yr + "-" + mo + "-" + dy;
            return yyyy_mm_dd;
        }

        //call stringToInt before using
        public int getYear()
        {
            return year;
        }

        //call stringToInt before using
        public int getMonth()
        {
            return month;
        }

        //call stringToInt before using
        public int getDay()
        {
            return day;
        }

        public int extractMonth(string d)
        {
            int m;
            string[] dashsplit = d.Split('-');
            m = Int32.Parse(dashsplit[1]);
            return m;
        }

    }
}

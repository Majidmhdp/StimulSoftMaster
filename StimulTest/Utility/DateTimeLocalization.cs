using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StimulTest.Utility
{
    class DateTimeLocalization
    {
        public static string ConvertDateToShamsiDateString(DateTime inputDate, char sepratorChar)
        {
            try
            {
                PersianCalendar persianCalendar = new PersianCalendar();

                return persianCalendar.GetYear(inputDate)
                       + sepratorChar.ToString()
                       + persianCalendar.GetMonth(inputDate).ToString().PadLeft(2, '0')
                       + sepratorChar.ToString()
                       + persianCalendar.GetDayOfMonth(inputDate).ToString().PadLeft(2, '0');
            }
            catch
            {
                return "1300" + sepratorChar.ToString() + "00" + sepratorChar.ToString() + "00";
            }
        }

        public static DateTime ConvertShamsiDateStringToDateTime(string inputPersianDate, char sepratorChar)
        {
            PersianCalendar pc = new PersianCalendar();
            try
            {
                string[] spilitedText = inputPersianDate.Split(sepratorChar);

                int persianYear = Convert.ToInt32(spilitedText[0]);
                int persianMonth = Convert.ToInt32(spilitedText[1]);
                int persianDay = Convert.ToInt32(spilitedText[2]);

                return new DateTime(persianYear, persianMonth, persianDay, pc);
            }
            catch
            {
                return new DateTime(1300, 1, 1, pc);
            }
        }

        public static DateTime ConvertGregorianDateStringToDateTime(string inputnDate, char sepratorChar)
        {
            try
            {
                string[] spilitedText = inputnDate.Split(sepratorChar);

                int year = Convert.ToInt32(spilitedText[0]);
                int month = Convert.ToInt32(spilitedText[1]);
                int day = Convert.ToInt32(spilitedText[2]);

                return new DateTime(year, month, day);
            }
            catch
            {
                return new DateTime(1970, 01, 01);
            }
        }
    }
}

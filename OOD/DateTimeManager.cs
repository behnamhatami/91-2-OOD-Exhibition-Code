#region

using System;

#endregion

namespace OOD
{
    public static class DateTimeManager
    {
        public static DateTime Today
        {
            get
            {
                if (Program.Exhibition != null)
                    return Program.Exhibition.ExhibitionDateTime;
                else return SystemToday;
            }
        }

        public static DateTime SystemToday
        {
            get { return DateTime.Today; }
        }

        public static DateTime SystemNow
        {
            get { return DateTime.Now; }
        }
    }
}
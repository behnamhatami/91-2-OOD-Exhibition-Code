#region

using System;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ModelContext;

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
                return SystemToday;
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

        public static void Tomorrow()
        {
            Program.Exhibition.ExhibitionDateTime = Program.Exhibition.ExhibitionDateTime.AddDays(1);
            DataManager.DataContext.SaveChanges();

            AddProcessManagerIfRequire();

            if (Program.Exhibition.State == ExhibitionState.Started)
                Program.ProcessManager.DoDayWork();
        }

        public static void AddProcessManagerIfRequire()
        {
            if (Program.Exhibition.State >= ExhibitionState.Freezed)
            {
                if (Program.ProcessManager == null)
                    Program.ProcessManager = new ProcessManager(Program.Exhibition);
            }
        }
    }
}
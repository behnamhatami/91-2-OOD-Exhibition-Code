using System;
using System.Windows.Forms;
using OOD.Model.ModelContext;
using OOD.Model.UserManaging;
using OOD.UI.UserManaging;

namespace OOD
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var db = DataManager.DataContext;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }

        public static User User { get; set; }
    }
}
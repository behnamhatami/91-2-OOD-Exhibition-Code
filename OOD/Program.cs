using System;
using System.Windows.Forms;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ModelContext;
using OOD.Model.NotificationPackage;
using OOD.Model.UserManagingPackage;
using OOD.UI.ExhibitionPackage.ExhibitionDefinition;
using OOD.UI.UserManagingPackage;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Login());
        }

        public static User User { get; set; }
        public static Exhibition Exhibition { get; set; }
    }
}
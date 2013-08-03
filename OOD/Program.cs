#region

using System;
using System.Windows.Forms;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.UserManagingPackage;
using OOD.UI.UserManagingPackage;

#endregion

namespace OOD
{
    internal static class Program
    {
        public static User User { get; set; }
        public static Exhibition Exhibition { get; set; }

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Login());
        }
    }
}
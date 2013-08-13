#region

using System;
using System.Linq;
using System.Windows.Forms;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ModelContext;
using OOD.Model.UserManagingPackage;
using OOD.UI.UserManagingPackage;

#endregion

namespace OOD
{
    internal static class Program
    {
        public static User User { get; set; }
        public static Exhibition Exhibition { get; set; }

        public static User System
        {
            get { return DataManager.DataContext.Users.First(user => user.Username == "System"); }
        }

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
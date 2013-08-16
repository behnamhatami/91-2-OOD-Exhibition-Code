#region

using System.Windows.Forms;

#endregion

namespace OOD.UI.UtilityPackage.PopUp
{
    public static class PopUp
    {
        public static void ShowError(string message)
        {
            MessageBox.Show(message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RtlReading);
        }

        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RtlReading);
        }

        public static void ShowSuccess(string message)
        {
            MessageBox.Show(message, "اطلاع", MessageBoxButtons.OK, MessageBoxIcon.Asterisk,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RtlReading);
        }
    }
}
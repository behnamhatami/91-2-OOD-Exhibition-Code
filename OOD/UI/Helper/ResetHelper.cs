using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOD.UI.Helper
{
    public static class ResetHelper
    {
        public static void Empty(params Control[] controls)
        {
            foreach (var control in controls)
                control.Text = "";
        }

        public static void SetEnable(bool enable, params Control[] controls)
        {
            foreach (var control in controls)
                control.Enabled = enable;
        }

        public static void Empty(params ComboBox[] comboBoxes)
        {
            foreach (var comboBox in comboBoxes)
            {
                comboBox.SelectedItem = null;
                comboBox.SelectedText = "";
                comboBox.SelectedIndex = -1;
            }
        }

        public static void Empty(params CheckedListBox[] checkListBoxes)
        {
            foreach (var checkListBox in checkListBoxes)
            {
                checkListBox.SelectedItems.Clear();
                checkListBox.SelectedIndices.Clear();
            }
        }
    }
}
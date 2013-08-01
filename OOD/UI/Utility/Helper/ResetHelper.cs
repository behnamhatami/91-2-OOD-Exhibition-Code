using System.Windows.Forms;

namespace OOD.UI.Utility.Helper
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

        public static void Empty(params CheckBox[] checkBoxes)
        {
            foreach (var checkBox in checkBoxes)
                checkBox.Checked = false;
        }

        public static void Empty(params ListBox[] listBoxes)
        {
            foreach (var listBox in listBoxes)
            {
                listBox.SelectedItems.Clear();
                listBox.SelectedIndices.Clear();
            }
        }
    }
}
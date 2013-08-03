#region

using System;
using System.Windows.Forms;

#endregion

namespace OOD.UI.Utility.Helper
{
    public static class ResetHelper
    {
        public static void SetEnable(bool enable, params Control[] controls)
        {
            foreach (var control in controls)
                control.Enabled = enable;
        }

        public static void Empty(params Control[] controls)
        {
            foreach (var control in controls)
            {
                var combobox = control as ComboBox;
                if (combobox != null)
                    EmptyComboBox(combobox);

                var checkList = control as CheckedListBox;
                if (checkList != null)
                    EmptyCheckedListBox(checkList);

                var checkBox = control as CheckBox;
                if (checkBox != null)
                    EmptyCheckBox(checkBox);

                var listBox = control as ListBox;
                if (listBox != null)
                    EmptyListBox(listBox);

                EmptyControl(control);
            }
        }

        private static void EmptyControl(Control control)
        {
            control.Text = "";
        }

        private static void EmptyCheckBox(CheckBox checkBox)
        {
            checkBox.Checked = false;
        }

        private static void EmptyListBox(ListBox listBox)
        {
            listBox.SelectedItems.Clear();
            listBox.SelectedIndices.Clear();
            listBox.ClearSelected();
        }

        private static void EmptyComboBox(ComboBox comboBox)
        {
            comboBox.SelectedItem = null;
            comboBox.SelectedIndex = -1;
        }

        private static void EmptyCheckedListBox(CheckedListBox checkListBox)
        {
            checkListBox.SelectedItems.Clear();
            checkListBox.SelectedIndices.Clear();
            checkListBox.ClearSelected();
        }

        public static void Refresh(ListBox listBox, Object[] init)
        {
            Empty(listBox);
            listBox.Items.Clear();
            listBox.Items.AddRange(init);
        }

        public static void Refresh(ComboBox comboBox, Object[] init)
        {
            Empty(comboBox);
            comboBox.Items.Clear();
            comboBox.Items.AddRange(init);
        }

        public static void Refresh(CheckedListBox checkedListBox, Object[] init)
        {
            Empty(checkedListBox);
            checkedListBox.Items.Clear();
            checkedListBox.Items.AddRange(init);
            checkedListBox.Refresh();
        }

        public static void Refresh(CheckBox checkBox, Boolean init)
        {
            Empty(checkBox);
            checkBox.Checked = init;
        }
    }
}
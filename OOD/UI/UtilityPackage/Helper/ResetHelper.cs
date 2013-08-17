#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

#endregion

namespace OOD.UI.UtilityPackage.Helper
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
                {
                    EmptyCheckedListBox(checkList);
                }
                var checkBox = control as CheckBox;
                if (checkBox != null)
                {
                    EmptyCheckBox(checkBox);
                    continue;
                }
                var listBox = control as ListBox;
                if (listBox != null)
                    EmptyListBox(listBox);

                var dateTimePicker = control as DateTimePicker;
                if (dateTimePicker != null)
                    EmptyDateTimePicker(dateTimePicker);

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

        private static void EmptyDateTimePicker(DateTimePicker dateTimePicker)
        {
            dateTimePicker.Checked = false;
            dateTimePicker.Value = DateTimeManager.Today;
        }

        public static void Refresh(ListBox listBox, Object[] init)
        {
            Empty(listBox);
            listBox.Items.Clear();
            listBox.Items.AddRange(init);
        }

        public static void Refresh(ListBox listBox, IQueryable<Object> queryable)
        {
            if (queryable != null)
                Refresh(listBox, queryable.ToArray());
        }


        public static void Refresh(ComboBox comboBox, Object[] init)
        {
            Empty(comboBox);
            comboBox.Items.Clear();
            if (init != null && init.Length != 0)
                comboBox.Items.AddRange(init);
        }

        public static void Refresh(ComboBox comboBox, IQueryable<Object> queryable)
        {
            if (queryable != null)
                Refresh(comboBox, queryable.ToArray());
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

        public static void Refresh(DateTimePicker timePicker, DateTime dateTime)
        {
            Empty(timePicker);
            timePicker.Value = dateTime;
        }

        public static void RemoveItems(params ComboBox[] comboBoxes)
        {
            Empty(comboBoxes);
            foreach (var comboBox in comboBoxes)
                comboBox.Items.Clear();
        }

        public static void RemoveItems(params ListBox[] listBoxes)
        {
            Empty(listBoxes);
            foreach (var listBox in listBoxes)
                listBox.Items.Clear();
        }
    }
}
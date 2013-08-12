#region

using System;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionPeripheral;
using OOD.Model.ExhibitionPackage.ExhibitionRoles;
using OOD.Model.ModelContext;
using OOD.Model.UserManagingPackage;
using OOD.UI.Utility.Base;
using OOD.UI.Utility.Helper;
using OOD.UI.Utility.PopUp;

#endregion

namespace OOD.UI.ExhibitionPackage.ExhibitionProgress.ExhibitionPeripheral
{
    public partial class WareHouseManaging : MainWindow
    {
        public WareHouseManaging()
        {
            InitializeComponent();
        }

        // IResetAble

        public override void Reset()
        {
            recieveTabPageReset();
            listTabPageReset();
        }

        // IPrecondition

        public override bool NeedUser()
        {
            return true;
        }


        public override bool NeedExhibition()
        {
            return true;
        }

        public override bool ValidatePreConditions()
        {
            if (!base.ValidatePreConditions())
                return false;

            var user = Program.User;
            var exhibition = Program.Exhibition;
            if (exhibition.Feature.HasWareHouse == false)
            {
                PopUp.ShowError("نمایشگاه دارای انبار نمی باشد.");
                return false;
            }

            if (exhibition.HasRole<WareHouseKeeperRole>(user))
            {
                if (exhibition.State == ExhibitionState.Started)
                    return true;
                GeneralErrors.Closed("انبار");
                return false;
            }
            GeneralErrors.AccessDenied();
            return false;
        }

        //IReloadAble

        public override int GetLevel()
        {
            return 3;
        }

        public override bool RestoreAble()
        {
            return true;
        }

        // Finish

        public void recieveTabPageReset()
        {
            ResetHelper.Empty(recieveItemNameTextBox, recieveDateTimePicker);
            var db = DataManager.DataContext;
            ResetHelper.Refresh(recieveItemUserListComboBox, db.Users.ToArray());
        }

        public void listTabPageReset()
        {
            ResetHelper.Empty(listItemIdTextBox, listItemNameTextBox, listItemUserTextBox, listItemEntranceDateTextBox);
            ResetHelper.Refresh(listItemListBox, Program.Exhibition.WareHouse.WareHouseItems.ToArray());
            listReleaseButton.Enabled = false;
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            var name = recieveItemNameTextBox.Text;
            var date = recieveDateTimePicker.Value;
            var user = recieveItemUserListComboBox.SelectedItem as User;
            if (GeneralErrors.IsEmptyField(name, "نام کالا")
                || GeneralErrors.IsNull(date, "تاریخ ورود")
                || GeneralErrors.IsNull(user, "نام کاربر"))
                return;

            var wareHouseItem = new WareHouseItem
            {
                EntranceDate = date,
                Name = name,
                Released = false,
                ReleaseDate = date,
                User = user,
                WareHouse = Program.Exhibition.WareHouse
            };
            var db = DataManager.DataContext;
            db.WareHouseItems.Add(wareHouseItem);
            db.SaveChanges();
            PopUp.ShowSuccess("کالا در انبار وارد گردید.");
            Reset();
        }

        private void listShowButton_Click(object sender, EventArgs e)
        {
            var wareHouseItem = listItemListBox.SelectedItem as WareHouseItem;
            if (GeneralErrors.IsNull(wareHouseItem, "کالای انبار"))
                return;

            listItemIdTextBox.Text = wareHouseItem.Id + "";
            listItemNameTextBox.Text = wareHouseItem.Name;
            listItemUserTextBox.Text = wareHouseItem.User.ToString();
            listItemEntranceDateTextBox.Text = wareHouseItem.EntranceDate.ToString();
            listReleaseButton.Enabled = !wareHouseItem.Released;
        }

        private void listReleaseButton_Click(object sender, EventArgs e)
        {
            var wareHouseItem = listItemListBox.SelectedItem as WareHouseItem;
            if (GeneralErrors.IsNull(wareHouseItem, "کالای انبار"))
                return;
            wareHouseItem.Released = true;
            DataManager.DataContext.SaveChanges();
            PopUp.ShowSuccess("کالا از انبار ترخیص گردید.");
            Reset();
        }
    }
}
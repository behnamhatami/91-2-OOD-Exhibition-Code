#region

using System;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ExhibitionPackage.ExhibitionRoles;
using OOD.Model.ModelContext;
using OOD.Model.UserManagingPackage;
using OOD.UI.Utility.Base;
using OOD.UI.Utility.Helper;
using OOD.UI.Utility.PopUp;

#endregion

namespace OOD.UI.ExhibitionPackage.ExhibitionDefinition
{
    public partial class Configuration : MainWindow
    {
        public Configuration()
        {
            InitializeComponent();
        }


        // IResetAble

        public override void Reset()
        {
            FeaturePageReset();
            RolePageReset();
            ProcessPageReset();
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
            if (exhibition.HasRole<ChairRole>(user))
            {
                if (exhibition.State == ExhibitionState.Created
                    || exhibition.State == ExhibitionState.Configuration)
                    return true;
                PopUp.ShowError("قسمت پیکربندی بسته شده است.");
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

        // Feature

        private void FeaturePageReset()
        {
            var exhibition = Program.Exhibition;
            var db = DataManager.DataContext;
            ResetHelper.Refresh(featureInitialConfigurationComboBox, db.Exhibitions.ToArray());

            if (exhibition != null)
            {
                var feature = exhibition.Feature;
                featurePostOfficeCheckBox.Checked = feature.HasPostOffice;
                featureWareHouseCheckBox.Checked = feature.HasWareHouse;
                featureSellRadioButton.Checked = feature.HasSell;
                featureNoSellRadioButton.Checked = !feature.HasSell;
                featureDifferentBoothCheckBox.Checked = feature.HasDifferentBooth;
            }
            else
            {
                ResetHelper.Empty(featurePostOfficeCheckBox, featureWareHouseCheckBox, featureSellRadioButton,
                    featureDifferentBoothCheckBox);
                featureNoSellRadioButton.Checked = true;
            }
        }

        private void featureCancelButton_Click(object sender, EventArgs e)
        {
            FeaturePageReset();
        }

        private void featureOkeyButton_Click(object sender, EventArgs e)
        {
            var db = DataManager.DataContext;
            var exhibition = Program.Exhibition;
            var feature = exhibition.Feature;
            feature.HasPostOffice = featurePostOfficeCheckBox.Checked;
            feature.HasWareHouse = featureWareHouseCheckBox.Checked;
            feature.HasSell = featureSellRadioButton.Checked;
            feature.HasDifferentBooth = featureDifferentBoothCheckBox.Checked;

            var newExhibition = featureInitialConfigurationComboBox.SelectedItem as Exhibition;
            if (newExhibition != null)
            {
                var configuration = exhibition.Configuration;
                configuration.Reset();
                foreach (var process in newExhibition.Configuration.Processes)
                    db.Processes.Add(process.Clone(configuration));
            }
            db.SaveChanges();
            PopUp.ShowSuccess("تغییرات مد نظر با موفقیت اعمال گردید.");
            FeaturePageReset();
            ProcessPageReset();
        }

        // Rolls

        private void RolePageReset()
        {
            var db = DataManager.DataContext;

            ResetHelper.Refresh(roleChoicesComboBox, ExhibitionRole.GetChoices());
            ResetHelper.Refresh(roleUserComboBox, db.Users.ToArray());
            ResetHelper.Refresh(roleUserExhibitionRoleListBox, Program.Exhibition.UserExhibitionRoles.ToArray());
        }

        private void roleAddButton_Click(object sender, EventArgs e)
        {
            var user = (User) roleUserComboBox.SelectedItem;
            var role = (ExhibitionRole) roleChoicesComboBox.SelectedItem;
            var exhibition = Program.Exhibition;

            if (GeneralErrors.IsNull(user, "نام کاربری") || GeneralErrors.IsNull(role, "نقش"))
                return;

            var userExhibitionRole = new UserExhibitionRole
            {
                Exhibition = exhibition,
                ExhibitionRole = role,
                User = user
            };
            var db = DataManager.DataContext;
            db.UserExhibitionRoles.Add(userExhibitionRole);
            user.RecieveNotification(NotificationFactory.ExhibitionRoleAddedTitle,
                NotificationFactory.ExhibitionRoleAddedContent(exhibition, role), exhibition);
            db.SaveChanges();
            RolePageReset();
            PopUp.ShowSuccess("نقش جدید ساخته شد.");
        }

        private void roleRemoveButton_Click(object sender, EventArgs e)
        {
            if (GeneralErrors.IsZero(roleUserExhibitionRoleListBox.CheckedItems.Count, "تخصیص"))
                return;

            var db = DataManager.DataContext;
            foreach (var userExhibitionRole in roleUserExhibitionRoleListBox.CheckedItems.Cast<UserExhibitionRole>())
            {
                db.UserExhibitionRoles.Remove(userExhibitionRole);
                userExhibitionRole.User.RecieveNotification(NotificationFactory.ExhibitionRoleRemovedTitle,
                    NotificationFactory.ExhibitionRoleRemovedContent(userExhibitionRole.Exhibition,
                        userExhibitionRole.ExhibitionRole), userExhibitionRole.Exhibition);
            }


            db.SaveChanges();
            RolePageReset();
            PopUp.ShowSuccess("نقش های انتخاب شده حذف گردید.");
        }

        // Process

        public void ProcessPageReset()
        {
            var exhibition = Program.Exhibition;
            ResetHelper.Empty(processMaxLengthTextBox, processMinLengthTextBox, processStartNodeTextBox,
                processFinishNodeTextBox);
            ResetHelper.Refresh(processProcessComboBox, Process.GetChoices());
            ResetHelper.Refresh(processCheckedListBox, exhibition.Configuration.Processes.ToArray());
        }

        private void processAddButton_Click(object sender, EventArgs e)
        {
            var processType = processProcessComboBox.SelectedItem;
            var minLengthText = processMinLengthTextBox.Text;
            var maxLengthText = processMaxLengthTextBox.Text;
            var startNodeText = processStartNodeTextBox.Text;
            var finishNodeText = processFinishNodeTextBox.Text;
            if (GeneralErrors.IsNull(processType, "نوع فرآیند")
                || GeneralErrors.IsEmptyField(minLengthText, "کمینه زمان اجرا")
                || GeneralErrors.IsEmptyField(maxLengthText, "بیشینه زمان اجرا")
                || GeneralErrors.IsEmptyField(startNodeText, "نقطه ی شروع")
                || GeneralErrors.IsEmptyField(finishNodeText, "نقطه ی پایان"))
                return;

            if (GeneralErrors.IsNotValidInt(minLengthText, 0, "کمینه زمان اجرا")
                || GeneralErrors.IsNotValidInt(maxLengthText, int.Parse(minLengthText), "بیشینه زمان اجرا")
                || GeneralErrors.IsNotValidInt(startNodeText, 0, "نقطه ی شروع")
                || GeneralErrors.IsNotValidInt(finishNodeText, int.Parse(startNodeText) + 1, "نقطه ی پایان"))
                return;

            var exhibition = Program.Exhibition;
            var process = new Process
            {
                Configuration = exhibition.Configuration,
                Type = (ProcessType) processType,
                MinLength = int.Parse(minLengthText),
                MaxLength = int.Parse(maxLengthText),
                StartNode = int.Parse(startNodeText),
                FinishNode = int.Parse(finishNodeText)
            };
            exhibition.State = ExhibitionState.Configuration;
            var db = DataManager.DataContext;
            db.Processes.Add(process);
            db.SaveChanges();

            ProcessPageReset();
            PopUp.ShowSuccess("فرآیند خواسته شده به پیکربندی اضافه شد.");
        }

        private void processRemoveButton_Click(object sender, EventArgs e)
        {
            if (GeneralErrors.IsZero(processCheckedListBox.CheckedItems.Count, "فرآیند"))
                return;

            var db = DataManager.DataContext;
            foreach (var process in processCheckedListBox.CheckedItems.Cast<Process>())
            {
//                Program.Exhibition.Configuration.Processes.Remove(process);
                db.Processes.Remove(process);
            }

            db.SaveChanges();
            ProcessPageReset();
            PopUp.ShowSuccess("نقش های انتخاب شده حذف گردید.");
        }
    }
}
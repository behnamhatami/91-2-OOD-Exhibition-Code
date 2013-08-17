#region

using System;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ExhibitionPackage.ExhibitionRolePackage;
using OOD.Model.ModelContext;
using OOD.Model.UserManagingPackage;
using OOD.UI.UtilityPackage.Base;
using OOD.UI.UtilityPackage.Helper;
using OOD.UI.UtilityPackage.PopUp;

#endregion

namespace OOD.UI.ExhibitionPackage.ExhibitionDefinitionPackage
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
            base.Reset();
            TabControl1.Controls.Clear();

            var secondPhase = Program.Exhibition.State == ExhibitionState.Freezed;

            TabControl1.Controls.Add(featurePage);
            FeaturePageReset();

            TabControl1.Controls.Add(processPage);
            ProcessPageReset();


            if (secondPhase)
            {
                RolePageReset();
                TabControl1.Controls.Add(rolePage);
            }
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
                    || exhibition.State == ExhibitionState.Configuration
                    || exhibition.State == ExhibitionState.FreezeStarted
                    || exhibition.State == ExhibitionState.Freezed)
                    return true;
                GeneralErrors.Closed("پیکربندی");
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
            ResetHelper.Refresh(featureInitialConfigurationComboBox, db.Exhibitions);

            var firstPhase = exhibition.State == ExhibitionState.Created ||
                             exhibition.State == ExhibitionState.Configuration;

            var feature = exhibition.Feature;
            featurePostOfficeCheckBox.Checked = feature.HasPostOffice;
            featureWareHouseCheckBox.Checked = feature.HasWareHouse;
            featureSellRadioButton.Checked = feature.HasSell;
            featureNoSellRadioButton.Checked = !feature.HasSell;
            featureDifferentBoothCheckBox.Checked = feature.HasDifferentBooth;
            featureOkeyButton.Enabled = firstPhase;
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
                configuration.AddFromConfiguration(newExhibition.Configuration);
            }
            db.SaveChanges();
            PopUp.ShowSuccess("تغییرات مد نظر با موفقیت اعمال گردید.");
            Reset();
        }

        // Rolls

        private void RolePageReset()
        {
            var db = DataManager.DataContext;

            ResetHelper.Refresh(roleChoicesComboBox, ExhibitionRole.GetChoices());
            ResetHelper.Refresh(roleUserComboBox, db.Users);
            ResetHelper.Refresh(roleUserExhibitionRoleListBox, Program.Exhibition.UserExhibitionRoles);
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
            userExhibitionRole.NotifyAdd();
            var db = DataManager.DataContext;
            db.UserExhibitionRoles.Add(userExhibitionRole);
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
                userExhibitionRole.NotifyRemove();
                db.UserExhibitionRoles.Remove(userExhibitionRole);
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
                processFinishNodeTextBox, processMileStoneCheckBox, processMileStoneTextBox);
            ResetHelper.Refresh(processProcessComboBox, ProcessTypeWrapper.ProcessTypes);
            ResetHelper.Refresh(processCheckedListBox, exhibition.Configuration.Processes);

            var firstPhase = exhibition.State == ExhibitionState.Created ||
                             exhibition.State == ExhibitionState.Configuration;
            processRemoveButton.Enabled = firstPhase;
            processAddButton.Enabled = firstPhase;
            processMileStoneTextBox.Visible = false;
        }

        private void processAddButton_Click(object sender, EventArgs e)
        {
            var processType = processProcessComboBox.SelectedItem as ProcessTypeWrapper;
            var minLengthText = processMinLengthTextBox.Text;
            var maxLengthText = processMaxLengthTextBox.Text;
            var startNodeText = processStartNodeTextBox.Text;
            var finishNodeText = processFinishNodeTextBox.Text;
            var isMileStone = processMileStoneCheckBox.Checked;
            var mileStone = processMileStoneTextBox.Text;

            if (GeneralErrors.IsNull(processType, "نوع فرآیند")
                || GeneralErrors.IsEmptyField(minLengthText, "کمینه زمان اجرا")
                || GeneralErrors.IsEmptyField(maxLengthText, "بیشینه زمان اجرا")
                || GeneralErrors.IsEmptyField(startNodeText, "نقطه ی شروع")
                || GeneralErrors.IsEmptyField(finishNodeText, "نقطه ی پایان")
                || (isMileStone && GeneralErrors.IsEmptyField(mileStone, "پیغام نقطه عطف")))
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
                Type = processType.ProcessType,
                MinLength = int.Parse(minLengthText),
                MaxLength = int.Parse(maxLengthText),
                StartNode = int.Parse(startNodeText),
                FinishNode = int.Parse(finishNodeText),
                Finished = false,
                Started = false,
                StartDate = DateTimeManager.Today,
                IsMileStone = isMileStone,
                MileStoneMessage = mileStone
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
                db.Processes.Remove(process);

            db.SaveChanges();
            ProcessPageReset();
            PopUp.ShowSuccess("نقش های انتخاب شده حذف گردید.");
        }

        private void processMileStoneCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            processMileStoneTextBox.Visible = processMileStoneCheckBox.Checked;
        }
    }
}
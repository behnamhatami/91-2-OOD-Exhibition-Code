#region

using System;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ExhibitionPackage.ExhibitionRolePackage;
using OOD.UI.UtilityPackage.Base;
using OOD.UI.UtilityPackage.Helper;
using OOD.UI.UtilityPackage.PopUp;

#endregion

namespace OOD.UI.NotificationPackage
{
    public partial class Home : MainWindow
    {
        public Home()
        {
            InitializeComponent();
        }

        // IResetAble

        public override void Reset()
        {
            base.Reset();
            tabControl1.Controls.Clear();

            if (HasExhibitionInformationPreCondition())
            {
                tabControl1.Controls.Add(exhibitionInformationTabPage);
                ExhibitionInformationReset();
            }

            if (HasUserInformationPreCondition())
            {
                tabControl1.Controls.Add(userInformationTabPage);
                UserInformationReset();
            }

            if (HasProcessRunningInformationPreCondition())
            {
                tabControl1.Controls.Add(processTabPage);
                ProcessRunningInformationReset();
            }

            nextDayButton.Visible = Program.Exhibition != null;
        }

        // IPrecondition

        public override bool NeedUser()
        {
            return true;
        }


        public override bool NeedExhibition()
        {
            return false;
        }

        //IReloadAble

        public override int GetLevel()
        {
            return 2;
        }

        public override bool RestoreAble()
        {
            return true;
        }

        // User Information

        private bool HasUserInformationPreCondition()
        {
            return true;
        }

        private void UserInformationReset()
        {
            var user = Program.User;
            userUsernameTextBox.Text = user.Username;
            userFirstNameTextBox.Text = user.FirstName;
            userFamilyNameTextBox.Text = user.FamilyName;
            userPhoneTextBox.Text = user.PhoneNumber + "";
            userRoletextBox.Text = user.UserRole.ToString();

            ResetHelper.Refresh(userExhibitionslistBox, user.Exhibitions);
        }

        // Exhibition Information

        private bool HasExhibitionInformationPreCondition()
        {
            return Program.Exhibition != null;
        }

        private void ExhibitionInformationReset()
        {
            var exhibition = Program.Exhibition;
            var user = Program.User;
            exhibitionNameTextBox.Text = exhibition.Name;
            exhibitionDescriptionTextBox.Text = exhibition.Description;
            exhibitionFullDescriptionTextBox.Text = exhibition.FullDescription;
            exhibitionCreatorTextBox.Text = exhibition.Owner;
            ResetHelper.Refresh(exhibitionChairMansListBox, exhibition.ChairUsers);
            ResetHelper.Refresh(exhibitionUserRolesListBox,
                exhibition.UserExhibitionRoles.Where(role => role.User.Id == user.Id));
        }

        // Process Running Information

        private bool HasProcessRunningInformationPreCondition()
        {
            return Program.Exhibition != null && Program.Exhibition.State == ExhibitionState.Started;
        }

        private void ProcessRunningInformationReset()
        {
            ResetHelper.Empty(processNameTextBox, processStartDateTextBox);
            processProgressBar.Value = 0;
            processFinishButton.Visible = false;

            ResetHelper.Refresh(processesComboBox, Program.ProcessManager.RunningProcesses());
            ResetHelper.Refresh(processRemainingListBox, Program.ProcessManager.RemainingProcesses());
        }

        private void processShowButton_Click(object sender, EventArgs e)
        {
            var process = processesComboBox.SelectedItem as Process;
            if (GeneralErrors.IsNull(process, "فرآیند"))
                return;

            processNameTextBox.Text = ProcessTypeWrapper.GetWrapper(process.Type).ToString();
            processStartDateTextBox.Text = process.StartDate.ToString();
            processProgressBar.Value = ((DateTimeManager.Today.Subtract(process.StartDate).Days + 1)*100)/
                                       process.MaxLength;

            processFinishButton.Visible = Program.Exhibition.HasRole<ExecutionRole>(Program.User)
                                          && !process.AnyFinishProblem();
        }

        private void processFinishButton_Click(object sender, EventArgs e)
        {
            var process = processesComboBox.SelectedItem as Process;
            process.ForceFinsih();
            PopUp.ShowSuccess("فرآیند اتمام یافت.");
            ProcessRunningInformationReset();
        }

        private void nextDayButton_Click(object sender, EventArgs e)
        {
            DateTimeManager.Tomorrow();
            PopUp.ShowSuccess("یک روز به جلو رفتیم.");
            Reset();
        }
    }
}
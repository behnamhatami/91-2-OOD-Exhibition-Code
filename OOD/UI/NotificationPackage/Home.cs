#region

using System.Linq;
using OOD.UI.UtilityPackage.Base;
using OOD.UI.UtilityPackage.Helper;

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
    }
}
using System;
using System.Linq;
using OOD.Model.ModelContext;
using OOD.Model.UserManaging;
using OOD.UI.Helper;
using OOD.UI.PopUp;

namespace OOD.UI.UserManaging
{
    public partial class UserCrud : MainWindow
    {
        public UserCrud()
        {
            InitializeComponent();
        }

        private void CreateReset()
        {
            ResetHelper.Empty(CreateUsernameTextBox, CreateFirstNameTextBox, CreateFamilyNameTextBox,
                CreateUserRoleComboBox, CreatePhoneTextBox, CreatePasswordTextBox, CreateRepeatPasswordTextBox);
            ResetHelper.Empty(CreateUserRoleComboBox);
            CreateUserRoleComboBox.Items.Clear();
            CreateUserRoleComboBox.Items.AddRange(UserRole.GetChoices());
        }

        private void EditReset()
        {
            ResetHelper.Empty(EditOldPasswordTextBox, EditNewPasswordTextBox, EditNewPasswordRepeatTextBox);
            EditChangePasswordCheckBox.Checked = false;
            EditChangePasswordCheckBox_CheckedChanged(null, null);

            var me = Program.User;
            if (me == null)
                ResetHelper.Empty(EditUsernameLabel, EditFirstNameTextBox, EditFamilyNameTextBox,
                    EditUserRoleLabel, EditPhoneTextBox);
            else
            {
                EditUsernameLabel.Text = me.Username;
                EditFirstNameTextBox.Text = me.FirstName;
                EditFamilyNameTextBox.Text = me.FamilyName;
                EditUserRoleLabel.Text = me.UserRole.ToString();
                EditPhoneTextBox.Text = String.Format("{0}", me.PhoneNumber);
            }
        }

        private void RemoveReset()
        {
            var db = DataManager.DataContext;
            ResetHelper.Empty(RemoveUsernameComboBox);
            RemoveUsernameComboBox.Items.Clear();
            RemoveUsernameComboBox.Items.AddRange(db.Users.ToArray());
        }

        private void UserCrud_Load(object sender, EventArgs e)
        {
            CreateReset();
            EditReset();
            RemoveReset();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            CreateReset();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GeneralErrors.IsEmptyField(CreateUsernameTextBox.Text, "نام کاربری"))
                return;

            var username = CreateUsernameTextBox.Text;

            if (!UserErrors.CheckUserDoesNotExists(username))
                return;

            var firstName = CreateFirstNameTextBox.Text;
            var familyName = CreateFamilyNameTextBox.Text;
            var phoneNumber = UserErrors.ParsePhoneNumber(CreatePhoneTextBox.Text);
            if (phoneNumber == -1)
                return;
            var userRole = (UserRole) CreateUserRoleComboBox.SelectedItem;
            if (GeneralErrors.IsNull(userRole, "سطح دسترسی"))
                return;

            var password = CreatePasswordTextBox.Text;
            if (GeneralErrors.IsEmptyField(password, "رمز عبور"))
                return;

            if (!UserErrors.IsSamePassword(password, CreateRepeatPasswordTextBox.Text))
                return;

            var user = new User
            {
                Username = username,
                FirstName = firstName,
                FamilyName = familyName,
                PhoneNumber = phoneNumber,
                UserRole = userRole,
                Password = User.Encrypt(password)
            };
            var db = DataManager.DataContext;
            db.Users.Add(user);
            db.SaveChanges();
            CreateReset();
            PopUp.PopUp.ShowSuccess("کاربر با موفقیت ساخته شد.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditReset();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var me = Program.User;
            if (me == null)
                return;

            var firstName = EditFirstNameTextBox.Text;
            var familyName = EditFamilyNameTextBox.Text;
            var phoneNumber = UserErrors.ParsePhoneNumber(EditPhoneTextBox.Text);
            if (phoneNumber == -1)
                return;

            if (EditChangePasswordCheckBox.Checked)
            {
                var oldPassword = EditOldPasswordTextBox.Text;
                if (GeneralErrors.IsEmptyField(oldPassword, "رمز عبور", "قبلی"))
                    return;

                if (UserErrors.AuthenticateIsNotValid(me, oldPassword))
                    return;

                var newPassword = EditNewPasswordTextBox.Text;
                if (GeneralErrors.IsEmptyField(newPassword, "رمز عبور", "جدید"))
                    return;

                if (!UserErrors.IsSamePassword(newPassword, EditNewPasswordRepeatTextBox.Text))
                    return;
            }

            me.FirstName = firstName;
            me.FamilyName = familyName;
            me.PhoneNumber = phoneNumber;
            if (EditChangePasswordCheckBox.Checked)
                me.Password = User.Encrypt(EditNewPasswordTextBox.Text);

            var db = DataManager.DataContext;
            db.SaveChanges();
            EditReset();
            PopUp.PopUp.ShowSuccess("تغییرات با موفقیت انجام شد.");
        }

        private void EditChangePasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ResetHelper.SetEnable(EditChangePasswordCheckBox.Checked, EditOldPasswordTextBox,
                EditNewPasswordTextBox, EditNewPasswordRepeatTextBox);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RemoveReset();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var user = (User) RemoveUsernameComboBox.SelectedItem;
            var db = DataManager.DataContext;
            db.Users.Remove(user);
            db.SaveChanges();
            RemoveReset();
            PopUp.PopUp.ShowSuccess("حذف با موفقیت انجام شد.");
        }
    }
}
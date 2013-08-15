#region

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ExhibitionPackage.ExhibitionRoles;
using OOD.Model.ModelContext;
using OOD.Model.NotificationPackage;
using OOD.UI.Utility.Base;
using OOD.UI.Utility.Helper;
using OOD.UI.Utility.PopUp;

#endregion

namespace OOD.UI.Notification
{
    public partial class CallCreation : MainWindow
    {
        private List<String> _attachments;

        public CallCreation()
        {
            InitializeComponent();
        }


        // IResetAble

        public void SyncWithPublicCheck()
        {
            _attachments = new List<string>();
            groupBox1.Text = newsPublicNotificationCheckBox.Checked ? "الحاقات" : "تلقن ها";
            label7.Text = newsPublicNotificationCheckBox.Checked ? "لیست الحاقات" : "لیست تلفن ها";
            label8.Visible = !newsPublicNotificationCheckBox.Checked;
            newsPhoneTextBox.Visible = !newsPublicNotificationCheckBox.Checked;
            ResetHelper.Empty(newsAttachmentListBox);
            RefreshList();
        }

        public void RefreshList()
        {
            ResetHelper.Refresh(newsAttachmentListBox, _attachments.ToArray());
        }

        public override void Reset()
        {
            ResetHelper.Empty(newsTitleTextBox, newsContentTextBox, newsImageTextBox, newsAttachmentListBox);
            ResetHelper.Refresh(newsPublicNotificationCheckBox, true);
            RefreshList();
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
            if (exhibition.HasRole<ExecutionRole>(user))
            {
                if (exhibition.State == ExhibitionState.Started)
                    return true;
                GeneralErrors.Closed("ساخت خبر");
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

        private void newsCancelButton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void newsImageSelectionButton_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result != DialogResult.Cancel)
                newsImageTextBox.Text = openFileDialog1.FileName;
        }

        private void newsAddAttachmentButton_Click(object sender, EventArgs e)
        {
            if (newsPublicNotificationCheckBox.Checked)
            {
                var result = openFileDialog1.ShowDialog();
                if (result != DialogResult.Cancel)
                {
                    _attachments.Add(openFileDialog1.FileName);
                    RefreshList();
                }
            }
            else
            {
                var phone = newsPhoneTextBox.Text;
                if (GeneralErrors.IsEmptyField(phone, "شماره تلفن"))
                    return;
                _attachments.Add(phone);
                RefreshList();
            }
        }

        private void newsRemoveAttachmentButton_Click(object sender, EventArgs e)
        {
            if (GeneralErrors.IsZero(newsAttachmentListBox.SelectedItems.Count, "الحاقات"))
                return;
            foreach (var path in newsAttachmentListBox.SelectedItems)
                _attachments.Remove(path as String);
            RefreshList();
        }

        private void newsCreationButton_Click(object sender, EventArgs e)
        {
            var title = newsTitleTextBox.Text;
            var content = newsContentTextBox.Text;
            var imagePath = newsImageTextBox.Text;
            if (GeneralErrors.IsEmptyField(title, "تیتر خبر")
                || GeneralErrors.IsEmptyField(content, "محتوای خبر")
                || GeneralErrors.IsEmptyField(imagePath, "آدرس عکس"))
                return;

            var db = DataManager.DataContext;
            if (newsPublicNotificationCheckBox.Checked)
            {
                var news = new News
                {
                    Title = title,
                    Content = content,
                    CreationDate = DateTime.Today,
                    Image = imagePath,
                    Exhibition = Program.Exhibition,
                    User = Program.System
                };
                db.Notifications.Add(news);

                foreach (var path in _attachments)
                    db.Attachments.Add(new Attachment
                    {
                        News = news,
                        Path = path
                    });
            }
            else
            {
                var phoneNews = new PhoneNews
                {
                    Title = title,
                    Content = content,
                    CreationDate = DateTime.Today,
                    Exhibition = Program.Exhibition,
                    User = Program.System
                };
                db.Notifications.Add(phoneNews);

                foreach (var phone in _attachments)
                    db.PhoneInformations.Add(new PhoneInformation
                    {
                        Phone = phone,
                        PhoneNews = phoneNews
                    });
            }
            db.SaveChanges();
            Reset();
            PopUp.ShowSuccess("خبر جدید در سیستم ثبت گردید.");
        }

        private void newsPublicNotificationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SyncWithPublicCheck();
        }

        // Finish
    }
}
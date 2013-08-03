#region

using System;
using System.Windows.Forms;
using OOD.UI.ExhibitionPackage.ExhibitionDefinition;
using OOD.UI.Utility.Interface;

#endregion

namespace OOD.UI.Utility.Base
{
    public partial class BaseForm : Form, IPreCondition, IReloadable, IResetAble
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        // IResetAble

        // IPrecondition

        public virtual bool NeedUser()
        {
            return false;
        }

        public virtual bool NeedExhibition()
        {
            return false;
        }

        public virtual bool ValidatePreConditions()
        {
            if (NeedExhibition() && Program.Exhibition == null)
            {
                PopUp.PopUp.ShowError(" قبل از ورود به این قسمت شما باید به یک نمایشگاه وارد شوید.");
                return false;
            }
            if (NeedUser() && Program.User == null)
            {
                PopUp.PopUp.ShowError(" قبل از ورود به این قسمت شما باید به یک حساب کاربری وارد شوید.");
                return false;
            }
            return true;
        }

        public void PreConditionResolver()
        {
            if (NeedExhibition() && Program.Exhibition == null)
                GoNext(new ExhibitionSelector(), true);
        }

        //IReloadAble

        public virtual void Reload()
        {
        }

        public virtual int GetLevel()
        {
            return 0;
        }

        public virtual bool RestoreAble()
        {
            return true;
        }

        public void Restore()
        {
            if (NeedExhibition() && Program.Exhibition == null)
            {
                Close();
                return;
            }

            if (NeedUser() && Program.User == null)
            {
                Close();
                return;
            }

            Reload();
            Show();
        }

        public virtual void Reset()
        {
        }

        protected void GoNext(BaseForm form, bool redirection = false)
        {
            form.PreConditionResolver();
            if (!form.ValidatePreConditions())
            {
                Reload();
                return;
            }

            if (!redirection)
            {
                Hide();
                if (!RestoreAble() || form.GetLevel() <= GetLevel())
                    Close();
            }

            form.ShowDialog();
            form.Dispose();

            if (!redirection && RestoreAble() && form.GetLevel() > GetLevel())
                Restore();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
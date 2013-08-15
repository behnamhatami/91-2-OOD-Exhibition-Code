#region

using System;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ExhibitionPackage.ExhibitionRoles;
using OOD.Model.ModelContext;
using OOD.UI.Utility.Base;
using OOD.UI.Utility.PopUp;

#endregion

namespace OOD.UI.ExhibitionPackage.ExhibitionDefinition
{
    public partial class RequestForFreeze : BaseForm
    {
        public RequestForFreeze()
        {
            InitializeComponent();
        }

        // IResetAble

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
                if (exhibition.State == ExhibitionState.Configuration)
                    return true;
                GeneralErrors.Closed("درخواست انجماد");
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
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var exhibition = Program.Exhibition;
            var poll = exhibition.Polls.First();
            poll.Reset();
            poll.Closed = false;
            poll.Started = true;
            exhibition.State = ExhibitionState.FreezeStarted;
            DataManager.DataContext.SaveChanges();
            PopUp.ShowSuccess("رای گیری آغاز گردید.");
            Close();
        }

        // Finish
    }
}
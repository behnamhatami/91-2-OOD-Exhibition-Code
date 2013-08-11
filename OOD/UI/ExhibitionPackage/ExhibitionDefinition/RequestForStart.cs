#region

using System;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ExhibitionPackage.ExhibitionRoles;
using OOD.Model.ModelContext;
using OOD.UI.Utility.Base;
using OOD.UI.Utility.PopUp;

#endregion

namespace OOD.UI.ExhibitionPackage.ExhibitionDefinition
{
    public partial class RequestForStart : BaseForm
    {
        public RequestForStart()
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
                if (exhibition.State == ExhibitionState.Freezed)
                    return true;
                PopUp.ShowError("قسمت آغاز بسته شده است.");
                return false;
            }
            GeneralErrors.AccessDenied();
            return false;
        }

        //IReloadAble

        public override int GetLevel()
        {
            return 4;
        }

        public override bool RestoreAble()
        {
            return false;
        }

        // Finish


        private void button1_Click(object sender, EventArgs e)
        {
            var exhibition = Program.Exhibition;
            exhibition.State = ExhibitionState.Started;
            DataManager.DataContext.SaveChanges();
            PopUp.ShowSuccess(string.Format("نمایشگاه {0} آغاز گردید", exhibition));
            Close();
        }
    }
}
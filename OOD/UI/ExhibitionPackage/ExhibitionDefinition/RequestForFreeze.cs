using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ModelContext;
using OOD.UI.Utility.Base;
using OOD.UI.Utility.PopUp;

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
            if (user.UserExhibitionRoles.Count(role => role.Exhibition.Id == Program.Exhibition.Id) > 0)
            {
                if (exhibition.State == ExhibitionState.Configuration)
                    return true;
                PopUp.ShowError("قسمت درخواست انجماد بسته شده است.");
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

        private void button1_Click(object sender, System.EventArgs e)
        {
            var exhibition = Program.Exhibition;
            exhibition.Polls.First().Reset();
            exhibition.State = ExhibitionState.FreezeStarted;
            DataManager.DataContext.SaveChanges();
            PopUp.ShowSuccess("رای گیری آغاز گردید.");
            Close();
        }

        // Finish
    }
}
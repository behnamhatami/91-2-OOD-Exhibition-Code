#region

using System;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ExhibitionPackage.ExhibitionRolePackage;
using OOD.Model.ModelContext;
using OOD.UI.UtilityPackage.Base;
using OOD.UI.UtilityPackage.PopUp;

#endregion

namespace OOD.UI.ExhibitionPackage.ExhibitionDefinitionPackage
{
    public partial class RequestForFinish : BaseForm
    {
        public RequestForFinish()
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
            var processManager = Program.ProcessManager;
            if (exhibition.HasRole<ChairRole>(user))
            {
                if (processManager.RemainingProcesses().Any())
                {
                    PopUp.ShowError("نمایشگاه هنوز در حال اجرای تعدادی زیر فرآیند است.");
                    return false;
                }

                if (exhibition.State == ExhibitionState.Started)
                    return true;

                GeneralErrors.Closed("درخواست اتمام نمایشگاه");
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
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var exhibition = Program.Exhibition;
            exhibition.State = ExhibitionState.Finished;
            DataManager.DataContext.SaveChanges();
            PopUp.ShowSuccess(string.Format("نمایشگاه {0} اتمام یافت", exhibition));
            Close();
        }
    }
}
#region

using System;
using System.Linq;
using System.Windows.Forms;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage;
using OOD.Model.ExhibitionPackage.ExhibitionRolePackage;
using OOD.Model.ModelContext;
using OOD.UI.UtilityPackage.Base;
using OOD.UI.UtilityPackage.Helper;
using OOD.UI.UtilityPackage.PopUp;

#endregion

namespace OOD.UI.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionBoothPackage
{
    public partial class BoothCrud : MainWindow
    {
        public BoothCrud()
        {
            InitializeComponent();
        }

        // IResetAble

        public override void Reset()
        {
            base.Reset();
            tabControl1.Controls.Clear();

            if (HasEditSaloonPreCondition())
            {
                tabControl1.Controls.Add(editSaloonTabPage);
                EditSaloonReset();
            }

            if (HasBoothConstuctorCreationPreCondition())
            {
                tabControl1.Controls.Add(boothConstructorCreationTabPage);
                BoothConstructorCreationReset();
            }

            if (HasBoothConstructorAssignmentPreCondition())
            {
                tabControl1.Controls.Add(boothConstructorAssignmentTabPage);
                BoothConstructorAssignmentReset();
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
            if (exhibition.HasRole<BoothManagerRole>(user))
            {
                if (exhibition.State == ExhibitionState.Started)
                    return true;
                GeneralErrors.Closed("مدیریت غرفه");
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

        private void boothActionButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var booth = BoothDrawerHelper.GetBooth(button, editSaloonListComboBox.SelectedItem as Saloon);
            booth.SwitchState();
            BoothDrawerHelper.ButtonReDraw(booth, button);
            DataManager.DataContext.SaveChanges();
        }

        // Finish

        // Edit Saloon

        private bool HasEditSaloonPreCondition()
        {
            return Program.ProcessManager.IsProcessRunning(ProcessType.SaloonCrud);
        }

        private void EditSaloonReset()
        {
            ResetHelper.Empty(editSaloonListComboBox);
            ResetHelper.Refresh(editSaloonListComboBox, Program.Exhibition.Saloons);
            flowLayoutPanel1.Controls.Clear();
        }

        private void editSaloonShowButton_Click(object sender, EventArgs e)
        {
            var saloon = editSaloonListComboBox.SelectedItem as Saloon;
            if (GeneralErrors.IsNull(saloon, "سالن"))
                return;
            BoothDrawerHelper.DrawSaloon(saloon, flowLayoutPanel1);
            foreach (var control in flowLayoutPanel1.Controls)
                (control as Button).Click += boothActionButton_Click;
        }

        // Constructor Creation

        private bool HasBoothConstuctorCreationPreCondition()
        {
            return Program.ProcessManager.IsProcessRunning(ProcessType.BoothConstruction);
        }

        private void BoothConstructorCreationReset()
        {
            ResetHelper.Empty(boothConstructorNameTextBox, boothConstructorProfessionTextBox,
                boothConstructorQualityTextBox, boothConstructorDurationTextBox, boothConstructorCostTextBox);
            ResetHelper.Refresh(boothConstructorQualityTextBox, ProfessionQualityWrapper.Types);
            ResetHelper.Refresh(boothConstructorProfessionTextBox, ProfessionTypeWrapper.Types);
            ResetHelper.Refresh(boothConstructorsListBox, Program.Exhibition.Constructors);
        }

        private void boothConstructorCancelButton_Click(object sender, EventArgs e)
        {
            BoothConstructorCreationReset();
        }

        private void boothConstructorCreateButton_Click(object sender, EventArgs e)
        {
            var name = boothConstructorNameTextBox.Text;
            var professionTypeWrapper = boothConstructorProfessionTextBox.SelectedItem as ProfessionTypeWrapper;
            var quality = boothConstructorQualityTextBox.SelectedItem as ProfessionQualityWrapper;
            var duration = boothConstructorDurationTextBox.Text;
            var cost = boothConstructorCostTextBox.Text;

            if (GeneralErrors.IsNull(professionTypeWrapper, "خدمت")
                || GeneralErrors.IsNull(quality, "کیفیت")
                || GeneralErrors.IsEmptyField(name, "نام سازنده")
                || GeneralErrors.IsNotValidInt(duration, 1, "مدت زمان ساخت")
                || GeneralErrors.IsNotValidInt(cost, 1, "هزینه ی ساخت"))
                return;

            var constructor = new BoothConstructor
            {
                Ability = new ConstructAbility
                {
                    Cost = int.Parse(cost),
                    Duration = int.Parse(duration),
                    Profession = new Profession
                    {
                        Quality = quality.Quality,
                        ProfessionType = professionTypeWrapper.Profession
                    },
                },
                Exhibition = Program.Exhibition,
                Name = name,
                ReserverdDays = 0,
            };

            var db = DataManager.DataContext;
            db.Constructors.Add(constructor);
            db.SaveChanges();
            PopUp.ShowSuccess("سارنده ی جدید در سیستم وارد گردید.");
            BoothConstructorCreationReset();
        }

        // Booth Construction
        private bool HasBoothConstructorAssignmentPreCondition()
        {
            return Program.ProcessManager.IsProcessRunning(ProcessType.BoothConstruction);
        }

        private void BoothConstructorAssignmentReset()
        {
            ResetHelper.RemoveItems(boothConstructorAssignmentBoothsComboBox,
                boothConstructorAssignmentProfessionsComboBox,
                boothConstructorAssignmentConstructorsComboBox);
            ResetHelper.Refresh(boothConstructorAssignmentSaloonsComboBox, Program.Exhibition.Saloons);
        }

        private void boothConstructorAssignmentSaloonsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var saloon = boothConstructorAssignmentSaloonsComboBox.SelectedItem as Saloon;
            if (saloon != null)
            {
                ResetHelper.Refresh(boothConstructorAssignmentBoothsComboBox,
                    saloon.Map.Booths.Where(booth => booth.ExtensionRequest != null));
            }
            else
            {
                ResetHelper.RemoveItems(boothConstructorAssignmentBoothsComboBox,
                    boothConstructorAssignmentProfessionsComboBox,
                    boothConstructorAssignmentConstructorsComboBox);
            }
        }

        private void boothConstructorAssignmentBoothsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var booth = boothConstructorAssignmentBoothsComboBox.SelectedItem as Booth;
            if (booth != null)
            {
                ResetHelper.Refresh(boothConstructorAssignmentProfessionsComboBox, booth.Assignments);
            }
            else
            {
                ResetHelper.RemoveItems(boothConstructorAssignmentProfessionsComboBox,
                    boothConstructorAssignmentConstructorsComboBox);
            }
        }

        private void boothConstructorAssignmentProfessionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var assignment = boothConstructorAssignmentProfessionsComboBox.SelectedItem as ProfessionAssignment;
            if (assignment != null)
            {
                ResetHelper.Refresh(boothConstructorAssignmentConstructorsComboBox,
                    Program.Exhibition.GetProperConstructors(assignment));
            }
            else
            {
                ResetHelper.RemoveItems(boothConstructorAssignmentConstructorsComboBox);
            }
        }

        private void boothConstructorAssignemtCancelButton_Click(object sender, EventArgs e)
        {
            BoothConstructorAssignmentReset();
        }

        private void boothConstructorAssignemtAssignButton_Click(object sender, EventArgs e)
        {
            var saloon = boothConstructorAssignmentSaloonsComboBox.SelectedItem as Saloon;
            var booth = boothConstructorAssignmentBoothsComboBox.SelectedItem as Booth;
            var constructor = boothConstructorAssignmentConstructorsComboBox.SelectedItem as BoothConstructor;
            if (GeneralErrors.IsNull(saloon, "سالن")
                || GeneralErrors.IsNull(booth, "غرفه")
                || GeneralErrors.IsNull(constructor, "سازنده"))
                return;

            var request = booth.ExtensionRequest as BoothExtensionRequest;
            var professionAssignment = request.ProfessionsAssignments.First(
                assignment =>
                    assignment.Profession.Quality == constructor.Ability.Profession.Quality &&
                    assignment.Profession.ProfessionType == constructor.Ability.Profession.ProfessionType);
            professionAssignment.Constructor = constructor;
            constructor.ReserverdDays += constructor.Ability.Duration;
            DataManager.DataContext.SaveChanges();
            PopUp.ShowSuccess("وظیفه ی محوله به سازنده محول گردید.");
            PopUp.ShowWarning(String.Format("به سازنده {0}، {1} روز کار تخصیص داده شده است."
                , constructor.Name, constructor.ReserverdDays));
            BoothConstructorAssignmentReset();
        }
    }
}
﻿#region

using System;
using System.Windows.Forms;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionBooth;
using OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionRequest;
using OOD.Model.ExhibitionPackage.ExhibitionRoles;
using OOD.Model.ModelContext;
using OOD.UI.Utility.Base;
using OOD.UI.Utility.Helper;
using OOD.UI.Utility.PopUp;

#endregion

namespace OOD.UI.ExhibitionPackage.ExhibitionProgress.ExhibitionBooth
{
    public partial class BoothSelector : BaseForm
    {
        private readonly BoothRequest _request;

        public BoothSelector()
        {
            InitializeComponent();
        }

        public BoothSelector(BoothRequest request)
        {
            InitializeComponent();
            _request = request;
        }

        // IResetAble

        public override void Reset()
        {
            ResetHelper.Refresh(saloonListComboBox, Program.Exhibition.Saloons);
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
            return 4;
        }

        public override bool RestoreAble()
        {
            return true;
        }

        private void boothActionButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var booth = BoothCrud.GetBooth(button, saloonListComboBox.SelectedItem as Saloon);
            booth.Register(_request);
            BoothCrud.ButtonReDraw(booth, button);
            DataManager.DataContext.SaveChanges();
        }

        // Finish

        private void saloonShowButton_Click(object sender, EventArgs e)
        {
            var saloon = saloonListComboBox.SelectedItem as Saloon;
            if (GeneralErrors.IsNull(saloon, "سالن"))
                return;

            BoothCrud.DrawSaloon(saloon, flowLayoutPanel1);
            foreach (var control in flowLayoutPanel1.Controls)
                (control as Button).Click += boothActionButton_Click;
        }
    }
}
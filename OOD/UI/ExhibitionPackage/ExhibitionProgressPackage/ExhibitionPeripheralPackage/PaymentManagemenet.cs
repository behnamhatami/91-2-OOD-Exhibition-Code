#region

using System;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionPeripheralPackage;
using OOD.Model.ExhibitionPackage.ExhibitionRolePackage;
using OOD.Model.ModelContext;
using OOD.UI.UtilityPackage.Base;
using OOD.UI.UtilityPackage.Helper;
using OOD.UI.UtilityPackage.PopUp;

#endregion

namespace OOD.UI.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionPeripheralPackage
{
    public partial class PaymentManagemenet : MainWindow
    {
        public PaymentManagemenet()
        {
            InitializeComponent();
        }


        // IResetAble

        public override void Reset()
        {
            CreateItemPageReset();
            ListPageReset();
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

            if (exhibition.HasRole<ECustomerRole>(user))
            {
                if (exhibition.State == ExhibitionState.Started)
                    return true;
                GeneralErrors.Closed("مالی");
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

        // Finish

        private void CreateItemPageReset()
        {
            ResetHelper.Empty(createItemAmountTextBox, createItemDateTimePicker);
        }

        private void ListPageReset()
        {
            ResetHelper.Empty(listAmountTextBox, listDateTextBox, listIdTextBox);
            ResetHelper.Refresh(listListBox,
                Program.Exhibition.Payments
                    .Where(payment => payment.User.Id == Program.User.Id));
        }

        private void createItemButton_Click(object sender, EventArgs e)
        {
            var amount = createItemAmountTextBox.Text;
            var date = createItemDateTimePicker.Value;
            if (GeneralErrors.IsNull(date, "تاریخ فیش")
                || GeneralErrors.IsNotValidInt(amount, 0, "میزان فیش"))
                return;

            var payment = new Payment
            {
                Exhibition = Program.Exhibition,
                User = Program.User,
                Amount = int.Parse(amount),
                Date = date
            };
            var db = DataManager.DataContext;
            db.Payments.Add(payment);
            db.SaveChanges();
            PopUp.ShowSuccess("فیش مدنظر در سیستم ثبت شد.");
            Reset();
        }

        private void listShowButton_Click(object sender, EventArgs e)
        {
            var payment = listListBox.SelectedItem as Payment;
            if (GeneralErrors.IsNull(payment, "فیش کالا"))
                return;

            listAmountTextBox.Text = payment.Amount + "";
            listDateTextBox.Text = payment.Date + "";
            listIdTextBox.Text = payment.Id + "";
        }
    }
}
#region

using System;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.UserManagingPackage;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionPeripheral
{
    public class Payment
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }

        public virtual Exhibition Exhibition { get; set; }
        public virtual User User { get; set; }


        public override string ToString()
        {
            return String.Format("فیش بانکی[شماره: {0}، تاریخ: {1}]", Id, Date);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var payment = obj as Payment;
            if (payment == null || payment.Id != Id)
                return false;
            return true;
        }
    }
}
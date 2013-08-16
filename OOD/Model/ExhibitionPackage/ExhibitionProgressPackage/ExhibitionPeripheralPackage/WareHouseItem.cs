#region

using System;
using OOD.Model.UserManagingPackage;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionPeripheralPackage
{
    public class WareHouseItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EntranceDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Boolean Released { get; set; }

        public virtual User User { get; set; }
        public virtual WareHouse WareHouse { get; set; }

        public override string ToString()
        {
            return String.Format("بار[شماره: {0}، انبار: {1}، کاربر: {2}]", Id, WareHouse, User);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var item = obj as WareHouseItem;
            if (item == null || item.Id != Id)
                return false;
            return true;
        }
    }
}
#region

using System;
using OOD.Model.UserManagingPackage;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionPeripheralPackage
{
    public class PostItem
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Destination { get; set; }

        public virtual PostOffice PostOffice { get; set; }
        public virtual User User { get; set; }


        public override string ToString()
        {
            return String.Format("محموله پستی[شماره: {0}، نوع: {1}]", Id, Type);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var item = obj as PostItem;
            if (item == null || item.Id != Id)
                return false;
            return true;
        }
    }
}
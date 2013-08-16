#region

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ModelContext;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionPeripheralPackage
{
    public class WareHouse
    {
        [Key, ForeignKey("Exhibition")]
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }
        public virtual Exhibition Exhibition { get; set; }

        [NotMapped]
        public IQueryable<WareHouseItem> WareHouseItems
        {
            get { return DataManager.DataContext.WareHouseItems.Where(item => item.WareHouse.Id == Id); }
        }

        [NotMapped]
        public IQueryable<WareHouseItem> WareHouseHodingItems
        {
            get
            {
                return
                    DataManager.DataContext.WareHouseItems.Where(
                        item => item.WareHouse.Id == Id && item.Released == false);
            }
        }


        public override string ToString()
        {
            return Exhibition.Name;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var house = obj as WareHouse;
            if (house == null || house.Id != Id)
                return false;
            return true;
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionRole;
using OOD.Model.ModelContext;
using OOD.Model.NotificationPackage;

namespace OOD.Model.ExhibitionPackage.ExhibitionDefinition
{
    public class Exhibition
    {
        public Exhibition()
        {
            CreationTime = DateTime.Now;
            State = ExhibitionState.Created;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FullDescription { get; set; }
        public string Owner { get; set; }
        public ExhibitionState State { get; set; }
        public DateTime CreationTime { get; set; }

        public virtual Feature Feature { get; set; }
        public virtual Configuration Configuration { get; set; }

        [NotMapped]
        public IQueryable<UserExhibitionRole> UserExhibitionRoles
        {
            get { return DataManager.DataContext.UserExhibitionRoles.Where(role => role.Exhibition.Id == Id); }
        }

        [NotMapped]
        public IQueryable<Poll> Polls
        {
            get { return DataManager.DataContext.Polls.Where(poll => poll.Exhibition.Id == Id); }
        }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var exhibition = obj as Exhibition;
            if (exhibition == null || exhibition.Id != Id)
                return false;
            return true;
        }
    }
}
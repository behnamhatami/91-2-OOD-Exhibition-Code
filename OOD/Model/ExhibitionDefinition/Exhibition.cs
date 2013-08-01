using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD.Logic.ExhibitionDefinition;
using OOD.Model.UserManaging;

namespace OOD.Model.ExhibitionDefinition
{
    public class Exhibition
    {
        public Exhibition()
        {
            this.Users = new HashSet<User>();
            this.CreationTime = DateTime.Now;
            this.State = ExhibitionState.Created;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FullDescription { get; set; }
        public string Owner { get; set; }
        public ExhibitionState State { get; set; }
        public DateTime CreationTime { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
#region

using System;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.UserManagingPackage;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionRequest
{
    public class Request
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public string Response { get; set; }
        public bool Closed { get; set; }
    
        public virtual Exhibition Exhibition { get; set; }
        public virtual User User { get; set; }


        public override string ToString()
        {
            return Title;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var request = obj as Request;
            if (request == null || request.Id != Id)
                return false;
            return true;
        }
    }
}
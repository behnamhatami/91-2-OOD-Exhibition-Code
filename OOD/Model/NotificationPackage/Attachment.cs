namespace OOD.Model.NotificationPackage
{
    public class Attachment
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public virtual News News { get; set; }


        public override string ToString()
        {
            return Path;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var attachment = obj as Attachment;
            if (attachment == null || attachment.Id != Id)
                return false;
            return true;
        }
    }
}
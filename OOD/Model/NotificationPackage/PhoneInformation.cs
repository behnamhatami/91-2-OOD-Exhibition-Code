namespace OOD.Model.NotificationPackage
{
    public class PhoneInformation
    {
        public int Id { get; set; }
        public string Phone { get; set; }

        public virtual PhoneNews PhoneNews { get; set; }


        public override string ToString()
        {
            return Phone;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var phoneInformation = obj as PhoneInformation;
            if (phoneInformation == null || phoneInformation.Id != Id)
                return false;
            return true;
        }
    }
}
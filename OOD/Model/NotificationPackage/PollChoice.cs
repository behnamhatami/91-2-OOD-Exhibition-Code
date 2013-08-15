namespace OOD.Model.NotificationPackage
{
    public class PollChoice
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Hit { get; set; }

        public virtual Poll Poll { get; set; }

        public void Vote()
        {
            Hit++;
        }

        public override string ToString()
        {
            return Content + " [" + Hit + "]"; 
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var pollChoice = obj as PollChoice;
            if (pollChoice == null || pollChoice.Id != Id)
                return false;
            return true;
        }
    }
}
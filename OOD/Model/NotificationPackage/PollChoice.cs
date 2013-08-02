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
    }
}
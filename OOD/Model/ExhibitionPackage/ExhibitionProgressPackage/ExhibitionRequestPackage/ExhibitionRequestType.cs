namespace OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage
{
    public enum ExhibitionRequestType
    {
        Entrance,
        Exit
    }

    public class ExhibitionRequestTypeWrapper
    {
        public static ExhibitionRequestTypeWrapper[] Types =
        {
            new ExhibitionRequestTypeWrapper(ExhibitionRequestType.Entrance, "ورود به نمایشگاه"),
            new ExhibitionRequestTypeWrapper(ExhibitionRequestType.Exit, "انصراف از نمایشگاه")
        };

        public ExhibitionRequestTypeWrapper(ExhibitionRequestType type, string name)
        {
            Type = type;
            Name = name;
        }

        public ExhibitionRequestType Type { get; set; }
        private string Name { get; set; }

        public static ExhibitionRequestTypeWrapper GetWrapper(ExhibitionRequestType type)
        {
            return Types[(int) type];
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
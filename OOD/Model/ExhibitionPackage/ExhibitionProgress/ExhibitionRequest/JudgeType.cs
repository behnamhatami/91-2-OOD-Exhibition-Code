namespace OOD.Model.ExhibitionPackage.ExhibitionProgress.ExhibitionRequest
{
    public enum JudgeType
    {
        Deposal,
        Fine,
        NothingImportant
    }

    public class JudgeTypeWrapper
    {
        public static JudgeTypeWrapper[] JudgeTypes =
        {
            new JudgeTypeWrapper(JudgeType.Deposal, "اخراج"),
            new JudgeTypeWrapper(JudgeType.Fine, "جریمه"),
            new JudgeTypeWrapper(JudgeType.NothingImportant, "بدون ایراد")
        };

        public JudgeTypeWrapper(JudgeType type, string name)
        {
            Type = type;
            Name = name;
        }

        public JudgeType Type { get; set; }
        private string Name { get; set; }

        public static JudgeTypeWrapper GetWrapper(JudgeType type)
        {
            return JudgeTypes[(int) type];
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
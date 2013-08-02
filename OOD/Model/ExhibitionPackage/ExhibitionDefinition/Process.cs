using System;

namespace OOD.Model.ExhibitionPackage.ExhibitionDefinition
{
    public class Process
    {
        public int Id { get; set; }
        public ProcessType Type { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; internal set; }
        public int StartNode { get; set; }
        public int FinishNode { get; set; }

        public virtual Configuration Configuration { get; set; }

        public static Object[] GetChoices()
        {
            object[] output =
            {
                ProcessType.BoothAssignment, ProcessType.BoothCreation
            };
            return output;
        }

        public override string ToString()
        {
            return String.Format("{0}({1}): [کمینه: {2}, بیشینه: {3}, شروع: {4}, پایان: {5}]", Id, Type, MinLength,
                MaxLength,
                StartNode, FinishNode);
        }


        public override int GetHashCode()
        {
            return 0;
        }

        public override bool Equals(object obj)
        {
            var process = obj as Process;
            if (process == null || process.Id != Id)
                return false;
            return true;
        }
    }
}
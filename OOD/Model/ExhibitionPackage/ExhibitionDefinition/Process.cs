#region

using System;

#endregion

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

        public Process Clone(Configuration newConfiguration)
        {
            return new Process
            {
                Type = Type,
                MinLength = MinLength,
                MaxLength = MaxLength,
                StartNode = StartNode,
                FinishNode = FinishNode,
                Configuration = newConfiguration
            };
        }

        public override string ToString()
        {
            return String.Format("{0}({1}): [کمینه: {2}, بیشینه: {3}, شروع: {4}, پایان: {5}]", Id,
                ProcessTypeWrapper.GetWrapper(Type), MinLength,
                MaxLength,
                StartNode, FinishNode);
        }


        public override int GetHashCode()
        {
            return Id;
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
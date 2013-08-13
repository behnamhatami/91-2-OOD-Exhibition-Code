#region

using System;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionDefinition
{
    public enum ExhibitionState
    {
        Created,
        Configuration,
        FreezeStarted,
        Freezed,
        Started,
        Finished
    }

    public class ExhibitionStateWrapper
    {
        public static ExhibitionStateWrapper[] ExhibitionStates =
        {
            new ExhibitionStateWrapper(ExhibitionState.Created, "ساخته شده"),
            new ExhibitionStateWrapper(ExhibitionState.Configuration, "پیکربندی"),
            new ExhibitionStateWrapper(ExhibitionState.FreezeStarted, "شروع انجماد"),
            new ExhibitionStateWrapper(ExhibitionState.Freezed, "اتمام انجماد"),
            new ExhibitionStateWrapper(ExhibitionState.Started, "آغاز نمایشگاه"),
            new ExhibitionStateWrapper(ExhibitionState.Finished, "اتمام نمایشگاه")
        };

        public ExhibitionStateWrapper(ExhibitionState exhibitionState, String name)
        {
            ExhibitionState = exhibitionState;
            Name = name;
        }

        public ExhibitionState ExhibitionState { get; set; }
        private String Name { get; set; }

        public static ExhibitionStateWrapper GetWrapper(ExhibitionState exhibitionState)
        {
            return ExhibitionStates[(int) exhibitionState];
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
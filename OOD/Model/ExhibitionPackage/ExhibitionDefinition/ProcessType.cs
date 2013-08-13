#region



#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionDefinition
{
    public enum ProcessType

    {
        BoothAssignment,
        BoothCreation,
        BoothInspection,
        BoothJudge,
        CustommerRequest,
        DataGathering,
        ExhibitionProgress,
        Payment,
        Poll,
        PostKeeping,
        PrivateInforming,
        PublicInforming,
        ReConfiguration,
        RequestForBooth,
        SaloonCrud,
        VisitorReport,
        Waiting,
        WareHouseKeeping
    }

    public class ProcessTypeWrapper
    {
        public static ProcessTypeWrapper[] ProcessTypes =
        {
            new ProcessTypeWrapper(ProcessType.BoothAssignment, "تخصیص غرفه"),
            new ProcessTypeWrapper(ProcessType.BoothCreation, "ساخت غرفه"),
            new ProcessTypeWrapper(ProcessType.BoothInspection, "بازرسی غرفه"),
            new ProcessTypeWrapper(ProcessType.BoothJudge, "قضاوت غرفه"),
            new ProcessTypeWrapper(ProcessType.CustommerRequest, "درخواست مشتری"),
            new ProcessTypeWrapper(ProcessType.DataGathering, "ورودی دهی"),
            new ProcessTypeWrapper(ProcessType.ExhibitionProgress, "اجرای نمایشگاه"),
            new ProcessTypeWrapper(ProcessType.Payment, "امور مالی"),
            new ProcessTypeWrapper(ProcessType.Poll, "نظرسنجی"),
            new ProcessTypeWrapper(ProcessType.PostKeeping, "پست داری"),
            new ProcessTypeWrapper(ProcessType.PrivateInforming, "اطلاع رسانی خصوصی"),
            new ProcessTypeWrapper(ProcessType.PublicInforming, "اطلاع رسانی عمومی"),
            new ProcessTypeWrapper(ProcessType.ReConfiguration, "بازپیکربندی"),
            new ProcessTypeWrapper(ProcessType.RequestForBooth, "درخواست غرفه"),
            new ProcessTypeWrapper(ProcessType.SaloonCrud, "عملیات کراد سالن"),
            new ProcessTypeWrapper(ProcessType.VisitorReport, "گزارش بازدیدکنندگان"),
            new ProcessTypeWrapper(ProcessType.Waiting, "انتظار"),
            new ProcessTypeWrapper(ProcessType.WareHouseKeeping, "انبار داری")
        };


        private ProcessTypeWrapper(ProcessType processType, string name)
        {
            Name = name;
            ProcessType = processType;
        }

        private string Name { get; set; }
        public ProcessType ProcessType { get; set; }

        public static ProcessTypeWrapper GetWrapper(ProcessType type)
        {
            return ProcessTypes[(int) type];
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
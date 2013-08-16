namespace OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage
{
    public enum ProcessType

    {
        BoothAssignment,
        BoothConstruction,
        BoothInspection,
        BoothJudge,
        CustommerRequest,
        DataGathering, // Justify Place
        ExhibitionProgress,
        ExhibitionRegistration,
        Informing,
        Payment,
        Poll,
        PostKeeping,
        ReConfiguration, // We Don't have
        RequestForBooth,
        SaloonCrud,
        VisitorReport, // We Don't have
        Waiting, // We have
        WareHouseKeeping
    }

    public class ProcessTypeWrapper
    {
        public static ProcessTypeWrapper[] ProcessTypes =
        {
            new ProcessTypeWrapper(ProcessType.BoothAssignment, "تخصیص غرفه/سالن"),
            new ProcessTypeWrapper(ProcessType.BoothConstruction, "ساخت غرفه"),
            new ProcessTypeWrapper(ProcessType.BoothInspection, "بازرسی غرفه"),
            new ProcessTypeWrapper(ProcessType.BoothJudge, "قضاوت غرفه"),
            new ProcessTypeWrapper(ProcessType.CustommerRequest, "درخواست مشتری"),
            new ProcessTypeWrapper(ProcessType.DataGathering, "ورودی دهی"),
            new ProcessTypeWrapper(ProcessType.ExhibitionProgress, "اجرای نمایشگاه"),
            new ProcessTypeWrapper(ProcessType.ExhibitionRegistration, "ثبت نام در نمایشگاه"),
            new ProcessTypeWrapper(ProcessType.Informing, "اطلاع رسانی خصوصی/عمومی"),
            new ProcessTypeWrapper(ProcessType.Payment, "امور مالی"),
            new ProcessTypeWrapper(ProcessType.Poll, "نظرسنجی"),
            new ProcessTypeWrapper(ProcessType.PostKeeping, "پست داری"),
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
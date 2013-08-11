namespace OOD.Model.ExhibitionPackage.ExhibitionDefinition
{
    public enum ProcessType
    {
        BoothInspection,
        BoothJudge,
        PrivateInforming,
        PublicInforming,
        Poll,
        WareHouseKeeping,
        Payment,
        RequestForBooth,
        BoothAssignment,
        SaloonCrud,
        PostKeeping,
        VisitorReport,
        BoothCreation,
        Waiting,
        ReConfiguration,
        DataGathering,
        CustommerRequest,
        ExhibitionProgress
    }

    public static class ProcessTypeExtension
    {
        public static string ToFriendlyString(this ProcessType processType)
        {
            switch (processType)
            {
                case ProcessType.BoothInspection:
                    return "بازرسی غرفه";
                case ProcessType.BoothAssignment:
                    return "تخصیص غرفه";
                case ProcessType.BoothCreation:
                    return "ساخت غرفه";
                case ProcessType.BoothJudge:
                    return "قضاوت غرفه";
                case ProcessType.CustommerRequest:
                    return "درخواست مشتری";
                case ProcessType.DataGathering:
                    return "ورودی دهی";
                case ProcessType.ExhibitionProgress:
                    return "اجرای نمایشگاه";
                case ProcessType.Payment:
                    return "امور مالی";
                case ProcessType.Poll:
                    return "نظرسنجی";
                case ProcessType.PostKeeping:
                    return "پست داری";
                case ProcessType.PrivateInforming:
                    return "اطلاع رسانی خصوصی";
                case ProcessType.PublicInforming:
                    return "اطلاع رسانی عمومی";
                case ProcessType.ReConfiguration:
                    return "بازپیکربندی";
                case ProcessType.RequestForBooth:
                    return "درخواست غرفه";
                case ProcessType.SaloonCrud:
                    return "عملیات کراد سالن";
                default:
                    return "";
            }
        }
    }
}
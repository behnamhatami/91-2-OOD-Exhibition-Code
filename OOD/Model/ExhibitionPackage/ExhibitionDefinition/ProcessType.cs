#region

using System.ComponentModel.DataAnnotations;
using System.Linq;
using OOD.Model.ModelContext;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionDefinition
{
    public class ProcessType
    {
        public static ProcessType
            BoothAssignment = new ProcessType("تخصیص غرفه"),
            BoothCreation = new ProcessType("ساخت غرفه"),
            BoothInspection = new ProcessType("بازرسی غرفه"),
            BoothJudge = new ProcessType("قضاوت غرفه"),
            CustommerRequest = new ProcessType("درخواست مشتری"),
            DataGathering = new ProcessType("ورودی دهی"),
            ExhibitionProgress = new ProcessType("اجرای نمایشگاه"),
            Payment = new ProcessType("امور مالی"),
            Poll = new ProcessType("نظرسنجی"),
            PostKeeping = new ProcessType("پست داری"),
            PrivateInforming = new ProcessType("اطلاع رسانی خصوصی"),
            PublicInforming = new ProcessType("اطلاع رسانی عمومی"),
            ReConfiguration = new ProcessType("بازپیکربندی"),
            RequestForBooth = new ProcessType("درخواست غرفه"),
            SaloonCrud = new ProcessType("عملیات کراد سالن"),
            VisitorReport = new ProcessType("گزارش بازدیدکنندگان"),
            Waiting = new ProcessType("انتظار"),
            WareHouseKeeping = new ProcessType("انبار داری");


        public ProcessType()
        {
        }

        public ProcessType(string name)
        {
            Name = name;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public static void SyncWithDB()
        {
            var context = DataManager.DataContext.ProcessTypes;
            BoothAssignment = context.First(type => type.Name == "تخصیص غرفه");
            BoothCreation = context.First(type => type.Name == "ساخت غرفه");
            BoothInspection = context.First(type => type.Name == "بازرسی غرفه");
            BoothJudge = context.First(type => type.Name == "قضاوت غرفه");
            CustommerRequest = context.First(type => type.Name == "درخواست مشتری");
            DataGathering = context.First(type => type.Name == "ورودی دهی");
            ExhibitionProgress = context.First(type => type.Name == "اجرای نمایشگاه");
            Payment = context.First(type => type.Name == "امور مالی");
            Poll = context.First(type => type.Name == "نظرسنجی");
            PostKeeping = context.First(type => type.Name == "پست داری");
            PrivateInforming = context.First(type => type.Name == "اطلاع رسانی خصوصی");
            PublicInforming = context.First(type => type.Name == "اطلاع رسانی عمومی");
            ReConfiguration = context.First(type => type.Name == "بازپیکربندی");
            RequestForBooth = context.First(type => type.Name == "درخواست غرفه");
            SaloonCrud = context.First(type => type.Name == "عملیات کراد سالن");
            VisitorReport = context.First(type => type.Name == "گزارش بازدیدکنندگان");
            Waiting = context.First(type => type.Name == "انتظار");
            WareHouseKeeping = context.First(type => type.Name == "انبار داری");
        }

        public static ProcessType[] GetAllTypes()
        {
            return new[]
            {
                BoothAssignment, BoothCreation, BoothInspection, BoothJudge, CustommerRequest, DataGathering,
                ExhibitionProgress, Payment, Poll, PostKeeping, PrivateInforming, PublicInforming, ReConfiguration,
                RequestForBooth, SaloonCrud, VisitorReport, Waiting, WareHouseKeeping
            };
        }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var processType = obj as ProcessType;
            if (processType == null || processType.Id != Id)
                return false;
            return true;
        }
    }
}
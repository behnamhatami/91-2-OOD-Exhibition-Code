#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionProgressPackage.ExhibitionRequestPackage;
using OOD.Model.ModelContext;
using OOD.Model.NotificationPackage;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage
{
    public class Process
    {
        public int Id { get; set; }
        public ProcessType Type { get; set; }
        public int MinLength { get; set; }
        public int MaxLength { get; internal set; }
        public int StartNode { get; set; }
        public int FinishNode { get; set; }
        public bool Started { get; set; }
        public bool Finished { get; set; }
        public bool IsMileStone { get; set; }
        public string MileStoneMessage { get; set; }
        public DateTime StartDate { get; set; }

        public virtual Configuration Configuration { get; set; }

        [NotMapped]
        public List<Process> PreProcesses { get; set; }

        public Process Clone(Configuration newConfiguration)
        {
            return new Process
            {
                Configuration = newConfiguration,
                Type = Type,
                MinLength = MinLength,
                MaxLength = MaxLength,
                StartNode = StartNode,
                FinishNode = FinishNode,
                Started = Started,
                Finished = Finished,
                StartDate = StartDate,
                IsMileStone = IsMileStone,
                MileStoneMessage = MileStoneMessage
            };
        }

        public bool AnyFinishProblem()
        {
            if (!(DateTimeManager.Today > StartDate.AddDays(MinLength)))
                return true;

            var exhibition = Configuration.Exhibition;
            switch (Type)
            {
                case ProcessType.BoothAssignment:
                    return exhibition.GetSpecialRequests<BoothRequest>()
                        .Any(request => request.NotMentioned())
                           ||
                           exhibition.GetSpecialRequests<SaloonRequest>()
                               .Any(request => request.NotMentioned());

                case ProcessType.BoothConstruction:
                    return DataManager.DataContext.ProfessionAssignments
                        .Where(assignment => assignment.Request.Exhibition.Id == exhibition.Id)
                        .Any(assignment => assignment.Constructor == null || !assignment.Done);

                case ProcessType.BoothInspection:
                    return exhibition.GetSpecialRequests<InspectionRequest>()
                        .Any(request => !request.Responsed);

                case ProcessType.BoothJudge:
                    return exhibition.GetSpecialRequests<InspectionRequest>()
                        .Any(request => request.Responsed && !request.Agreed);

                case ProcessType.CustommerRequest:
                    return exhibition.GetSpecialRequests<BoothExtensionRequest>()
                        .Any(request => request.IsCustomerRequest && request.NotMentioned())
                           || exhibition.GetSpecialRequests<ExhibitionRequest>()
                               .Where(request => request.RequestType == ExhibitionRequestType.Exit)
                               .Any(request => request.NotMentioned())
                           || exhibition.GetSpecialRequests<PollRequest>()
                               .Any(request => request.NotMentioned());

                case ProcessType.ExhibitionRegistration:
                    return exhibition.GetSpecialRequests<ExhibitionRequest>()
                        .Where(request => request.RequestType == ExhibitionRequestType.Entrance)
                        .Any(request => request.NotMentioned());

                case ProcessType.Poll:
                    return exhibition.Polls.Any(poll => poll.Started && !poll.Closed);

                default:
                    return false;
            }
        }

        public void ForceFinsih()
        {
            Finished = true;
            var db = DataManager.DataContext;
            if (IsMileStone)
            {
                db.Notifications.Add(new Notification
                {
                    Content = MileStoneMessage,
                    CreationDate = DateTimeManager.SystemNow,
                    Exhibition = Configuration.Exhibition,
                    Title = "نمایشگاه به نقطی عطف جدیدی رسید",
                    User = Program.System
                });
            }
            db.SaveChanges();
        }

        public void Start()
        {
            Started = true;
            StartDate = DateTimeManager.Today;
            DataManager.DataContext.SaveChanges();
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
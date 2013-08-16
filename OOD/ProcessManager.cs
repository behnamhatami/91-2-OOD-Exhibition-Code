#region

using System.Collections.Generic;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;
using OOD.Model.ModelContext;

#endregion

namespace OOD
{
    public class ProcessManager
    {
        private readonly IQueryable<Process> _processes;

        public ProcessManager(Exhibition exhibition)
        {
            _processes = exhibition.Configuration.Processes;
            foreach (var process in _processes)
            {
                process.PreProcesses = new List<Process>();
                foreach (var process1 in _processes)
                    if (process1.FinishNode == process.StartNode)
                        process.PreProcesses.Add(process1);
            }
            DoDayWork();
        }

        public void Tomorrow()
        {
            Program.Exhibition.ExhibitionDateTime = Program.Exhibition.ExhibitionDateTime.AddDays(1);
            DataManager.DataContext.SaveChanges();
            DoDayWork();
        }

        public void DoDayWork()
        {
            foreach (var process in ToBeFinsihed())
                process.ForceFinsih();

            foreach (var process in ToBeStarted())
                process.Start();
        }

        public bool IsProcessRunning(ProcessType processType)
        {
            return RunningProcesses().Any(process => process.Type == processType);
        }

        public IQueryable<Process> RunningProcesses()
        {
            return _processes.Where(process => process.Started && !process.Finished);
        }

        public IQueryable<Process> ToBeFinsihed()
        {
            var today = DateTimeManager.Today;
            return RunningProcesses().Where(process => process.StartDate.AddDays(process.MaxLength) < today);
        }

        public IQueryable<Process> CanBeFinished()
        {
            var today = DateTimeManager.Today;
            return RunningProcesses().Where(process => process.StartDate.AddDays(process.MinLength) < today);
        }

        public IQueryable<Process> ToBeStarted()
        {
            return _processes.Where(process => process.PreProcesses.All(process1 => process1.Finished));
        }
    }
}
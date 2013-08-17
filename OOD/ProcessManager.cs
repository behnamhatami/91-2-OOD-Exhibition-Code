#region

using System.Collections.Generic;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinitionPackage;

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
        }

        public void DoDayWork()
        {
            foreach (var process in ToBeFinsihed())
                process.ForceFinsih();

            foreach (var process in ToBeStarted())
                process.Start();

            foreach (var process in RunningProcesses())
                process.Run();
        }

        public bool IsProcessRunning(ProcessType processType)
        {
            return RunningProcesses().Any(process => process.Type == processType);
        }

        public IQueryable<Process> RunningProcesses()
        {
            return _processes.Where(process => process.Started && !process.Finished);
        }

        public List<Process> ToBeFinsihed()
        {
            var today = DateTimeManager.Today;
            return
                RunningProcesses()
                    .ToList()
                    .Where(process => process.StartDate.AddDays(process.MaxLength) <= today)
                    .ToList();
        }

        public List<Process> ToBeStarted()
        {
            return
                _processes.Where(process => !process.Started).ToList().Where(process => process.PreProcesses.All(process1 => process1.Finished)).ToList();
        }

        public IQueryable<Process> RemainingProcesses()
        {
            return _processes.Where(process => !process.Finished);
        }

        public IQueryable<Process> FinsihedProcesses()
        {
            return _processes.Where(process => process.Finished);
        }
    }
}
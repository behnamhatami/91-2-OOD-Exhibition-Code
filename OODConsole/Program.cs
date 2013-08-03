#region

using System;
using System.Linq;
using OOD.Model.ExhibitionPackage.ExhibitionDefinition;
using OOD.Model.ModelContext;

#endregion

namespace OODConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var db = DataManager.DataContext;
            var conf = new Configuration
            {
                Id = 20
            };

            var process = new Process();
            db.Processes.Add(process);
            db.SaveChanges();
            conf.Processes.Add(process);
            Console.WriteLine(conf.Processes.Count);
            db.SaveChanges();

            process = new Process();
            db.Processes.Add(process);
            db.SaveChanges();
            conf.Processes.Add(process);
            Console.WriteLine(conf.Processes.Count);
            db.SaveChanges();

            process = new Process();
            db.Processes.Add(process);
            db.SaveChanges();
            conf.Processes.Add(process);
            Console.WriteLine(conf.Processes.Count);
            db.SaveChanges();

            process = new Process();
            db.Processes.Add(process);
            db.SaveChanges();
            conf.Processes.Add(process);
            Console.WriteLine(conf.Processes.Count);
            db.SaveChanges();

            conf.Processes.Remove(new Process {Id = conf.Processes.ElementAt(0).Id});
            Console.WriteLine(conf.Processes.Count);
            conf.Processes.Remove(new Process {Id = conf.Processes.ElementAt(1).Id});
            Console.WriteLine(conf.Processes.Count);
            conf.Processes.Remove(new Process {Id = conf.Processes.ElementAt(2).Id});
            Console.WriteLine(conf.Processes.Count);
            Console.ReadKey();
        }
    }
}
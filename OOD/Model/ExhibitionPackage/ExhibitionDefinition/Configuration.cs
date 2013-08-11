#region

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OOD.Model.ModelContext;

#endregion

namespace OOD.Model.ExhibitionPackage.ExhibitionDefinition
{
    public class Configuration
    {
        [Key, ForeignKey("Exhibition")]
        public int Id { get; set; }

        public virtual Exhibition Exhibition { get; set; }

        [NotMapped]
        public IQueryable<Process> Processes
        {
            get { return DataManager.DataContext.Processes.Where(process => process.Configuration.Id == Id); }
        }

        public void Reset()
        {
            foreach (var process in Processes)
                DataManager.DataContext.Processes.Remove(process);
        }

        public void AddFromConfiguration(Configuration configuration)
        {
            foreach (var process in configuration.Processes)
                DataManager.DataContext.Processes.Add(process.Clone(this));
        }

        public override string ToString()
        {
            return Id + "";
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var config = obj as Configuration;
            if (config == null || config.Id != Id)
                return false;
            return true;
        }
    }
}
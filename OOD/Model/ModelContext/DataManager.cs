#region

using System.Data.Entity;
using System.Data.Entity.Infrastructure;

#endregion

namespace OOD.Model.ModelContext
{
    public class DataManager
    {
        private static OodContext _dataContext;

        public static OodContext DataContext
        {
            get
            {
                if (_dataContext != null) return _dataContext;

                Database.DefaultConnectionFactory = new SqlCeConnectionFactory("System.Data.SqlServerCe.4.0");
                _dataContext = new OodContext();
                var dbExists = _dataContext.Database.Exists();
                if (dbExists)
                {
                    //UpgradeScript();
                }

                if (!dbExists)
                    Database.SetInitializer(new DatabaseInitializer());
                else
                    Database.SetInitializer<OodContext>(null);
                return _dataContext;
            }
        }
    }
}
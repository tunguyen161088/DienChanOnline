using System.Configuration;
using PetaPoco;

namespace DienChanOnline.DAL
{
    public interface IQueryBase
    {
        Database Db();
    }

    public class QueryBase: IQueryBase
    {
        private readonly Database _db;

        public QueryBase()
        {
            _db = new Database(ConfigurationManager.AppSettings["ConnectionString"], "System.Data.SqlClient");
        }

        public Database Db()
        {
            return _db;
        }
    }
}
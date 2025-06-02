
using AppTempoAgoraSQLite.Models;
using AppTempoAgoraSQLite.Models;
using SQLite;

namespace AppTempoAgoraSQLite.Helpers
{
    public class SQliteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;

        public SQliteDatabaseHelper(string path)
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Tempo>().Wait();
        }

        public Task<int> Insert(Tempo p)
        {
            return _conn.InsertAsync(p);
        }

        public Task<int> Delete(int id)
        {
            return _conn.Table<Tempo>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Tempo>> GetAll()
        {
            return _conn.Table<Tempo>().OrderByDescending(i => i.Id).ToListAsync();
        }

        public Task<List<Tempo>> Search(string q)
        {
            string sql = "SELECT * FROM Tempo " +
                         "WHERE Cidade LIKE '%" + q + "%'";

            return _conn.QueryAsync<Tempo>(sql);
        }
    } 
}

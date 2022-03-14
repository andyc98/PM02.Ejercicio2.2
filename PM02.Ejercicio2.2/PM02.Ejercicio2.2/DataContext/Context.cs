using PM02.Ejercicio2._2.Features;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PM02.Ejercicio2._2.DataContext
{
    public class Context
    {
        readonly SQLiteAsyncConnection db;

        public Context(String pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);

            db.CreateTableAsync<Firmas>().Wait();
        }

        public Task<List<Firmas>> GetListFirmas()
        {
            return db.Table<Firmas>().ToListAsync();
        }

        public Task<Firmas> GetFirmaPorId(int signatureCode)
        {
            return db.Table<Firmas>()
                .Where(i => i.id == signatureCode)
                .FirstOrDefaultAsync();
        }

        public Task<int> guardarfirma(Firmas firmas)
        {
            return firmas.id != 0 ? db.UpdateAsync(firmas) : db.InsertAsync(firmas);
        }

    }
}

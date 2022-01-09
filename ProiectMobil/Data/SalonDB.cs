using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProiectMobil.Models;

namespace ProiectMobil.Data
{
    public class SalonDB
    {
        readonly SQLiteAsyncConnection _database;
        public SalonDB(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Programari>().Wait();
            _database.CreateTableAsync<Angajati>().Wait();
        }

        public Task<List<Programari>> GetProgramariAsync()
        {
            return _database.Table<Programari>().ToListAsync();
        }

        public Task<int> DeleteProgramariAsync(Programari plist)
        {
            return _database.DeleteAsync(plist);
        }

        public Task<Programari> GetProgramareAsync(int id)
        {
            return _database.Table<Programari>()
            .Where(i => i.Id_programare == id)
           .FirstOrDefaultAsync();
        }

        public Task<int> SaveProgramareAsync(Programari prog)
        {
            if (prog.Id_programare != 0)
            {
                return _database.UpdateAsync(prog);
            }
            else
            {
                return _database.InsertAsync(prog);
            }
        }
        public Task<int> DeleteProgramareAsync(Programari prog)
        {
            return _database.DeleteAsync(prog);
        }
        public Task<List<Programari>> GetProductsAsync()
        {
            return _database.Table<Programari>().ToListAsync();
        }

        public Task<List<Angajati>> GetAngAsync()
        {
            return _database.Table<Angajati>().ToListAsync();
        }


        public Task<Angajati> GetAngAsync(int id)
        {
            return _database.Table<Angajati>()
            .Where(i => i.AngajatiId == id)
           .FirstOrDefaultAsync();
        }

        public Task<int> SaveAngAsync(Angajati prog)
        {
            if (prog.AngajatiId != 0)
            {
                return _database.UpdateAsync(prog);
            }
            else
            {
                return _database.InsertAsync(prog);
            }
        }
        public Task<int> DeleteAngAsync(Angajati prog)
        {
            return _database.DeleteAsync(prog);
        }
        public Task<List<Angajati>> GetAngsAsync()
        {
            return _database.Table<Angajati>().ToListAsync();
        }
    }
}



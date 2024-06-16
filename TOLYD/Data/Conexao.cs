using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using TOLYD.Classes;

namespace TOLYD.Data
{
    public class Conexao
    {
        private readonly SQLiteAsyncConnection _database;

        public Conexao(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Animal>().Wait();
            _database.CreateTableAsync<Captura>().Wait();
            _database.CreateTableAsync<Anestesia>().Wait();
            _database.CreateTableAsync<Anestesia2>().Wait();
            _database.CreateTableAsync<Biometria>().Wait();
        }

        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<User> GetUserAsync(string username)
        {
            return _database.Table<User>().Where(i => i.Username == username).FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.ID != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }

        public Task<int> SaveAnimalAsync(Animal animal)
        {
            return _database.InsertAsync(animal);
        }

        public Task<int> SaveCapturaAsync(Captura captura)
        {
            return _database.InsertAsync(captura);
        }

        public Task<Animal> GetAnimalByIdAsync(int IdAnimal)
        {
            return _database.Table<Animal>().FirstOrDefaultAsync(a => a.IdAnimal == IdAnimal);
        }

        public Task<Captura> GetCapturaByAnimalIdAsync(int Id)
        {
            return _database.Table<Captura>().FirstOrDefaultAsync(c => c.Id == Id);
        }

        public Task<List<Animal>> GetAnimalsAsync()
        {
            return _database.Table<Animal>().ToListAsync();
        }

        public async Task<int> GetNextAnimalIdAsync()
        {
            var lastAnimal = await _database.Table<Animal>().OrderByDescending(a => a.IdAnimal).FirstOrDefaultAsync();
            int nextId = (lastAnimal != null) ? lastAnimal.IdAnimal + 1 : 1; // Se não houver registros, começa com 1

            return nextId;
        }

        public Task<int> SaveAnestesiaAsync(Anestesia anestesia)
        {
            return _database.InsertAsync(anestesia);
        }

        public Task<int> SaveAnestesia2Async(Anestesia2 anestesia2)
        {
            return _database.InsertAsync(anestesia2);
        }

        public Task<int> SaveBiometriaAsync(Biometria biometria)
        {
            return _database.InsertAsync(biometria);
        }
    }
}

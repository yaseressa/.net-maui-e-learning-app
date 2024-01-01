using Baro.Models;
using SQLite;


namespace Baro.Database
{
    //public class Baro_Db
    //{
    //    SQLiteAsyncConnection Database;
    //    public Baro_Db()
    //    {
    //    }
    //    async Task Init()
    //    {
    //        if (Database is not null)
    //            return;

    //        Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
    //        var result = await Database.CreateTableAsync<User>();
    //    }

    //    public async Task<List<User>> GetItemsAsync()
    //    {
    //        await Init();
    //        return await Database.Table<User>().ToListAsync();
    //    }

    //    public async Task<User> Login(string email, string password)
    //    {
    //        await Init();
    //        var log = await Database.Table<User>().Where(i => i.Email == email && i.Password == password).FirstOrDefaultAsync();
    //        return log;
    //    }
    //    public async Task<User> GetUserAsync(int id)
    //    {
    //        await Init();
    //        return await Database.Table<User>().Where(i => i.Id == id).FirstOrDefaultAsync();
    //    }

    //    public async Task<int> SaveUserAsync(User user)
    //    {
    //        await Init();
    //        if (user.Id != 0)
    //        {
    //            return await Database.UpdateAsync(user);
    //        }
    //        else
    //        {
    //            return await Database.InsertAsync(user);
    //        }
    //    }

    //    public async Task<int> DeleteUserAsync(int id)
    //    {
    //        await Init();
    //        return await Database.Table<User>().Where(i => i.Id == id).DeleteAsync();
    //    }

    //}
}

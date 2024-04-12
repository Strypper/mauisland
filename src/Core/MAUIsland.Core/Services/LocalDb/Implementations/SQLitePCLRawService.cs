using SQLite;

namespace MAUIsland.Core;

public class SQLitePCLRawService<T> : ILocalDbService<T> where T : BaseLocalEntity, new()
{
    private const string DbName = "mauisland.db";
    private readonly SQLiteAsyncConnection _connection;

    public SQLitePCLRawService()
    {
        _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DbName));
        _connection.CreateTableAsync<T>().Wait();
    }

    public async Task AddAsync(T entity)
    {
        await _connection.InsertAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _connection.InsertAllAsync(entities);
    }

    public async Task DeleteAsync(T entity)
    {
        await _connection.DeleteAsync(entity);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _connection.Table<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _connection.Table<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        await _connection.UpdateAsync(entity);
    }
}

namespace MAUIsland.Features.LocalDbFeatures;

public class SQLitePCLRawService<T> : ILocalDbService<T> where T : BaseLocalEntity, new()
{
    private readonly SQLiteAsyncConnection _connection;

    public SQLitePCLRawService(DatabaseSettings databaseSettings)
    {
        _connection = new SQLiteAsyncConnection(databaseSettings.DatabasePath);
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

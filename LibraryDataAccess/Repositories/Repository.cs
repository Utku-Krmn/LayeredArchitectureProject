
using LibraryDataAccess.Repositories;
using LibraryDataAccess;
using Microsoft.EntityFrameworkCore;
public class Repository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{

public Repository(DatabaseConnection dbContext)
{
    _dbContext = dbContext;
    _dbSet = _dbContext.Set<TEntity>(); // Initialize the DbSet for the specific entity type TEntity using the DbContext. This allows us to perform CRUD operations on the corresponding databasetable.
}
    protected readonly DatabaseConnection _dbContext;
    private readonly DbSet<TEntity> _dbSet; 
    public void Create(TEntity entity)
    {
        _dbSet.Add(entity); // Add the entity to the DbSet, which marks it for insertion into the database when SaveChanges is called on the DbContext.
        _dbContext.SaveChanges(); // Save the changes to the database immediately after adding the entity. This ensures that the new entity is persisted in the database.
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity); // Remove the entity from the DbSet, which marks it for deletion from the database when SaveChanges is called on the DbContext.
        _dbContext.SaveChanges(); // Save the changes to the database immediately after removing the entity. This ensures that the deletion is persisted in the database.
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity); // Asynchronously add the entity to the DbSet, which marks it for insertion into the database when SaveChanges is called on the DbContext.
    }

    public IQueryable<TEntity> GetAll()
    {
        return _dbSet.AsNoTracking(); // Return all entities from the DbSet as an IQueryable collection. AsNoTracking is used to improve performance by not tracking changes to the entities in the DbContext.
    }

    

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity); // Update the entity in the DbSet, which marks it for modification in the database when SaveChanges is called on the DbContext.
        _dbContext.SaveChanges(); 
    }

    public void DeletebyRange(List<TEntity> entities)
    {
        _dbSet.RemoveRange(entities); // Remove a range of entities from the DbSet, which marks them for deletion from the database when SaveChanges is called on the DbContext.
        _dbContext.SaveChanges(); 
    }


    public async Task<TEntity?> GetByIdAsync(int id) // Asynchronously retrieve an entity by its primary key (id) from the DbSet. If the entity is found, it is returned; otherwise, null is returned.
    {
        return await _dbSet.FindAsync(id);
    }

    public IQueryable<TEntity> Queryable()
    {
        return _dbSet.AsQueryable(); // Return the entities from the DbSet as an IQueryable collection, allowing for further querying and filtering before execution.
    }

}
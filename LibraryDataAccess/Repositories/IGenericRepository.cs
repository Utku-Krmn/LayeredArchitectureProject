
namespace LibraryDataAccess.Repositories
{   
public interface IGenericRepository<TEntity> where TEntity : class
{
    #region CRUD
    void Create(TEntity entity); // Create operation for adding a new entity to the database.

    Task AddAsync(TEntity entity); // Asynchronous version of the Create operation for adding a new entity to the database.

    IQueryable<TEntity> GetAll(); // Read operation for retrieving all entities from the database as an IQueryable collection.

    void Update(TEntity entity); // Update operation for modifying an existing entity in the database.

    void Delete(TEntity entity); // Delete operation for removing an entity from the database.

    Task<TEntity?> GetByIdAsync(int id); // Asynchronous version of the GetById operation for retrieving a specific entity by its unique identifier (ID) from the database.

    void DeletebyRange(List<TEntity> entities); // Delete operation for removing a range of entities from the database.

    IQueryable<TEntity> Queryable(); // Method for retrieving entities as an IQueryable collection, allowing for further querying and filtering before execution.
    
    #endregion
}

}
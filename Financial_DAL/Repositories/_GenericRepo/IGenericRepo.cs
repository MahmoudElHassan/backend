namespace Financial_DAL;

public interface IGenericRepo<TEntity> where TEntity : class
{
    List<TEntity> GetAll();
    TEntity? GetById(Guid id);
    TEntity? GetByintId(int id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void DeleteById(Guid id);
    void DeleteByintId(int id);

    void SaveChanges();

}

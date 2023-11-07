using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Financial_DAL;

public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
{
    #region Field
    private readonly ApplicationDbContext _context;
    #endregion

    #region Ctor
    public GenericRepo(ApplicationDbContext context)
    {
        _context = context;
    }
    #endregion

    #region Method
    public List<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    public TEntity GetById(Guid id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public TEntity GetByintId(int id)
    {
        return _context.Set<TEntity>().Find(id);
    }

    public void Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }

    public void DeleteById(Guid id)
    {
        var entityToDelete = GetById(id);
        if (entityToDelete is not null)
        {
            _context.Set<TEntity>().Remove(entityToDelete);
        }
    }

    public void DeleteByintId(int id)
    {
        var entityToDelete = GetByintId(id);
        if (entityToDelete is not null)
        {
            _context.Set<TEntity>().Remove(entityToDelete);
        }
    }


    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    #endregion

}

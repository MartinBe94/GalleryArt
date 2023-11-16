using System.Linq.Expressions;

namespace Data.Interface;

public interface IDbService
{
    public Task<List<TDto>> GetAsync<TEntity, TDto>()
           where TEntity : class, IEntity
           where TDto : class;

    public Task<TDto> GetByIdAsync<TEntity, TDto>
        (Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity
        where TDto : class;

    public Task<List<TDto>> GetManyByExp<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity
        where TDto : class;

    public Task<bool> GetExpressionAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
   where TEntity : class, IEntity;
    Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
        where TEntity : class
        where TDto : class;

    public Task<TEntity> PostManytoManyAsync<TEntity, TDto>(TDto dto)
               where TEntity : class
        where TDto : class;
    public Task<List<TEntity>> PostListAsync<TEntity, TDto>(List<TDto> dtoList)
     where TEntity : class
            where TDto : class;
    public Task<bool> SaveChangesAsync();

    public void Update<TEntity, TDto>(int id, TDto dto)
           where TEntity : class, IEntity
           where TDto : class;

    public Task<bool> DeleteAsync<TEntity>(int Id)
        where TEntity : class, IEntity;
    bool Delete<TReferenceEntity, TDto>(TDto dto) where TReferenceEntity : class where TDto : class;
    string GetURI<TEntity>(TEntity entity) where TEntity : class, IEntity;
    string GetListURI<TEntity>(List<TEntity> entity);
}

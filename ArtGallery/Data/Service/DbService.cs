using AutoMapper;
using Data.Interface;
using System.Linq.Expressions;

namespace Data.Service;

public class DbService : IDbService
{
    private readonly ArtGalleryContext _context;
    private readonly IMapper _mapper;
    public DbService(ArtGalleryContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    async Task<List<TDto>> IDbService.GetAsync<TEntity, TDto>()
    {
        var entities = await _context.Set<TEntity>().ToListAsync();
        return _mapper.Map<List<TDto>>(entities);
    }

    async Task<TDto> IDbService.GetByIdAsync<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
    {
        var entity = _context.Set<TEntity>().SingleOrDefaultAsync(expression);
        if (entity == null) return null;

        var Dto = _mapper.Map<TDto>(entity);
        return Dto;
    }

    public async Task<bool> GetExpressionAsync<TEntity>(Expression<Func<TEntity, bool>> expression)
        where TEntity : class, IEntity =>
            await _context.Set<TEntity>().AnyAsync(expression);



    public async Task<TEntity> AddAsync<TEntity, TDto>(TDto dto)
    where TEntity : class/*, IEntity*/
    where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    //async Task<TEntity> IDbService.PostAsync<TEntity, TDto>(TDto dto)
    //{
    //    try
    //    {
    //        var entity = _mapper.Map<TEntity>(dto);

    //        _ = _context.Set<TEntity>().Add(entity);
    //        return entity;
    //    }
    //    catch (Exception)
    //    {
    //        throw;
    //    }
    //}

    async Task<TEntity> IDbService.PostManytoManyAsync<TEntity, TDto>(TDto dto)
      where TEntity : class
    where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _context.Set<TEntity>().AddAsync(entity);
        return entity;
    }


    async Task<List<TEntity>> IDbService.PostListAsync<TEntity, TDto>(List<TDto> dtoList)
    {
        List<TEntity> entitiesToInsert = dtoList.Select(dto => _mapper.Map<TDto, TEntity>(dto)).ToList();
        _context.AddRange(entitiesToInsert);
        await _context.SaveChangesAsync();
        return entitiesToInsert;

    }


    public async Task<bool> SaveChangesAsync()
    {
        int result = await _context.SaveChangesAsync();
        return result > 0;
    }

    public void Update<TEntity, TDto>(int id, TDto dto)
        where TEntity : class, IEntity
        where TDto : class
    {
        var entity = _mapper.Map<TEntity>(dto);
        entity.Id = id;
        _context.Set<TEntity>().Update(entity);
    }

    async Task<bool> IDbService.DeleteAsync<TEntity>(int Id)
    {
        try
        {
            var entity = await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == Id);
            if (entity == null) return false;

            _context.Set<TEntity>().Remove(entity);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Delete<TReferenceEntity, TDto>(TDto dto) where TReferenceEntity : class where TDto : class
    {
        try
        {
            var entity = _mapper.Map<TReferenceEntity>(dto);
            if (entity is null) return false;
            _context.Remove(entity);
        }
        catch { throw; }

        return true;
    }

    async Task<List<TDto>> IDbService.GetManyByExp<TEntity, TDto>(Expression<Func<TEntity, bool>> expression)
    {
        var queryable = _context.Set<TEntity>().AsQueryable();

        var entities = await queryable.Where(expression).ToListAsync();
        var dtoList = _mapper.Map<List<TDto>>(entities).ToList();

        return dtoList;
    }

    public string GetURI<TEntity>(TEntity entity) where TEntity : class, IEntity
=> $"/{typeof(TEntity).Name.ToLower()}s/{entity.Id}";
    public string GetListURI<TEntity>(List<TEntity> entity) =>
    $"/{typeof(TEntity).Name.ToLower()}" + $"s/{entity}";
}
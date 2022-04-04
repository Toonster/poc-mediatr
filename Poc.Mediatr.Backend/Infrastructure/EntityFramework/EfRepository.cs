using Domain.Common.Entities;
using Domain.Common.Repositories;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework;

internal abstract class EfRepository<TEntity> : IRepository<TEntity> where TEntity : RootEntity 
{
    private protected EfRepository(MediatrPocDbContext context)
    {
        Context = context;
    }
    
    private MediatrPocDbContext Context { get; }
    
    public async Task<RootEntity> GetByIdAsync(Guid id)
    {
        return await Context.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id) ??
               throw new NotFoundException($"{typeof(TEntity).Name} with id: {id} not found.");
    }

    public Task Create(TEntity entity)
    {
        return Context.Set<TEntity>().AddAsync(entity).AsTask();
    }
}
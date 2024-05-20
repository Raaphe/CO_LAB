// PAT Project - Sharp Coders

namespace PAT.Models.Repositories;
using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using Task = Task;

/// <summary>
/// Provides common generic data access methods for entities.
/// </summary>
/// <typeparam name="T">The type of the entities.</typeparam>
public class Repository<T> : IRepository<T>
    where T : BaseEntity
{
    private readonly AppDbContext context;
    private readonly DbSet<T> entities;

    /// <summary>
    /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
    /// </summary>
    /// <param name="context">The module database context.</param>
    public Repository(AppDbContext context)
    {
        this.context = context;
        this.entities = context.Set<T>();
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<T?>> GetAllAsync()
    {
        return await this.entities.ToListAsync();
    }

    /// <inheritdoc/>
    public IQueryable<T?> Get()
    {
        return this.entities;
    }

    /// <inheritdoc/>
    public async Task<T?> GetByIdAsync(int id, CancellationToken token = default)
    {
        return await this.entities.SingleOrDefaultAsync(e => e.Id == id, token);
    }

    /// <inheritdoc/>
    public async Task CreateAsync(T? entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }

        this.entities.Add(entity);
        await this.context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(T entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException("entity");
        }

        await this.context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public virtual async Task DeleteAsync(int id)
    {
        T? entity = this.entities.SingleOrDefault(e => e != null && e.Id == id);
        if (entity is null)
        {
            return;
        }

        this.entities.Remove(entity);
        await this.context.SaveChangesAsync();
    }
}
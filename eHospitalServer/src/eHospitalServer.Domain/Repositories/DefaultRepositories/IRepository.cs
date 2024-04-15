using System.Linq.Expressions;

namespace eHospitalServer.Domain.Repositories.DefaultRepositories;
public interface IRepository<T> where T : class
{
    IQueryable<T> GetAll();
    IQueryable<T> GetAllWithTacking();
    IQueryable<T> Where(Expression<Func<T, bool>> predicate);
    IQueryable<T> WhereWithTracking(Expression<Func<T, bool>> predicate);
    Task<T> GetByExpressionAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<T> GetByExpressionWithTrackingAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    Task<T> GetFirstAsync(CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    bool Any(Expression<Func<T, bool>> predicate);
    T GetByExpression(Expression<Func<T, bool>> predicate);
    T GetByExpressionWithTracking(Expression<Func<T, bool>> predicate);
    T GetFirst();
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    void Add(T entity);
    Task AddRangeAsync(ICollection<T> entities, CancellationToken cancellationToken = default);
    void Update(T entity);
    void UpdateRange(ICollection<T> entities);
    Task DeleteByIdAsync(string id);
    Task DeleteByExpressionAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
    void Delete(T entity);
    void DeleteRange(ICollection<T> entities);
}

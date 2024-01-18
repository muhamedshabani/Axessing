using Axessing.Models.Resource;

namespace Axessing.Services.UnitOfWork;

public interface IHelper<T> where T : class
{
    public T Get(int id);
    public List<T> GetAll(RequestParams requestParams);
    public void Create(T entity);
    public void Update(int id, T entity);
    public void Delete(int id);
    public int Save();
    public Task<int> SaveAsync();
}

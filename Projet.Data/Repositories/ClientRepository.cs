



public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(int id);
    void Save();
}

public class Repository<T> : IRepository<T> where T : class
{
    private readonly MyDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(MyDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public IEnumerable<T> GetAll() => _dbSet.ToList();
    public T GetById(int id) => _dbSet.Find(id);
    public void Add(T entity) { _dbSet.Add(entity); Save(); }
    public void Update(T entity) { _dbSet.Update(entity); Save(); }
    public void Delete(int id) { var entity = _dbSet.Find(id); if (entity != null) { _dbSet.Remove(entity); Save(); } }
        
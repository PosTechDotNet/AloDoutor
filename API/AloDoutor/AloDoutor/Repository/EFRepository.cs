using AloDoutor.Entity;
using AloDoutor.Interface;
using Microsoft.EntityFrameworkCore;

namespace AloDoutor.Repository;

public class EFRepository<T> : IRepository<T> where T : Entidade
{
    protected ApplicationDbContext _context;
    protected DbSet<T> _dbSet;

    public EFRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public void Alterar(T entity)
    {
        _dbSet.Update(entity);
        _context.SaveChanges();
    }
    public void Cadastrar(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
    }
    public void Deletar(int id)
    {
        _dbSet.Remove(ObterPorId(id));
        _context.SaveChanges();
    }
    public T ObterPorId(int id)
    {
        return _dbSet.FirstOrDefault(t => t.Id == id);
    }
    public IList<T> ObterTodos()
    {
        return _dbSet.ToList();
    }
    public IList<Medico> ObterTodosMedicos()
    {
        return _context.Medico
            .Include(e => e.Especialidade)
            .ToList();
    }
    public IList<Medico> ObterMedicoPorId(int id)
    {
        return (IList<Medico>)_dbSet.FirstOrDefault(t => t.Id == id);
    }
}

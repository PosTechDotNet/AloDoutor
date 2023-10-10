using AloDoutor.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AloDoutor.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entidade
    {
        void Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        void Atualizar(TEntity entity);
        void Remover(TEntity entity);
    //    Task<int> SaveChanges();
        IUnitOfWork UnitOfWork { get; }
    }
}

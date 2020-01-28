using System.Collections.Generic;
using System.Linq;

namespace WebApiTESTEBACKENDRosembergue.Common
{
    public class RepositorioBase<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        private readonly AcessoContexto _contexto;

        public RepositorioBase(AcessoContexto contexto)
        {
            _contexto = contexto;
        }

        public void Alterar(int ID, params TEntity[] obj)
        {
            _contexto.Set<TEntity>().UpdateRange(obj);
            _contexto.SaveChanges();
        }

        public void Excluir(int ID)
        {
            _contexto.Set<TEntity>().Remove(Selecionar(ID));
            _contexto.SaveChanges();
        }

        public void Incluir(params TEntity[] obj)
        {
            _contexto.Set<TEntity>().AddRange(obj);
            _contexto.SaveChanges();
        }

        public IList<TEntity> Listar()
        {
            return _contexto.Set<TEntity>().ToList();
        }

        public TEntity Selecionar(int Id)
        {
            return _contexto.Find<TEntity>(Id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTESTEBACKENDRosembergue.Common
{
    public interface IRepositorio<TEntity> where TEntity : class
    {
        IList<TEntity> Listar();
        TEntity Selecionar(int ID);
        void Incluir(params TEntity[] obj);
        void Alterar(int ID, params TEntity[] obj);
        void Excluir(int ID);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IteraDisc.Repositorio.Contexto;

namespace IteraDisc.Repositorio
{
    public abstract class BaseRepositorio
    {
        protected readonly IteraDiscContexto _contexto;

        protected BaseRepositorio(IteraDiscContexto contexto)
        {
            _contexto = contexto;
        }
    }
}
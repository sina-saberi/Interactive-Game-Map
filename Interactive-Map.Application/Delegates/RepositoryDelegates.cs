using Interactive_Map.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Application.Delegates
{
    public delegate void UpdateDelegate<TEntity, Tid>(TEntity source, TEntity target) where TEntity : EntityBase<Tid>;
}

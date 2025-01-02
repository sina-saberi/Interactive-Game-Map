using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Domain.Base
{
    public class EntityBase<TId> : PureEntity
    {
        public TId Id { get; set; } = default!;
    }
}

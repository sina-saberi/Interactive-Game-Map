using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Application
{

    public delegate void OnAfterUpdateDelegate<TEntity>(TEntity existingEntity, TEntity newEntity);
    public delegate void OnUpdateDelegate<TEntity>(TEntity existingEntity, TEntity newEntity);
    public delegate void OnCreateDelegate<TEntity>(TEntity newEntity);
    public static class Extensions
    {
        public static void AddOrUpdate<TEntity>(
            this IEnumerable<TEntity> entities,
            IEnumerable<TEntity> newEntities,
            Func<TEntity, TEntity, bool> compare,
            OnUpdateDelegate<TEntity> onUpdate,
            OnCreateDelegate<TEntity> onCreate,
            OnAfterUpdateDelegate<TEntity>? onAfterUpdateDelegate = null
            )
        {
            foreach (var newEntity in newEntities)
            {
                var existingEntity = entities.FirstOrDefault(x => compare.Invoke(x, newEntity));
                if (existingEntity != null) onUpdate(existingEntity, newEntity);
                else onCreate(newEntity);

                if (onAfterUpdateDelegate is not null && existingEntity is not null)
                    onAfterUpdateDelegate(existingEntity, newEntity);
            }
        }
    }
}

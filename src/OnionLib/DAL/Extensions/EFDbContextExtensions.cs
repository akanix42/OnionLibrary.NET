using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;

namespace LayeredDev.DAL.Extensions
{
    public static class EFDbContextExtensions
    {
        public static void Detach(this System.Data.Entity.DbContext context, object entity)
        {
            ((System.Data.Entity.Infrastructure.IObjectContextAdapter)context).ObjectContext.Detach(entity);
        }

        public static ObjectContext GetContext(this IEntityWithRelationships entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var relationshipManager = entity.RelationshipManager;

            var relatedEnd = relationshipManager.GetAllRelatedEnds()
                                                .FirstOrDefault();

            if (relatedEnd == null)
                throw new Exception("No relationships found");

            var query = relatedEnd.CreateSourceQuery() as ObjectQuery;

            if (query == null)
                throw new Exception("The Entity is Detached");

            return query.Context;
        }
    }
}
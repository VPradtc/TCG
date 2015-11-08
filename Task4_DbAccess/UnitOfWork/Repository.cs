using System.Collections.Generic;
using System.Data;

namespace Task4_DbAccess.UnitOfWork
{
    /// <summary>
    /// Represents a repository of items that can be obtained from a database.
    /// </summary>
    /// <typeparam name="TEntity">The type that represents a DB table entry.</typeparam>
    public abstract class Repository<TEntity> where TEntity : new()
    {
        protected AdoNetContext m_context;

        protected AdoNetContext Context
        {
            get
            {
                return m_context;
            }
        }
        
        public Repository(AdoNetContext context)
        {
            m_context = context;
        }

        /// <summary>
        /// Executes a command and converts its result to a generic list of entity objects.
        /// </summary>
        /// <param name="command">The command to be executed.</param>
        /// <returns>A list of items returned by the command.</returns>
        protected IEnumerable<TEntity> ToList(IDbCommand command)
        {
            using (var reader = command.ExecuteReader())
            {
                List<TEntity> items = new List<TEntity>();
                while (reader.Read())
                {
                    var item = new TEntity();
                    Map(reader, item);
                    items.Add(item);
                }
                return items;
            }
        }
        /// <summary>
        /// Maps IDataRecord to an entity object.
        /// </summary>
        /// <param name="record">An IDataRecord containing values to be copied.</param>
        /// <param name="entity">An entity whose fields are to be initialized.</param>
        protected abstract void Map(IDataRecord record, TEntity entity);
    }
}

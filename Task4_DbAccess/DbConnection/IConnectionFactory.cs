using System.Data;

namespace Task4_DbAccess
{
    /// <summary>
    /// Defines a connection factory capable of creating a DB connection.
    /// </summary>
    public interface IConnectionFactory
    {
        /// <summary>
        /// Creates a DB connection.
        /// </summary>
        /// <returns></returns>
        IDbConnection Create();
    }
}

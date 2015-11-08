using System;
using System.Data;

namespace Task4_DbAccess.Utils
{
    public static class CommandExtensions
    {
        /// <summary>
        /// Adds a new parameter do the command.
        /// </summary>
        /// <param name="command"></param>
        /// <param name="name">The parameter's name.</param>
        /// <param name="value">The parameter's value.</param>
        public static void AddParameter(this IDbCommand command, string name, object value)
        {
            if (command == null) throw new ArgumentNullException("command");
            if (name == null) throw new ArgumentNullException("name");

            var p = command.CreateParameter();
            p.ParameterName = name;
            p.Value = value ?? DBNull.Value;
            command.Parameters.Add(p);
        }
    }
}

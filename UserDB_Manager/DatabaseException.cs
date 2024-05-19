using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDB_Manager
{
    /// <summary>
    /// Exception thrown when an error occurs in the database
    /// </summary>
    public class DatabaseException : Exception
    {
        /// <summary>
        /// Constructor for the DatabaseException
        /// </summary>
        /// <param name="message"> The message to be shown when the exception is thrown </param>
        public DatabaseException(string message) : base(message)
        {
        }
    }

    /// <summary>
    /// Exception thrown when there is no update made after ADD/UPDATE/DELETE operations
    /// </summary>
    public class NoRowsUpdatedException : DatabaseException
    {
        /// <summary>
        /// Constructor for the NoRowsUpdatedException
        /// </summary>
        /// <param name="message"> The message to be shown when the exception is thrown </param>
        public NoRowsUpdatedException(string message) : base(message)
        {
        }
    }

}

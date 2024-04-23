using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.SudokuApp.Model.Exceptions
{
    /// <summary>
    /// Public <c>ModelException</c> which captures the error 
    /// with the passwords of the users.
    /// </summary>
    [Serializable]
    public class IncorrectPasswordException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="IncorrectPasswordException"/> class.
        /// </summary>
        /// <param name="pseudonim"><c>loginName</c> that causes the error.</param>
        public IncorrectPasswordException(String pseudonim)
            : base("Incorrect password exception => pseudonim = " + pseudonim)
        {
            this.pseudonim = pseudonim;
        }

        /// <summary>
        /// Stores the User login name of the exception
        /// </summary>
        /// <value>The name of the login.</value>
        public String pseudonim { get; private set; }
    }
}

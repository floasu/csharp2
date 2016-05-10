using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaHotel.DataAccess
{
     /// <summary>
    /// Stores the operation result
    /// </summary>
    public class OperationResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationResult"/> class.
        /// </summary>
        public OperationResult()
        {
            Messages = new List<String>();
        }

        /// <summary>
        /// Gets or sets the messages.
        /// </summary>
        /// <value>
        /// The messages.
        /// </value>
        public List<String> Messages
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the operation is successful.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [operation succeeded]; otherwise, <c>false</c>.
        /// </value>
        public bool OperationSucceeded
        {
            get;
            set;
        }

        /// <summary>
        /// A valid result instance
        /// </summary>
        private static OperationResult _validResult = new OperationResult { OperationSucceeded = true };

        /// <summary>
        /// Returns a valid result
        /// </summary>
        /// <value>
        /// A valid result.
        /// </value>
        public static OperationResult OkResult
        {
            get
            {
                return _validResult;
            }
        }
    }
}

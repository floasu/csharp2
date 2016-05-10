using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemaHotel.DataAccess
{
    static class ExceptionMessageComposer
    {
        /// <summary>
        /// Gets the messages from this exception and inner excetion (recursively)
        /// </summary>
        /// <param name="exception">The exception from which the message(s) are to be retrieved.</param>
        /// <returns></returns>
        public static List<String> GetMessages(Exception exception)
        {
            List<String> listOfMessages = new List<String>();
            while (exception != null)
            {
                listOfMessages.Add(exception.Message);
                exception = exception.InnerException;
            }
            return listOfMessages.Distinct().ToList();
        }
    }
}

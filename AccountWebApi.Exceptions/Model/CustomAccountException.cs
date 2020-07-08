using System;

namespace AccountWebApi.Exceptions
{
    /// <summary>
    /// This class defines the custom exception defined for AccountWebApi.
    /// </summary>
    public class CustomAccountException : Exception
    {
        /// <summary>
        /// Status code of error.
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Error message.
        /// </summary>
        public string ExceptionMessage { get; set; }

        /// <summary>
        /// Constructor for ExceptionMessage.
        /// </summary>
        /// <param name="status"></param>
        /// <param name="msg"></param>
        public CustomAccountException(int status, string msg)
        {
            this.Status = status;
            this.ExceptionMessage = msg;
        }
    }
}

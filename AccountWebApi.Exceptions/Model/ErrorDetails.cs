using Newtonsoft.Json;

namespace AccountWebApi.Exceptions
{
    /// <summary>
    /// This class defines the Error details to generate Json.
    /// </summary>
    public class ErrorDetails
    {
        /// <summary>
        /// Status Code of error generated.
        /// </summary>
        public int StatusCode { get; set; }

        /// <summary>
        /// Exception message generated.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Helper method to serialise the exception.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

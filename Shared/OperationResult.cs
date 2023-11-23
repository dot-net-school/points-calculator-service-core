using System.Collections;
using System.Net;

namespace Shared;

    public class OperationResult<T>
    {
        public bool IsSucceed { get; private set; }
        public string Message { get; private set; }
        public HttpStatusCode HttpStatusCode { get; private set; }

        public T Data { get; private set; }

        private OperationResult()
        {
            IsSucceed = false;
            Message = string.Empty;
            HttpStatusCode = 0;
            Data = default;
        }

        public static OperationResult<T> Succeeded(T data, string message = "Mission accomplished.",HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            return new OperationResult<T>
            {
                IsSucceed = true,
                Message = message,
                HttpStatusCode = httpStatusCode,
                Data = data
            };
        }

        public static OperationResult<T> Failed(string message, HttpStatusCode httpStatusCode = HttpStatusCode.BadRequest)
        {
            //when we need to return list and list is empty we return empty list
            return new OperationResult<T>
            {
                IsSucceed = false,
                Message = message,
                HttpStatusCode = httpStatusCode,
                Data = typeof(T) == typeof(List<>) ? Activator.CreateInstance<T>() : default(T)
            };
        }
    }

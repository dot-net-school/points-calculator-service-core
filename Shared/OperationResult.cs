namespace Shared;

    public class OperationResult<T>
    {
        public bool IsSucceeded { get; private set; }
        public string Message { get; private set; }
        public int HttpStatusCode { get; private set; }
        public T Data { get; private set; }

        private OperationResult()
        {
            IsSucceeded = false;
            Message = string.Empty;
            HttpStatusCode = 0;
            Data = default(T);
        }

        public static OperationResult<T> Succeeded(T data, string message = "Mission accomplished.", int httpStatusCode = 200)
        {
            return new OperationResult<T>
            {
                IsSucceeded = true,
                Message = message,
                HttpStatusCode = httpStatusCode,
                Data = data
            };
        }

        public static OperationResult<T> Failed(string message, int httpStatusCode = 400)
        {
            return new OperationResult<T>
            {
                IsSucceeded = false,
                Message = message,
                HttpStatusCode = httpStatusCode,
                Data = default(T)
            };
        }
    }

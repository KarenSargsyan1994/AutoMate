
namespace Automate.Domain.Shared
{
    public class Result
    {
        protected internal Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None)
            {
                throw new InvalidOperationException();
            }

            if (!isSuccess && error ==  Error.None)
            {
                throw new InvalidOperationException();
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; set; }

        public static Result Success() => new(true, Error.None);

        public static ResultT<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);
    }
}

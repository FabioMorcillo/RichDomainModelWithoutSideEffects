using System;
using System.Linq;

namespace RichDomainModelWithoutSideEffects.Models.Base
{
    public class Result
    {
        public bool IsSuccess { get; private set; }

        public bool IsFailure => !IsSuccess;

        public string Error { get; private set; }

        protected Result(bool isSuccess, string error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }

        public static Result Fail(string message)
        {
            return new Result(false, message);
        }

        public static Result<T> Fail<T>(string message)
        {
            return new Result<T>(default(T), false, message);
        }

        public static Result Ok()
        {
            return new Result(true, String.Empty);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, String.Empty);
        }

        public static Result Combine(params Result[] results)
        {
            var resultsFailure = results.Where(r => r.IsFailure);

            if (resultsFailure.Any())
            {
                return Result.Fail(
                    string.Join(Environment.NewLine, resultsFailure.Select(r => r.Error)));
            }

            return Ok();
        }
    }

    public class Result<T> : Result
    {
        private T _value;

        public T Value
        {
            get
            {
                return _value;
            }
            private set { _value = value; }
        }

        protected internal Result(T value, bool success, string error)
            : base(success, error)
        {
            Value = value;
        }

        public static implicit operator T(Result<T> result)
        {
            return result.Value;
        }
    }
}

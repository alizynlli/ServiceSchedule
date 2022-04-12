using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace NBA.ServiceSchedule.Core
{
    public class ActionResult
    {
        public ActionResult()
        {
            ErrorMessages = new List<string>();
            Exception = null;
        }

        public static ActionResult<TNew> From<TNew>(ActionResult otherResultToCopy, TNew data)
        {
            var newResult = new ActionResult<TNew>
            {
                IsSucceed = otherResultToCopy.IsSucceed,
                Data = data,
                ErrorMessages = otherResultToCopy.ErrorMessages,
                Exception = otherResultToCopy.Exception
            };
            return newResult;
        }

        public bool IsSucceed { get; set; }

        public bool IsFailed => !IsSucceed;

        public List<string> ErrorMessages { get; set; }

        public Exception Exception { get; set; }

        public static ActionResult Succeed()
        {
            return new ActionResult
            {
                IsSucceed = true
            };
        }

        public static ActionResult Failed(params string[] errorMessages)
        {
            return new ActionResult
            {
                IsSucceed = false,
                Exception = null,
                ErrorMessages = errorMessages.ToList()
            };
        }

        public static ActionResult Failed(Exception exc)
        {
            var result = new ActionResult { IsSucceed = false, Exception = exc };

            if (exc is SqlException sqlException)
            {
                var sqlErrors = sqlException.Errors.Cast<SqlError>().Select(error => error.Message);
                result.ErrorMessages.AddRange(sqlErrors);
            }

            result.ErrorMessages.Add(exc.Message);
            return result;
        }

        public ActionResult ThrowIfFailed()
        {
            if (IsFailed)
            {
                throw new Exception(ErrorMessages.FirstOrDefault() ?? "Action Result Failed");
            }

            return this;
        }
    }

    public class ActionResult<T> : ActionResult
    {
        public T Data;

        public static ActionResult<T> Succeed(T data)
        {
            return new ActionResult<T>
            {
                IsSucceed = true,
                Data = data
            };
        }
        public new static ActionResult<T> Failed(params string[] errorMessages)
        {
            return new ActionResult<T>()
            {
                IsSucceed = false,
                Exception = null,
                ErrorMessages = errorMessages.ToList()
            };
        }

        public new static ActionResult<T> Failed(Exception exc)
        {
            var result = new ActionResult<T> { IsSucceed = false, Exception = exc };

            if (exc is SqlException sqlException)
            {
                var sqlErrors = sqlException.Errors.Cast<SqlError>().Select(error => error.Message);
                result.ErrorMessages.AddRange(sqlErrors);
            }

            result.ErrorMessages.Add(exc?.Message);
            return result;
        }

        public ActionResult<T> ThrowIfError(bool throwIfEmptyData = false)
        {
            if (Exception != null) throw Exception;
            if (ErrorMessages.Any()) throw new Exception(ErrorMessages.FirstOrDefault());
            if (throwIfEmptyData)
            {
                if (Data == null)
                {
                    throw new Exception("Data came here as null in ActionResult");
                }
            }
            return this;
        }
    }
}

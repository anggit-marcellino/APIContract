using Common.Models;

namespace Common.Helpers
{
    public class ResponseFactory<T>
    {
        public static ResponseModel<T> SuccessResponse(int status, T data)
        {
            return new ResponseModel<T>()
            {
                Success = true,
                Error = null,
                Results = new ResultModel<T>()
                {
                    Status = status,
                    Data = data,
                },
            };
        }

        public static ResponseModel<T> ErrorResponse(int status, T messages)
        {
            return new ResponseModel<T>()
            {
                Success = false,
                Error = new ErrorModel<T>()
                {
                    Status = status,
                    Messages = messages,
                },
                Results = null,
            };
        }
    }
}

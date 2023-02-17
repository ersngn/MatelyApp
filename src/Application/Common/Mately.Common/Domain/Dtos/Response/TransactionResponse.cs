using System.Net;
using System.Text.Json.Serialization;
using Mately.Common.Constants;
using Mately.Common.Domain.Dtos.Base;
using Mately.Common.Domain.Dtos.Transaction;
using Mately.Common.Enumeration;
using TransactionMessage = Mately.Common.Constants.TransactionMessageConstant;

namespace Mately.Common.Domain.Dtos.Response;

public class Response : IResponse
{
    [JsonIgnore]
    public HttpStatusCode StatusCode { get; set; }
    public bool IsSuccess { get; set; }
    public object Data { get; set; }

    public static Response Succeess(object data)
    {
        return new Response()
        {
            StatusCode = HttpStatusCode.OK,
            IsSuccess = true,
            Data = data
        };
    }

    public static Response Success(object data, HttpStatusCode statusCode)
    {
        return new Response()
        {
            StatusCode = statusCode,
            IsSuccess = true,
            Data = data
        };
    }

    public static Response Fail(object data)
    {
        return new Response()
        {
            StatusCode = HttpStatusCode.BadRequest,
            IsSuccess = false,
            Data = data
        };
    }

    public static Response Fail(object data, HttpStatusCode statusCode)
    {
        return new Response()
        {
            StatusCode = statusCode,
            IsSuccess = false,
            Data = data
        };
    }
    public static Response Fail(TransactionResultEnum error, string errorMessage)
    {
        var errorDto = new ErrorDto()
        {
            Error = error,
            ErrorCode = (int)error,
            Message = errorMessage
        };
        return new Response()
        {
            Data = errorDto,
            StatusCode = HttpStatusCode.BadRequest,
            IsSuccess = false
        };
    }
    public static Response Fail(string exceptionMessage)
    {
        var errors = new List<ErrorDto>()
        {
            new()
            {
                Error = TransactionResultEnum.UnknownError,
                ErrorCode = (int)TransactionResultEnum.UnknownError,
                Message = TransactionMessageConstant.UnknownError
            },
            new()
            {
                Error = TransactionResultEnum.UnknownError,
                ErrorCode = (int)TransactionResultEnum.UnknownError,
                Message = exceptionMessage
            }
        };
        return new Response()
        {
            Data = errors,
            StatusCode = HttpStatusCode.BadRequest,
            IsSuccess = false
        };
    }
}


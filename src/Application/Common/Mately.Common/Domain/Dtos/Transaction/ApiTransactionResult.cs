using System.Net;
using Mately.Common.Constants;
using Mately.Common.Domain.Dtos.Base;
using Mately.Common.Enumeration;
using Microsoft.OpenApi.Extensions;

namespace Mately.Common.Domain.Dtos.Transaction;

public class ApiTransactionResult<T> : IResponse where T : class
{
    public bool IsSuccess { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public List<TransactionMessage> Messages { get; set; }
    public T? Data { get; set; }
    
    

    public void Success(T data)
    {
        IsSuccess = true;
        StatusCode = HttpStatusCode.OK;
        Messages = new List<TransactionMessage>()
        {
            new()
            {
                Message = TransactionResultEnum.TransactionSuccess,
                Code = (int)TransactionResultEnum.TransactionSuccess,
                Description = TransactionResultEnum.TransactionSuccess.GetDisplayName()
            }
        };
        Data = data;
    }
    
    public void Success(T data, HttpStatusCode statusCode)
    {
        IsSuccess = true;
        StatusCode = statusCode;
        Messages = new List<TransactionMessage>()
        {
            new()
            {
                Message = TransactionResultEnum.TransactionSuccess,
                Code = (int)TransactionResultEnum.TransactionSuccess,
                Description = TransactionResultEnum.TransactionSuccess.GetDisplayName()
            }
        };
        Data = data;
    }
    
    public void UnKnownError(string exeptionMessage)
    {
        IsSuccess = false;
        StatusCode = HttpStatusCode.BadRequest;
        Messages = new List<TransactionMessage>()
        {
            new()
            {
                Message = TransactionResultEnum.UnknownError,
                Code = (int)TransactionResultEnum.UnknownError,
                Description = exeptionMessage
            }
        };
    }

    public void Fail(TransactionResultEnum message)
    {
        IsSuccess = false;
        StatusCode = HttpStatusCode.BadRequest;
        Messages = new List<TransactionMessage>()
        {
            new()
            {
                Message = message,
                Code = (int)message,
                Description = message.GetDisplayName()
            }
        };
    }
    
    public void Fail(TransactionResultEnum message,T data)
    {
        IsSuccess = false;
        StatusCode = HttpStatusCode.BadRequest;
        Messages = new List<TransactionMessage>()
        {
            new()
            {
                Message = message,
                Code = (int)message,
                Description = message.GetDisplayName()
            }
        };
        Data = data;
    }

    public void Fail(List<TransactionMessage> messages)
    {
        IsSuccess = false;
        StatusCode = HttpStatusCode.BadRequest;
        Messages = messages;
    }
    
}
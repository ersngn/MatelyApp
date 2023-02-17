using System.Text.RegularExpressions;
using FluentValidation.Results;
using Mately.Common.Constants;
using Mately.Common.Domain.Dtos.Transaction;
using Mately.Common.Enumeration;
using Microsoft.OpenApi.Extensions;

namespace Mately.Indentity.API.Helpers.Validation;

public static class ValidationHelper
{
    public static bool IsEmailValid(string email)
    {
        var regex = RegexConstant.EmailRegex;

        return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase);
    }

    public static bool IsPhoneNumber(string? number)
    {
        var regex = RegexConstant.PhoneRegex;
        if (number != null) return Regex.IsMatch(number, regex);
        return false;
    }

    public static bool IsName(string? name)
    {
        var regex = RegexConstant.NameRegex;
        if(name!=null) return Regex.IsMatch(name, regex);
        return false;
    }

    public static List<TransactionMessage> ErrorValidation(ValidationResult result)
    {
        var errors = result.Errors.Select(e => e.ErrorCode).ToList().Select(int.Parse)
            .Select(e => (TransactionResultEnum)e).ToList();
        var transactionMessages = new List<TransactionMessage>();
        foreach (var error in errors)
        {
            var transactionMessage = new TransactionMessage()
            {
                Code = (int)error, Description = error.GetDisplayName(), Message = error
            };
            transactionMessages.Add(transactionMessage);
        }

        return transactionMessages;
    }
}
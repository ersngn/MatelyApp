using FluentValidation;
using Mately.Common.Enumeration;
using Mately.Indentity.API.Domain.Auth.Dtos;
using Mately.Indentity.API.Domain.User.Dtos;
using Mately.Indentity.API.Helpers.Validation;

namespace Mately.Indentity.API.Services.Auth.Validation;


public class ValidatorRegisterDto : AbstractValidator<RegisterDto>
{
    public ValidatorRegisterDto()
    {
        #region NullCheck
        RuleFor(e => e.Email).NotNull().Must(f => !string.IsNullOrWhiteSpace(f))
            .WithErrorCode(((int)TransactionResultEnum.NullEmail).ToString());
        RuleFor(e => e.Password).NotNull().Must(f => !string.IsNullOrWhiteSpace(f))
            .WithErrorCode(((int)TransactionResultEnum.NullPassword).ToString());
        RuleFor(e => e.FirstName).NotNull().Must(f => !string.IsNullOrWhiteSpace(f))
            .WithErrorCode(((int)TransactionResultEnum.NullFirstName).ToString());
        RuleFor(e => e.LastName).NotNull().Must(f => !string.IsNullOrWhiteSpace(f))
            .WithErrorCode(((int)TransactionResultEnum.NullLastName).ToString());
        RuleFor(e => e.PhoneNumber).NotNull().Must(f => !string.IsNullOrWhiteSpace(f))
            .WithErrorCode(((int)TransactionResultEnum.NullPhone).ToString());
        RuleFor(e => e.UserName).NotNull().Must(f => !string.IsNullOrWhiteSpace(f))
            .WithErrorCode(((int)TransactionResultEnum.NullUserName).ToString());
        #endregion

        #region Validation
        RuleFor(e => e.Email).Must(ValidationHelper.IsEmailValid)
            .WithErrorCode(((int)TransactionResultEnum.NotValidEmail).ToString());
        RuleFor(e => e.FirstName).Must(ValidationHelper.IsName)
            .WithErrorCode(((int)TransactionResultEnum.NotValidFirstName).ToString());
        RuleFor(e => e.LastName).Must(ValidationHelper.IsName)
            .WithErrorCode(((int)TransactionResultEnum.NotValidLastName).ToString());
        RuleFor(e => e.PhoneNumber).Must(ValidationHelper.IsPhoneNumber)
            .WithErrorCode(((int)TransactionResultEnum.NotValidPhone).ToString());
        #endregion
    }
}

public class ValidatorLoginDto : AbstractValidator<LoginDto>
{
    public ValidatorLoginDto()
    {
        RuleFor(e => e.Password).NotNull().Must(f => !string.IsNullOrWhiteSpace(f))
            .WithErrorCode(((int)TransactionResultEnum.NullPassword).ToString());
        RuleFor(e => e.UserName).NotNull().Must(f => !string.IsNullOrWhiteSpace(f))
            .WithErrorCode(((int)TransactionResultEnum.NullUserName).ToString());
    }
}
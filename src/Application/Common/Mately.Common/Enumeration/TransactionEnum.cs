using System.ComponentModel.DataAnnotations;
using Mately.Common.Constants;
using Mately.Common.Domain.Dtos.Transaction;

namespace Mately.Common.Enumeration;


public enum TransactionResultEnum
{
    #region Common
    [Display(Name = TransactionMessageConstant.UnknownError)]
    UnknownError = 10000,
    [Display(Name = TransactionMessageConstant.TransactionSuccess)]
    TransactionSuccess = 10001,
    #endregion
    
    #region NullCheck
    [Display(Name = TransactionMessageConstant.NullEmail)]
    NullEmail = 11000,
    [Display(Name = TransactionMessageConstant.NullPhone)]
    NullPhone = 11002,
    [Display(Name = TransactionMessageConstant.NullUserName)]
    NullUserName = 11003,
    [Display(Name = TransactionMessageConstant.NullEmail)]
    NullFirstName = 11004,
    [Display(Name = TransactionMessageConstant.NullLastName)]
    NullLastName = 11005,
    [Display(Name = TransactionMessageConstant.NullPassword)]
    NullPassword = 11006,
    [Display(Name = TransactionMessageConstant.NullRole)]
    NullRole = 11011,
    #endregion

    #region Validation
    [Display(Name = TransactionMessageConstant.EmailNotValid)]
    NotValidEmail = 11007,
    [Display(Name = TransactionMessageConstant.PhoneNotValid)]
    NotValidPhone = 11008,
    [Display(Name = TransactionMessageConstant.FirstNameNotValid)]
    NotValidFirstName = 11009,
    [Display(Name = TransactionMessageConstant.NullPassword)]
    NotValidLastName = 11010,
    #endregion

    #region User
    
    [Display(Name = TransactionMessageConstant.UserNotCreated)]
    UserNotCreated = 1201,
    [Display(Name = TransactionMessageConstant.UserNameAlreadyExist)]
    UserNameAlreadyExist = 1202,
    [Display(Name = TransactionMessageConstant.EmailAlreadyExist)]
    EmailAlreadyExist = 1203,
    [Display(Name = TransactionMessageConstant.PhoneAlreadyExist)]
    PhoneAlreadyExist = 1204,
    [Display(Name = TransactionMessageConstant.UserNotFound)]
    UserNotFound = 1208,


    #endregion

    #region Account
    [Display(Name = TransactionMessageConstant.AccountNotCreated)]
    AccountNotCreated = 1205,
    [Display(Name = TransactionMessageConstant.AccountNotUpdated)]
    AccountNotUpdated = 1206,
    

    #endregion

    #region AccountSecurity

    [Display(Name = TransactionMessageConstant.AccountSecurityNotCreated)]
    AccountSecurityNotCreated = 1207,
    [Display(Name = TransactionMessageConstant.AccountSecurityNotFound)]
    AccountSecurityNotFound = 12022,

    #endregion

    #region Auth

    [Display(Name = TransactionMessageConstant.PasswordNotMatch)]
    PasswordNotMatch = 1225,
    [Display(Name = TransactionMessageConstant.InvalidRequest)]
    InvalidRequest = 1209,
    [Display(Name = TransactionMessageConstant.InvalidTokenOrRefreshToken)]
    InvalidTokenOrRefreshToken = 1210,

    #endregion

    #region Role

    [Display(Name = TransactionMessageConstant.RolesNotFound)]
    RolesNotFound = 1220,

    #endregion
}
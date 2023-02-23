using System.ComponentModel.DataAnnotations;
using Mately.Common.Constants;
using Mately.Common.Domain.Dtos.Transaction;

namespace Mately.Common.Enumeration;


public enum TransactionResultEnum
{
    #region Common
    [Display(Name = TransactionMessageConstant.UnknownError)]
    UnknownError = 10001,
    [Display(Name = TransactionMessageConstant.TransactionSuccess)]
    TransactionSuccess = 10002,
    #endregion

    #region Identity
    
    #region NullCheck
    [Display(Name = TransactionMessageConstant.NullEmail)]
    NullEmail = 11100,
    [Display(Name = TransactionMessageConstant.NullPhone)]
    NullPhone = 11101,
    [Display(Name = TransactionMessageConstant.NullUserName)]
    NullUserName = 11102,
    [Display(Name = TransactionMessageConstant.NullEmail)]
    NullFirstName = 11103,
    [Display(Name = TransactionMessageConstant.NullLastName)]
    NullLastName = 11104,
    [Display(Name = TransactionMessageConstant.NullPassword)]
    NullPassword = 11105,
    [Display(Name = TransactionMessageConstant.NullRole)]
    NullRole = 11106,
    #endregion

    #region Validation
    [Display(Name = TransactionMessageConstant.EmailNotValid)]
    NotValidEmail = 11200,
    [Display(Name = TransactionMessageConstant.PhoneNotValid)]
    NotValidPhone = 11201,
    [Display(Name = TransactionMessageConstant.FirstNameNotValid)]
    NotValidFirstName = 11202,
    [Display(Name = TransactionMessageConstant.NullPassword)]
    NotValidLastName = 11203,
    #endregion
    
    #region User
    [Display(Name = TransactionMessageConstant.UserNotCreated)]
    UserNotCreated = 11300,
    [Display(Name = TransactionMessageConstant.UserNameAlreadyExist)]
    UserNameAlreadyExist = 11301,
    [Display(Name = TransactionMessageConstant.EmailAlreadyExist)]
    EmailAlreadyExist = 11302,
    [Display(Name = TransactionMessageConstant.PhoneAlreadyExist)]
    PhoneAlreadyExist = 11303,
    [Display(Name = TransactionMessageConstant.UserNotFound)]
    UserNotFound = 11304,
    #endregion

    #region Account
    [Display(Name = TransactionMessageConstant.AccountNotCreated)]
    AccountNotCreated = 11400,
    [Display(Name = TransactionMessageConstant.AccountNotUpdated)]
    AccountNotUpdated = 11401,
    #endregion
    
    #region AccountSecurity
    [Display(Name = TransactionMessageConstant.AccountSecurityNotCreated)]
    AccountSecurityNotCreated = 11400,
    [Display(Name = TransactionMessageConstant.AccountSecurityNotFound)]
    AccountSecurityNotFound = 11401,
    #endregion
    
    #region Auth
    [Display(Name = TransactionMessageConstant.PasswordNotMatch)]
    PasswordNotMatch = 11500,
    [Display(Name = TransactionMessageConstant.InvalidRequest)]
    InvalidRequest = 11501,
    [Display(Name = TransactionMessageConstant.InvalidTokenOrRefreshToken)]
    InvalidTokenOrRefreshToken = 11502,
    #endregion

    #region Role
    [Display(Name = TransactionMessageConstant.RolesNotFound)]
    RolesNotFound = 11600,
    #endregion
    #endregion

    #region Match

    #region Profile
    
    [Display(Name = TransactionMessageConstant.ProfileNotCreated)]
    ProfileNotCreated = 12000,
    [Display(Name = TransactionMessageConstant.ProfileNotFount)]
    ProfileNotFount = 12001,
    [Display(Name = TransactionMessageConstant.ProfileNotUpdated)]
    ProfileNotUpdated = 12002,
    [Display(Name = TransactionMessageConstant.ProfilesNotFoundByDistance)]
    ProfilesNotFoundByDistance = 12003,
    
    

    #endregion
    

    #endregion




}
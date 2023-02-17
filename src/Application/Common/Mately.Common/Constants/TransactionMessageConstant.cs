namespace Mately.Common.Constants;

public static class TransactionMessageConstant
{
    #region Common
    public const string UnknownError = "An unknown error has occurred.";
    public const string TransactionSuccess = "Transaction has been suuccess";
    
    #endregion
    
    #region NullCheck

    public const string NullEmail = "The email must not be empty";
    public const string NullPhone = "The phone must not be empty";
    public const string NullUserName = "The user name must not be empty";
    public const string NullFirstName = "The first name must not be empty";
    public const string NullLastName = "The last name must not be empty";
    public const string NullPassword = "The password must not be empty";
    public const string NullRole = "The role must not be null";
    
    #endregion

    #region Validation

    public const string EmailNotValid = "The email is not valid.";
    public const string PhoneNotValid = "The phone number is not valid.";
    public const string FirstNameNotValid = "The first name is not valid.";
    public const string LastNameNotValid = "The first name is not valid.";

    #endregion

    #region User

    public const string UserNotCreated = "The user has been not created";
    public const string UserNotFound = "The user has been not found";
    public const string EmailAlreadyExist = "The email has been already used by another user.";
    public const string PhoneAlreadyExist = "The phone number has been already used by another user.";
    public const string UserNameAlreadyExist = "The email has been already used by another user.";
    
    #endregion

    #region Role

    public const string RolesNotFound = "Roles were found for this user";

    #endregion

    #region Account

    public const string AccountNotCreated = "The account has been not created";
    public const string AccountNotUpdated = "The account has been not updated";

    #endregion

    #region AccountSecurity

    public const string AccountSecurityNotCreated = "The account security has been not created";
    public const string AccountSecurityNotFound = "The account security has been not found";
    #endregion

    #region Auth

    public const string PasswordNotMatch = "The password has been not matched";
    public const string InvalidTokenOrRefreshToken = "Invalid access token or refresh token";

    #endregion

    #region Request

    public const string InvalidRequest = "The request was be invalid";

    #endregion
}
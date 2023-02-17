namespace Mately.Common.Constants;

public class RegexConstant
{
    public const string PhoneRegex = @"^\\+?[1-9][0-9]{7,14}$";
    public const string EmailRegex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";
    public const string NameRegex = @"^[A-Z][a-zA-Z]*$";
    
}
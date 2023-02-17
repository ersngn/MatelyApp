using Mately.Identity.API.Domain.User.Dtos;

namespace Mately.Indentity.API.Helpers.Security;

public interface ISecurityHelper
{
    EncyrptTextDto Encrypt(string sourceText);
    DecryptTextDto Decrypt(string sourceText);
    HashedTextDto CreateHash(string value, string salt);
    HashedTextDto CreateHash();

    ValidateHashDto ValidateHash(string value, string salt, string hash);
}
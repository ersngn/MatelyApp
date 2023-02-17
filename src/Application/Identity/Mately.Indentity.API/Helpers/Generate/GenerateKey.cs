using System.Security.Cryptography;
using System.Text;
using Mately.Common.Constants;
using Mately.Indentity.API.Domain.AccountSecurity.Dtos;
using Mately.Indentity.API.Domain.Security;

namespace Mately.Indentity.API.Helpers.Generate;

public static class GenerateKey
{
    public static GenerateTextDto GenerateTextKey(int size)
    {
        var data = new byte[4 * size];
        using (var crypto = RandomNumberGenerator.Create())
        {
            crypto.GetBytes(data);
        }

        var result = new StringBuilder(size);
        for (var i = 0; i < size; i++)
        {
            var rnd = BitConverter.ToUInt32(data, i * 4);
            var idx = rnd % SecurityConstant.Chars.Length;

            result.Append(SecurityConstant.Chars[idx]);
        }

        return new GenerateTextDto
        {
            GeneratedText = result.ToString()
        };
    }
}
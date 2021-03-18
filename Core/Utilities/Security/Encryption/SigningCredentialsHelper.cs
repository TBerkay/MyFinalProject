using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        // giriş bilgilerin
        // jwt token oluşturmak için, sen bir jwt kullanıyosun ve key ile algoritman bu
        // hangi anahtar ve hangi algoritma bu değerleri veriyoruz
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) 
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    // kullanıcıya verilen token
    // kullanıcı adı ve parola verildiğinde token verilir
    // sonlanma tarihi de verilir
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}

using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        // kullanıcı giriş yaptığında parola vb. girdiğinde bu metod çalışır
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
        //kullanıcıyı bulacak onun claim lerini bulacak ve token oluşturup geri döndürecek
    }
}

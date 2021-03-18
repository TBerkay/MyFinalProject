using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //out dışarıya verilecek değer
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // byte olarak gönderilmeli
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt)) // doğrulama yapacağımız için key i koyarız
            {
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); // girilen password u hash le
                // array oldukları için ve bunları karşılaştırmak için for kullan

                for(int i = 0; i<computeHash.Length; i++)
                {
                    if(computeHash[i] != passwordHash[i])
                    {
                        return false;
                    }

                }

                return true;
            }      
        }
    }
}

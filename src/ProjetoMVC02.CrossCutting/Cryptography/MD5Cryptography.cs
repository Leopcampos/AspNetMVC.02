using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoMVC02.CrossCutting.Cryptography
{
    public class MD5Cryptography
    {
        /// <summary>
        /// método para receber um valor string e retorna-lo criptografado em MD5
        /// </summary>
        public static string Encrypt(string value)
        {
            var md5 = new MD5CryptoServiceProvider();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));

            //convertendo o conteudo da variavel hash de byte[] para string
            var result = string.Empty;
            foreach (var item in hash)
            {
                result += item.ToString("X2"); //X2 -> HEXADECIMAL
            }
            return result.ToUpper();
        }
    }
}
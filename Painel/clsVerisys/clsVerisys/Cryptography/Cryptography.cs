using System;
using System.IO;
using System.Security.Cryptography;

namespace clsVerisys.Cryptography
{
    public class Cryptography
    {
        const String KEY = "d15f85r45e2s33a6s5";
        public enum Metodo
        {
            Criptografar,
            Decriptograr
        }

        public String Criptografia(String strValor, Metodo enumMetodo)
        {
            if (enumMetodo == Metodo.Criptografar)
            {
                Byte[] clearBytes = System.Text.Encoding.UTF8.GetBytes(strValor);
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(KEY, new Byte[] { 0x49, 0x76, 0x61, 0x9e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                Byte[] encryptedData = Encrypt(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
                return Convert.ToBase64String(encryptedData);
            }
            else 
            {
                Byte[] cipherBytes = Convert.FromBase64String(strValor);
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(KEY, new Byte[] { 0x49, 0x76, 0x61, 0x9e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                Byte[] decryptedData = Decrypt(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
                return System.Text.Encoding.UTF8.GetString(decryptedData);
            }
        }

        private Byte[] Encrypt(Byte[] clearData, Byte[] Key, Byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();

            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearData, 0, clearData.Length);
            cs.Close();

            Byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }

        public static Byte[] Decrypt(Byte[] cipherData, Byte[] Key, Byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();

            alg.Key = Key;
            alg.IV = IV;

            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();

            Byte[] decryptedData = ms.ToArray();
            return decryptedData;
        }
    }
}

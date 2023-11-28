using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace DAMRsaCrypt
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter text to encrypt with RSA");
            var text= Console.ReadLine();

            UnicodeEncoding byteConverter = new UnicodeEncoding();
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            byte[] plainText;
            byte[] encryptedText;

            if (text != null)
            {
                plainText = byteConverter.GetBytes(text);
                encryptedText = EncryptText(plainText, RSA.ExportParameters(false), false);
                Console.WriteLine("Encrypted Text=:" + Convert.ToBase64String(encryptedText));
            }
        }

        static byte[] EncryptText(byte[] data, RSAParameters rSAKey, bool padding)
        {
            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.ImportParameters(rSAKey);
                encryptedData = RSA.Encrypt(data, padding);
            }
            return encryptedData;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class RC4: ICryptoAlgorithm
    {

        static public long keyLen;
        static public int counter;
        protected byte[] key;
        protected byte[] iv;
        static public long ivLen;
        int randomKeyLength;
        int randomIvLength;
        long i;
        long j;

        public RC4()
        {
            i = 3;
            j = 4;
            randomKeyLength = 8;
            randomIvLength = 10;
            counter = 0;

           // GenerateRandomIV();
        }

        public bool SetKey(byte[] input)
        {
            
            keyLen = input.Length;
            key = new byte[keyLen];
            key = input;
            
            return true;
        }


        public byte[] GenerateRandomKey()
        {
            int pom;
            Random rand = new Random();
            
            byte[] rKey = new byte[randomKeyLength];

            for (int i = 0; i < randomKeyLength; i++)
            {
                pom = rand.Next(35, 125);
                rKey[i] = (byte)pom;
            }
            return rKey;
        }


        public bool SetIV(byte[] input)
        {
            ivLen = input.Length;
            iv = new byte[ivLen];
            iv = input;

            return true;
        }

        public byte[] GenerateRandomIV()
        {
            int pom;
            Random rand = new Random();

            byte[] rKey = new byte[randomIvLength];

            for (int i = 0; i < randomIvLength; i++)
            {
                pom = rand.Next(35, 125);
                rKey[i] = (byte)pom;
            }

           // SetIV(rKey);

            return rKey;
        }

        public bool SetAlgorithmProperties(IDictionary<string, byte[]> specArguments)
        {
            byte[] di= specArguments["i"];
            byte[] dj = specArguments["j"];
            i = BitConverter.ToInt32(di, 0);
            j = BitConverter.ToInt32(dj, 0);
            return true;
        }

        public byte[] CryptCTR(byte[] input)
        {
            
            /////////
            byte[] output = new byte[input.Length];

            byte[] ctr;
            byte[] IVCounter; 

            byte[] encryptedBlock;
            long count = 0;
            long inputCount=input.Count();

            for (int j = 0; j < inputCount; j++)
            {
                counter++;
                ctr = BitConverter.GetBytes(counter);

                IVCounter = iv;
                IVCounter = IVCounter.Concat(ctr).ToArray();
                
                encryptedBlock = Crypt(IVCounter);

                for (int i = 0; i < encryptedBlock.Count(); i++)
                {
                    if (count < inputCount)
                    {
                        output[count] = (byte)(input[count] ^ encryptedBlock[i]);
                        count++;
                    }
                }

                
            }
            counter = 0;
                return output; 
           
        }

        public byte[] Crypt(byte[] input)
        {
            byte[] output = new byte[input.Length];
            byte[] localKey = new byte[keyLen];
            this.key.CopyTo(localKey, 0);

            for (long offset = 0; offset < input.Length; offset++)
            {
                i = (i + 1) % keyLen;
                j = (j + localKey[i]) % keyLen;
                //  Console.WriteLine("i="+i);
                //Console.WriteLine("j=" + j);
                //Console.Write(Convert.ToString(j, 2));
                //Console.WriteLine();
                byte temp = localKey[i];
                localKey[i] = localKey[j];
                localKey[j] = temp;
                byte a = input[offset];
                byte b = localKey[(localKey[i] + localKey[j]) % keyLen];
                output[offset] = (byte)((int)a ^ (int)b);

                //Console.WriteLine("output [" + offset+"]");
                //Console.Write(Convert.ToString(output[offset], 2));
                //Console.WriteLine();
            }

            return output;
        }

        public byte[] DecryptCTR(byte[] output)
        {
            return CryptCTR(output);
        }

        public byte[] Decrypt(byte[] output)
        {
            return Crypt(output);
        }
    }
}

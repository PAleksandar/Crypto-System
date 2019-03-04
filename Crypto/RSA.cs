using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class RSA: ICryptoAlgorithm
    {
        private int p;
        private int q;
        private int n;
        private int e;
        private int d;


        protected byte[] iv;
        static public long ivLen;
        int randomIvLength;
        static public int counter;

        public RSA()
        {
            randomIvLength = 8;
            counter = 0;

           // GenerateRandomIV();
        }

        public void init(int p,int q)
        {
            this.p = p;
            this.q = q;
            n = p * q;
            e = 1;

            if (e == 1 || GetMinimalDivider((p - 1) * (q - 1), e) > 1)
            {
                if (e == 1)
                    e = 3;
                while (GetMinimalDivider((p - 1) * (q - 1), e) > 1)
                {
                    e++;
                }
            }

            d = 1;

            while ((d * e) % ((p - 1) * (q - 1)) != 1)
            {
                d++;
            }
        }

        public int GetMinimalDivider(int a, int b)
        {
            if ((a % b) == 0)
            {
                return b;
            }
            else
            {
                a -= b;
                if (a > b)
                    return this.GetMinimalDivider(a, b);
                else
                    return this.GetMinimalDivider(b, a);
            }
        }

        public bool SetKey(byte[] input)
        {
            throw new NotImplementedException();
        }

        public byte[] GenerateRandomKey()
        {
            throw new NotImplementedException();
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

            //SetIV(rKey);

            return rKey;
        }

        public bool SetAlgorithmProperties(IDictionary<string, byte[]> specArguments)
        {
            byte[] dp = specArguments["p"];
            byte[] dq = specArguments["q"];
            int pi = BitConverter.ToInt32(dp, 0);
            int qi = BitConverter.ToInt32(dq, 0);

            init(pi, qi);
            return true;
        }

        public byte[] CryptCTR(byte[] input)
        {
            /////////
            byte[] output = new byte[input.Length];

            byte[] ctr;// = BitConverter.GetBytes(counter);
            byte[] IVCounter;

            //counter++;
            //byte[] encryptedBlock = CryptBlock(IVCounter);
            byte[] encryptedBlock;
            long count = 0;
            long inputCount = input.Count();

            while(count< inputCount)
            {
                counter++;
                ctr = BitConverter.GetBytes(counter);

                IVCounter = iv;
                // IVCounter = IVCounter.Concat(iv).ToArray();
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
            //byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(this.tbxRSASource.Text);
            //RSA rsa = new RSA();
            //rsa.PublicKey_N = System.Convert.ToInt32(this.tbxRSAN.Text);
            //rsa.PublicKey_E = System.Convert.ToInt32(this.tbxRSAE.Text);

            string outstr = "";
            foreach (byte b in input)
            {
                int res = Calculate(b, this.e);
                outstr += res.ToString() + " ";
            }

            byte[] output = System.Text.Encoding.ASCII.GetBytes(outstr);
            return output;
        }

        public int Calculate(int startValue, int eksp)
        {
            int retValue = startValue;

            for (int i = 1; i < eksp; i++)
            {
                retValue = (retValue * startValue) % this.n;
            }

            return retValue;
        }

        public byte[] DecryptCTR(byte[] input)
        {
            ///////////
            //byte[] output = new byte[input.Length];

            //byte[] ctr;// = BitConverter.GetBytes(counter);
            //byte[] IVCounter;

            ////counter++;
            ////byte[] encryptedBlock = CryptBlock(IVCounter);
            //byte[] encryptedBlock;
            //long count = 0;
            //long inputCount = input.Count();

            //for (int j = 0; j < inputCount; j++)
            //{
            //    counter++;
            //    ctr = BitConverter.GetBytes(counter);

            //    IVCounter = iv;
            //    // IVCounter = IVCounter.Concat(iv).ToArray();
            //    IVCounter = IVCounter.Concat(ctr).ToArray();

            //    encryptedBlock = DecryptBlock(IVCounter);
            //  //  output = encryptedBlock;
            //    for (int i = 0; i < encryptedBlock.Count(); i++)
            //    {
            //        if (count < inputCount)
            //        {
            //            output[count] = (byte)(input[count] ^ encryptedBlock[i]);
                        
            //            count++;
            //        }
            //    }


            //}
            //counter = 0;
            //return output; 

            return CryptCTR(input);
        }

        public byte[] Decrypt(byte[] input)
        {
            string cod = System.Text.Encoding.ASCII.GetString(input);
            string[] codes = cod.Split(' ');
            //string[] codes =  .Split(' ');

            //RSA rsa = new RSA();
            //rsa.PrivateKey_D = System.Convert.ToInt32(this.tbxRSAD.Text);
            //rsa.PublicKey_N = System.Convert.ToInt32(this.tbxRSAN.Text);

            string outstr = "";
            foreach (string s in codes)
            {
                int C = 0;
                try
                {
                    C = System.Convert.ToInt32(s);
                }
                catch
                {
                    C = 1;
                }
                C = Calculate(C, this.d);
                outstr += System.Convert.ToChar(C);
            }

            byte[] output = System.Text.Encoding.ASCII.GetBytes(outstr);
            return output;
        }




    }
}

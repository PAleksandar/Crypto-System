using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
     public class A5_2 : ICryptoAlgorithm
    {
         ShiftRegister R1;
         ShiftRegister R2;
         ShiftRegister R3;
         ShiftRegister R4;
         int[] clockBits;

         public A5_2()
         {
             R1 = new ShiftRegister(19);
             R2 = new ShiftRegister(22);
             R3 = new ShiftRegister(23);
             R4 = new ShiftRegister(17);

             //set majority elements
             int[] r1m = new int[3];
             r1m[0] = 12;
             r1m[1] = 14;
             r1m[2] = 15;
             R1.SetMajorityBits(r1m);

             int[] r2m = new int[3];
             r2m[0] = 9;
             r2m[1] = 13;
             r2m[2] = 16;
             R2.SetMajorityBits(r2m);

             int[] r3m = new int[3];
             r3m[0] = 7;
             r3m[1] = 20;
             r3m[2] = 21;
             R3.SetMajorityBits(r3m);

             //set bits for new value
             int[] rnb1 = new int[4];
             rnb1[0] = 13;
             rnb1[1] = 16;
             rnb1[2] = 17;
             rnb1[3] = 18;
             R1.SetBitsForNewValue(rnb1);


             int[] rnb2 = new int[2];
             rnb2[0] = 20;
             rnb2[1] = 21;
             R2.SetBitsForNewValue(rnb2);

             int[] rnb3 = new int[4];
             rnb3[0] = 7;
             rnb3[1] = 20;
             rnb3[2] = 21;
             rnb3[3] = 22;
             R3.SetBitsForNewValue(rnb3);

             int[] rnb4 = new int[2];
             rnb4[0] = 11;
             rnb4[1] = 16;
             R4.SetBitsForNewValue(rnb4);

             clockBits = new int[3];
             clockBits[0] = 10;
             clockBits[1] = 3;
             clockBits[2] = 7;

         }

        public bool SetKey(byte[] input)
        {
            R1.EmptyRegyister();
            R2.EmptyRegyister();
            R3.EmptyRegyister();
            R4.EmptyRegyister();

            char[] K = getByteBinaryString(input).ToCharArray();

            for (int i = 0; i < 64; i++ )
            {
                R1.Shift();
                R2.Shift();
                R3.Shift();
                R4.Shift();

                R1.Register[0] = R1.XOR(R1.Register[0], K[i]);
                R2.Register[0] = R2.XOR(R2.Register[0], K[i]);
                R3.Register[0] = R3.XOR(R3.Register[0], K[i]);
                R4.Register[0] = R4.XOR(R4.Register[0], K[i]);

            }

                return true;
        }
        private String getByteBinaryString(byte b)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 7; i >= 0; --i)
            {
                sb.Append(b >> i & 1);
                
            }
            return sb.ToString();

        }

         private String getByteBinaryString(byte[] bs)
        {
            StringBuilder sb = new StringBuilder();
             for(int i=0; i<bs.Count(); i++)
             {
                 sb.Append(getByteBinaryString(bs[i]));
             }

             return sb.ToString();
        }
        public byte[] GenerateRandomKey()
        {
            //Random rnd = new Random();
            //byte[] ret = new byte[64];
            //for (int i = 0; i < 64; i++)
            //    ret[i] = rnd.Next(0, 11) > 5 ? (byte)1 : (byte)0;
            //return ret;

            int pom;
            Random rand = new Random();

            byte[] rKey = new byte[64];

            for (int i = 0; i < 64; i++)
            {
                pom = rand.Next(35, 125);
                rKey[i] = (byte)pom;
            }

            //SetIV(rKey);

            return rKey;
        }

        public bool SetIV(byte[] input)
        {
            char[] f = getByteBinaryString(input).ToCharArray();

            for (int i = 0; i < 22; i++)
            {
                R1.Shift();
                R2.Shift();
                R3.Shift();
                R4.Shift();

                R1.Register[0] = R1.XOR(R1.Register[0], f[i]);
                R2.Register[0] = R2.XOR(R2.Register[0], f[i]);
                R3.Register[0] = R3.XOR(R3.Register[0], f[i]);
                R4.Register[0] = R4.XOR(R4.Register[0], f[i]);

            }

            R1.SetElement(15,'1');
            R2.SetElement(16, '1');
            R3.SetElement(18, '1');
            R4.SetElement(10, '1');

            return true;
        }

        public byte[] GenerateRandomIV()
        {
            //Random rnd = new Random();
            //byte[] ret = new byte[22];
            //for (int i = 0; i < 22; i++)
            //    ret[i] = rnd.Next(0, 11) > 5 ? (byte)1 : (byte)0;
            //return ret;

            int pom;
            Random rand = new Random();

            byte[] rKey = new byte[22];

            for (int i = 0; i < 22; i++)
            {
                pom = rand.Next(35, 125);
                rKey[i] = (byte)pom;
            }

            //SetIV(rKey);

            return rKey;
        }

        public bool SetAlgorithmProperties(IDictionary<string, byte[]> specArguments)
        {
            throw new NotImplementedException();
        }

        public byte[] Crypt(byte[] input)
        {
            char[] K = getByteBinaryString(input).ToCharArray();
            char[] outchar = new char[K.Count()];
            byte[] output = new byte[input.Count()];

            for (int i = 0; i < 100; i++ )
            {
                SH();
            }

            for (int i = 0; i < K.Count(); i++ )
            {
                SH();
                char pom = R1.GetMajority();
                pom = R1.XOR(pom,R1.GetLastElement);
                pom = R2.XOR(pom, R2.GetMajority());
                pom = R2.XOR(pom,R2.GetLastElement);
                pom = R3.XOR(pom, R3.GetMajority());
                pom = R3.XOR(pom, R3.GetLastElement);
                pom = R3.XOR(pom, K[i]);

                outchar[i] = pom;
            }

            StringBuilder sb = new StringBuilder();
            for(int i=0; i< input.Count(); i++)
            {
                
                String s=new String(outchar,i*8,8);
                output[i] = Convert.ToByte(s, 2);
            }

            

            return output;
        }

        private void SH()
        {
            if (R1.GetMajority() == R4.GetElement(clockBits[0]))
            {
                R1.Shift();
            }

            if (R2.GetMajority() == R4.GetElement(clockBits[1]))
            {
                R2.Shift();
            }

            if (R3.GetMajority() == R4.GetElement(clockBits[2]))
            {
                R3.Shift();
            }

            R4.Shift();
        }

        public byte[] Decrypt(byte[] output)
        {
            return Crypt(output);
        }
    }
}

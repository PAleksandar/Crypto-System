using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class TigerHash: ICryptoAlgorithm
    {
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
            throw new NotImplementedException();
        }

        public byte[] GenerateRandomIV()
        {
            throw new NotImplementedException();
        }

        public bool SetAlgorithmProperties(IDictionary<string, byte[]> specArguments)
        {
            throw new NotImplementedException();
        }

        public byte[] Crypt(byte[] input)
        {
            throw new NotImplementedException();
        }

        public byte[] Decrypt(byte[] output)
        {
            throw new NotImplementedException();
        }

        public byte[] Hash(byte[] input)
        {
            ulong h0 = 0x0123456789ABCDEF;
            ulong h1 = 0xFEDCBA9876543210;
            ulong h2 = 0xF096A5B4C3D2E187;


            //preprocesiranje
            int velicinaDela = 64; //64Byte = 512bit
            byte[] message = input;
            int count=input.Count();
            int lengthOfUnpaddedMessage = 8; //64bit

            int mod = (count + lengthOfUnpaddedMessage) % velicinaDela;  //64Byte = 512bit  

            if(mod!=0)
            {
                int dopuna = velicinaDela - mod;
                byte[] pom = new byte[dopuna];

                String s = "10000000";
                pom[0] = Convert.ToByte(s, 2);
                dopuna--;

                s = "00000000";
                for (int i = 1; i < dopuna+1; i++ )
                {
                    pom[i] = Convert.ToByte(s, 2);
                }

                message = message.Concat(pom).ToArray();      
                    
            }

            if (BitConverter.IsLittleEndian)
            {
                double co = count;
                byte [] duzina = BitConverter.GetBytes(co);
                message = message.Concat(duzina).ToArray();   
               // convertedFromBytes = BitConverter.ToDouble(duzina, 0);
            }
            else
            {
                byte[] b = new byte[1];
                return b;
            }


            ///procesiranje poruke kao niz 512 bitnih blokova

            double d = message.Count()/velicinaDela;  //64byte 512bits
            for (int l = 0; l < d; l++ )
            {
                byte[] wpom = message.Skip(l * 64).Take(64).ToArray();
                ulong[] w= new ulong [8];

                Int64 dm;
                for(int k=0; k<8; k++)
                {
                    dm = BitConverter.ToInt64(wpom, k*8);
                    w[k] = Convert.ToUInt64(dm);
                }
                
                

                
               

                ulong a = h0;
                ulong b = h1;
                ulong c = h2;

                for(int i=0; i<4; i++)
                {
                    for(int j=0; j<8; j++)
                    {
                       
                        c = c ^ w[j];

                        byte[] cNiz = BitConverter.GetBytes(c);

                      
                        a = a - (SBox.s1[(int)cNiz[0]] ^ SBox.s2[(int)cNiz[2]] ^ SBox.s3[(int)cNiz[4]] ^ SBox.s4[(int)cNiz[6]]);
                        b = b + (SBox.s4[(int)cNiz[1]] ^ SBox.s3[(int)cNiz[3]] ^ SBox.s2[(int)cNiz[5]] ^ SBox.s4[(int)cNiz[7]]);
                        b=b*(Convert.ToUInt64(i)+1);
                        
                    }

                    if(i==0)
                    {
                            w[0] = w[0] - (w[7] ^ 0xA5A5A5A5A5A5A5A5);
                            w[1] = w[1] ^ w[0];
                            w[2] = w[2] + w[1];
                            w[3] = w[3] - (w[2] ^ ((w[1] ^ 0xFFFFFFFFFFFFFFFF)<< 19));
                            w[4] = w[4] ^ w[3];
                            w[5] = w[5] + w[4];
                            w[6] = w[6] - (w[5] ^ ((w[4] ^ 0xFFFFFFFFFFFFFFFF)>> 23));
                            w[7] = w[7] ^ w[6];
                        
                        
                    }
                    else if(i==1)
                    {
                           w[0] = w[0] + w[7];
	                       w[1] = w[1] - (w[0] ^ ((w[0] ^ 0xFFFFFFFFFFFFFFFF)<< 19));
	                       w[2] = w[2] ^ w[1];
                           w[3] = w[3] + w[2];
                           w[4] = w[4] - (w[3] ^ ((w[2] ^ 0xFFFFFFFFFFFFFFFF)>> 23));
                           w[5] = w[5] ^ w[4];
                           w[6] = w[6] + w[5];
                           w[7] = w[7] - (w[6] ^ 0x0123456789ABCDEF);

                    }
                }
                   

                h0 = h0 + a;
                h1 = h1 + b ;
                h2 = h2 + c;

            }

                //h0 append h1 append h2 
            byte[] res=BitConverter.GetBytes(h0);
            res=res.Concat(BitConverter.GetBytes(h1)).ToArray();
            res=res.Concat(BitConverter.GetBytes(h2)).ToArray();

                return res;
        }
    }
}

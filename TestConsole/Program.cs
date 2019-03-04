using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crypto;

namespace TestConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // RSA rsa = new RSA();
           // rsa.init(17, 23);
           // String s = "Hellooo world!!!";
           // byte[] input = System.Text.Encoding.ASCII.GetBytes(s);

           // byte[] iv = rsa.GenerateRandomIV();

           // byte[] cript1 = rsa.Crypt1(input); 
           // byte[] cript = rsa.CryptBlock(input);

           // rsa.init(17,23);
           // byte[] decrypt1 = rsa.DecryptBlock(cript1);

           // String i1 = System.Text.Encoding.ASCII.GetString(iv);
           // String r1 = System.Text.Encoding.ASCII.GetString(cript);
           // String r2 = System.Text.Encoding.ASCII.GetString(decrypt1);

           // Console.WriteLine("cripr length: "+cript.Count());
           // Console.WriteLine("input length: "+input.Count());
           // Console.WriteLine("r1: "+r1);
           //// Console.WriteLine("r2: "+r2);
           // Console.ReadLine();

            Crypto.A5_2 a5 = new A5_2();
            byte[] key = a5.GenerateRandomKey();
            byte[] iv = a5.GenerateRandomIV();

            a5.SetKey(key);
            a5.SetIV(iv);

            String s = "Hellooo world test !!!";
            byte[] input = System.Text.Encoding.Unicode.GetBytes(s);
            byte[] cript = a5.Crypt(input);

            String cr = System.Text.Encoding.Unicode.GetString(cript);
            byte[] crb = System.Text.Encoding.Unicode.GetBytes(cr);

           // Crypto.A5_2 a52 = new A5_2();
            a5.SetKey(key);
            a5.SetIV(iv);
            byte[] decrypt = a5.Decrypt(crb);
            String res = System.Text.Encoding.Unicode.GetString(decrypt);

            Console.WriteLine("key: " + res);
            //Console.WriteLine("Length: " + key.Count());
            Console.ReadLine();
        }

        void Main33(string[] args)
        {
            Crypto.A5_2 a5 = new A5_2();
            byte[] key = a5.GenerateRandomKey();
           // byte[] iv = a5.GenerateRandomIV();

            a5.SetKey(key);
           // a5.SetIV(iv);

            String s = "Hellooo world!!!";
            byte[] input = System.Text.Encoding.ASCII.GetBytes(s);
            byte[] cript = a5.Crypt(input);

            Crypto.A5_2 a52 = new A5_2();
            a52.SetKey(key);
            //a52.SetIV(iv);
            byte[] decrypt = a52.Crypt(cript);
            String res = System.Text.Encoding.ASCII.GetString(decrypt);

            RC4 rc4 = new RC4();
            byte[] iv = rc4.GenerateRandomIV();

            int counter = 1;
           // byte[] iv;
            byte[] output = new byte[input.Length];
            int IVCounterLength = iv.Count() + sizeof(int);
            byte[] ctr = BitConverter.GetBytes(counter);
            byte[] IVCounter = { };
            IVCounter = IVCounter.Concat(iv).ToArray();
            IVCounter = IVCounter.Concat(ctr).ToArray();

            byte byte1 = 10;
            byte byte2 = 20;
          //  byte1[1] = byte1[1] ^ byte2[6];
            byte r = (byte)((byte1 >> 1 & 1) ^ (byte2 >> 6 & 1));

            byte[] b = System.Text.Encoding.ASCII.GetBytes("he lo");
            Console.WriteLine("Length: " + b.Count());
            Console.ReadLine();
        }

         void Main15(string[] args)
        {
            //double h = 0x000000000000001A;
            //byte[] b=System.Text.Encoding.ASCII.GetBytes("helloooWorld");
            //byte[] b2 = System.Text.Encoding.ASCII.GetBytes("test");
            //b = b.Concat(b2).ToArray();
            //byte pom = Convert.ToByte("10000000",2);
            //String s = System.Text.Encoding.ASCII.GetString(b);

            //String s = "10";
            //byte[] pom=new byte[2]; //= Convert.ToByte("10000000", 2);
           // byte[] pom = System.Text.Encoding.ASCII.GetBytes(s,2);
           // pom[0] = Convert.ToByte(s, 10);

            //message = message.Concat(pom).ToArray();

            int dopuna = 3;
            byte[] pom = new byte[dopuna];

            String s = "10000000";
            pom[0] = Convert.ToByte(s, 2);
            dopuna--;

            s = "00000000";
            for (int i = 1; i < dopuna + 1; i++)
            {
                pom[i] = Convert.ToByte(s, 2);
            }

            byte[] duzina = System.Text.Encoding.Unicode.GetBytes("3545");
            double convertedFromBytes=0;

            if (BitConverter.IsLittleEndian)
            {
                double someInteger = 123456;
                duzina = BitConverter.GetBytes(someInteger);
                convertedFromBytes = BitConverter.ToDouble(duzina, 0);
            }

            String str = "Hell";
            byte [] p = System.Text.Encoding.BigEndianUnicode.GetBytes(str);

            Int64 ts = BitConverter.ToInt64(p,0);
            UInt64 te = Convert.ToUInt64(ts);

            double x1 = 10;
            double x2 = 20;

            ulong p1 = 0x000000000000000A;
            ulong p2 = 0x0000000000000009;
            ulong p3 = p1 ^ p2;

            ulong tst=SBox.s1[0];

            ulong vIn = 0xFFFFFFFFFFFFFFFFUL;
            byte[] vOut = System.Text.Encoding.BigEndianUnicode.GetBytes("Test hash function");

            //Crypto.TigerHash tg = new TigerHash();
            //ulong testHash = tg.Hash(vOut);

            byte bp = Convert.ToByte("00111111", 2);
            byte bp2 = Convert.ToByte("00011000", 2);
            byte[] btest = new byte[2];
            btest[0] = bp;
            btest[1] = bp2;
           // bp = (byte)(bp >> 1);//& 0xff
            String stri=getByteBinaryString(btest);
            char[] ch = stri.ToCharArray();

            String stringpom = new String(ch,8,8);
            byte[] rb = GenerateRandomKey();
            Console.WriteLine("count= " + stringpom);
            for (int i = 0; i < 16; i++ )
            { 
            //    Console.WriteLine("Value= " + ch[i]);
            }
           // Console.WriteLine("Hash output: {0:X}", testHash);
            Console.ReadLine();
        }

        public static byte[] GenerateRandomKey()
        {
            Random rnd = new Random();
            byte[] ret = new byte[64];
            for (int i = 0; i < 64; i++)
                ret[i] = rnd.Next(0, 11) > 5 ? (byte)1 : (byte)0;
            return ret;
        }

        public static String getByteBinaryString(byte[] bs)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bs.Count(); i++)
            {
                sb.Append(getByteBinaryString(bs[i]));
            }

            return sb.ToString();
        }

        public static String getByteBinaryString(byte b)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 7; i >= 0; --i)
            {
                sb.Append(b >> i & 1);

            }
            return sb.ToString();

        }

        String byteToBinaryString(byte b){
    StringBuilder binaryStringBuilder = new StringBuilder();
    for(int i = 0; i < 8; i++)
        binaryStringBuilder.Append(((0x80 >> i) & b) == 0? '0':'1');
    return binaryStringBuilder.ToString();
}

        public byte[] INT2LE(int data)
        {
            byte[] b = new byte[4];
            b[0] = (byte)data;
            b[1] = (byte)(((uint)data >> 8) & 0xFF);
            b[2] = (byte)(((uint)data >> 16) & 0xFF);
            b[3] = (byte)(((uint)data >> 24) & 0xFF);
            return b;
        }

        static void Main3(string[] args)
        {
           // byte[] b = { '1', 'B' ,'48'};
            string s = "57041326";
            char[] c=s.ToCharArray();
            byte[] key = System.Text.Encoding.ASCII.GetBytes(s);
            // byte t= Convert.ToByte("3",10);
            byte t2 = Convert.ToByte(c[2]);

            char[] ch=new char[8];
            
            Random rand = new Random();
            int [] k =new int[8];
            byte[] by=new byte[8];

            for (int i = 0; i < 8; i++ )
            {
                k[i] = rand.Next(35,125);
                ch[i]=(char)k[i];
                by[i] = (byte)k[i];
                Console.WriteLine("int "+k[i]);
                Console.WriteLine("char "+ch[i]);
                Console.WriteLine("byte " + by[i]);

            }

            byte[] result = new byte[k.Length * sizeof(int)];
            Buffer.BlockCopy(k, 0, result, 0, result.Length);

            Buffer.BlockCopy(result, 0, k, 0, k.Length);

            Console.WriteLine("byte []");
            for (int i = 0; i < 8; i++ )
            {
                
                Console.WriteLine(result[i]);

            }

            Console.WriteLine("int []");
            for (int i = 0; i < 8; i++)
            {

                Console.WriteLine(k[i]);

            }


           



           

                
            Console.ReadLine();
           // proxy.RC4SetKey(key);
        }

        void Main2(string[] args)
        {
            //RC4 rc = new RC4();
            
           // byte[] bytes = Encoding.ASCII.GetBytes(someString);

            //byte c1 = Convert.ToByte("00110001", 2);
            //byte c2 = Convert.ToByte("00110100", 2);
            //byte c3 = Convert.ToByte("00110011", 2);
            //byte c4 = Convert.ToByte("00110110", 2);
            //byte c5 = Convert.ToByte("00110000", 2);
            //byte c1 = Convert.ToByte('H');
            //byte c2 = Convert.ToByte('e');
            //byte c3 = Convert.ToByte('l');
            //byte c4 = Convert.ToByte('l');
            //byte c5 = Convert.ToByte('o');
            //byte[] input = { c1,c2,c3,c4,c5 };
            //byte[] output=new byte[5];
            //byte[] output2 = new byte[5];

            //byte[] key = {5,7,0,4,1,3,2,6 };//Convert.ToByte("5", 10);

            //rc.SetKey(key);
           
            //for (int i = 0; i < 5;i++ )
            //{
            //    Console.Write(Convert.ToString(input[i], 2));
            //    Console.WriteLine();
            //}

            //output = rc.Crypt(input);
            //Console.WriteLine("rezultat kriptovanja");
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write(Convert.ToChar(output[i]));
            //    Console.WriteLine();
            //}


            //Console.WriteLine("dekriptovanje");
            //output2 = rc.Crypt(output);

            //Console.WriteLine("rezultat dekriptovanja");
            //for (int i = 0; i < 5; i++)
            //{
            //    //Console.Write(Convert.ToString(output2[i]));
            //    Console.Write(Convert.ToChar(output2[i]));
            //    Console.WriteLine();
            //}
               
           // byte c5 = Convert.ToByte(5);
            //Console.Write(Convert.ToString(c5));
            //Console.Write(c5);

         //static void test6(byte w, byte x, byte y, byte z)


            //////////////////////////////// RSA 1

            //int data = 607;
            //byte[] bytes = new byte[4];
            //{
            //    bytes[0] = (byte)(data >> 24);
            //    bytes[1] = (byte)(data >> 16);
            //    bytes[2] = (byte)(data >> 8);
            //    bytes[3] = (byte)(data);
            //}

            //for (int i = 0; i < 4;i++ )
            //{
            //    Console.Write(Convert.ToString(bytes[i]));
            //    Console.WriteLine();

            //}

            //Console.WriteLine("---------------------");
            //{
            //    int res = 0;
            //    var timer = System.Diagnostics.Stopwatch.StartNew();
            //    // var b = new byte[] { 0, 0, 1, 7 };
            //    var b = bytes;
            //    //for (int i = 0; i < iters; i++)
            //    //res = b[0] | (b[1]) | (b[2]) | (b[3]);
            //    res = b[0] << 24 | (b[1] << 16) | (b[2] << 8) | (b[3]);
            //    Console.WriteLine("test6: " + timer.Elapsed + " " + res);
            //}
            
            //int p=(bytes[3] * bytes[2]);
            //Console.WriteLine("res: " +p);

            /////////////!!!!!!!!!??????????????????????????????????????!!!!!!!!!

           // RSA rsa = new RSA();
            //rsa.init(17,23);
            String text = "Hello world";
            byte[] input = System.Text.Encoding.ASCII.GetBytes(text);
            //byte[] res=rsa.Crypt(input);
            String rezultat = System.Text.Encoding.ASCII.GetString(input);

            //Console.WriteLine("Rezultat kriptovanja"+rezultat);


            //byte[] resDecrypt=rsa.Decrypt(res);
            //String rezultat2=System.Text.Encoding.ASCII.GetString(resDecrypt);
            //Console.WriteLine("Rezultat dekriptovanja" + rezultat2);


            //Console.WriteLine( rezultat);
            //byte[] b1 = input.Take(5).ToArray();
            //input = input.Skip(5).Take(6).ToArray();
            //rezultat = System.Text.Encoding.ASCII.GetString(b1);
            //Console.WriteLine(rezultat);
            //rezultat = System.Text.Encoding.ASCII.GetString(input);
            //Console.WriteLine(rezultat);

            String file = "c\\Desktop\\fajl.txt.cryptor";

            string[] path = file.Split('\\');
            string[] name = path.Last().Split('.');

            //string[] n = name.Take(name.Length-1).ToArray();

            //Console.WriteLine(file);
            //Console.WriteLine(path.Last());
            //Console.WriteLine(name.Last());
           // Console.WriteLine(n);

            if (name.Last().Equals("crypto"))
            {
                Console.WriteLine("Kriptovan fajl");
            }
           // string newName = path.Last() + ".crypt";
            //string newPath = _destinationPath + "\\" + newName;

            string test1 = "0123456";

            // ... Start removing at index 3.
            string result1 = test1.Remove(3);

            // ... Displays the first three characters.
            Console.WriteLine(test1);


            Console.ReadLine();

            
        }
    }
}

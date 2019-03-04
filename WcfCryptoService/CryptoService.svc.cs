using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Crypto;

namespace WcfCryptoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CryptoService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CryptoService.svc or CryptoService.svc.cs at the Solution Explorer and start debugging.
    public class CryptoService : ICryptoService
    {

        static RC4 rc4;
        static RSA rsa;
        static A5_2 a5_2;
        static TigerHash tiger;

        static private string algoritam;
        static private string fileName;
        static private int brPaketa = 0;
        static private byte[] Msg = { };
        static private byte[] CryptMsg = { };
        private byte[] pom={};
        static int brojac = 3;

        private int velicinaPaketa = 4000;
        static private int brCelihPaketa;
        static private bool ostatak=false;
        static private int brDekriptovanihPaketa = 0;
        static private byte[] KriptovanFile;
        static private bool ZapocetoDekriptovanje = false;

        

        public CryptoService()
        {
            if(rc4==null)
            {
                rc4 = new RC4();
            }

            if(rsa==null)
            {
                rsa = new RSA();
                //rsa.init(17, 23);
            }

            if (a5_2 == null)
            {
                a5_2 = new A5_2();
            }
            
            

        }

        /////RSA ---------------------------------------------------------
      
       public byte[] RSACrypt(byte[] input)
        {
           // RSA rsa = new RSA();
           // rsa.init(17, 23);
            return rsa.Crypt(input);
           
        }

       public byte[] RSADecrypt(byte[] input)
       {
           //RSA rsa = new RSA();
          // rsa.init(17, 23);
           return rsa.Decrypt(input);

       }

       public byte[] RSACryptCTR(byte[] input)
       {
           // RSA rsa = new RSA();
           // rsa.init(17, 23);
           return rsa.CryptCTR(input);

       }

       public byte[] RSADecryptCTR(byte[] input)
       {
           //RSA rsa = new RSA();
           // rsa.init(17, 23);
           return rsa.DecryptCTR(input);

       }

       public bool RSASetIV(byte[] input)
       {
           rsa.SetIV(input);
           return true;
       }

       public byte[] RSAGenerateRandomIV()
       {
           return rsa.GenerateRandomIV();
       }

       public bool RSASetAlgorithmProperties(IDictionary<string, byte[]> specArguments)
       {
           return rsa.SetAlgorithmProperties(specArguments);
       }

       /////end RSA ---------------------------------------------------------
      

       /////RC4 ---------------------------------------------------------
       public byte[] RC4Crypt(byte[] input)
       {
           return rc4.Crypt(input);
       }

       public byte[] RC4CryptCTR(byte[] input)
       {
           return rc4.CryptCTR(input);
       }

       public byte[] RC4Decrypt(byte[] input)
       {
           return rc4.Decrypt(input);
       }

       public byte[] RC4DecryptCTR(byte[] input)
       {
           return rc4.DecryptCTR(input);
       }

       public bool RC4SetKey(byte[] input)
       {
           rc4.SetKey(input);
           return true;
       }

       public byte[] RC4GenerateRandomKey()
       {
           return rc4.GenerateRandomKey();
       }

       public bool RC4SetIV(byte[] input)
       {
           rc4.SetIV(input);
           return true;
       }

       public byte[] RC4GenerateRandomIV()
       {
           return rc4.GenerateRandomIV();
       }

       public bool RC4SetAlgorithmProperties(IDictionary<string, byte[]> specArguments) 
       {
           return rc4.SetAlgorithmProperties(specArguments);
       }

       /////end RC4------------------------------------------------------------------------

       /////A5/2 ---------------------------------------------------------

       public byte[] A5_2Crypt(byte[] input)
       {
           byte[] res=a5_2.Crypt(input);
          // a5_2 = null;
           return res;
       }

       public byte[] A5_2Decrypt(byte[] input)
       {
           byte[] res = a5_2.Decrypt(input);
          // a5_2 = null;
           return res;
       }

       public bool A5_2SetKey(byte[] input)
       {
           a5_2.SetKey(input);
           return true;
       }

       public byte[] A5_2GenerateRandomKey()
       {
           return a5_2.GenerateRandomKey();
       }

       public bool A5_2SetIV(byte[] input)
       {
           a5_2.SetIV(input);
           return true;
       }

       public byte[] A5_2GenerateRandomIV()
       {
           return a5_2.GenerateRandomIV();
       }

       /////end A5/2---------------------------------------------------------

       public byte[] TigerHash(byte[] input)
       {
           TigerHash tg = new TigerHash();
           return tg.Hash(input);
       }

       /////Clou ---------------------------------------------------------

       private void TigerUpload()
       {

       }

       public void Upload(byte[] input)
       {
           string path="C:\\Users\\Aca\\Desktop\\Cloud\\";
           if(brojac==3)
           {
               fileName = System.Text.Encoding.ASCII.GetString(input);
               brojac--;
              // System.IO.File.WriteAllBytes(fileName, input);
           }
           else if (brojac == 2)
           {
               algoritam = System.Text.Encoding.ASCII.GetString(input);
               brojac--;
               
           }
           else if (brojac == 1)
           {
               brPaketa = Convert.ToInt32(System.Text.Encoding.ASCII.GetString(input));
               brojac--;
               return;
           }
           
           if (brPaketa > 0)
           {
               
              // Msg = Msg.Concat(input).ToArray();
               if(algoritam=="rc4")
               {
                   CryptMsg = CryptMsg.Concat(rc4.Crypt(input)).ToArray();
               }
               else if (algoritam == "rc4CTR")
               {
                   CryptMsg = CryptMsg.Concat(rc4.CryptCTR(input)).ToArray();
               }
               else if(algoritam=="rsa")
               {
                   CryptMsg = CryptMsg.Concat(rsa.Crypt(input)).ToArray();
               }
               else if (algoritam == "rsaCTR")
               {
                   CryptMsg = CryptMsg.Concat(rsa.CryptCTR(input)).ToArray();
               }
               else if (algoritam == "a5_2")
               {
                   CryptMsg = CryptMsg.Concat(a5_2.Crypt(input)).ToArray();
               }
               //else if (algoritam == "tiger")
               //{
               //    CryptMsg = CryptMsg.Concat(tiger.Crypt(input)).ToArray();
               //}
               else
               {
                   return;
               }
               
               brPaketa--;
               if(brPaketa==0)
               {
                   System.IO.File.WriteAllBytes(path+fileName+"."+algoritam, CryptMsg);
                  // System.IO.File.WriteAllBytes(path + fileName, Msg);
                   brojac = 3;
                   CryptMsg = pom;
                  // Msg = pom;
               }
           }

       }
        
        public string[] GetFiles()
       {
            string path = "C:\\Users\\Aca\\Desktop\\Cloud\\";
            string[] dirs = System.IO.Directory.GetFiles(path, "*.*");

            int count = dirs.Count();
            string[] p;
            string Name;
            string[] files= new string[count];

           
                for (int i = 0; i < count; i++ )
                {
                    p = dirs[i].Split('\\');
                    Name = p.Last();
                    files[i] = Name;

                }

            
            //string[] s = { "file 1", "file 2", "file 3" };
            return files;
       }

        public void DeleteFile(string name)
        {
            string path = "C:\\Users\\Aca\\Desktop\\Cloud\\";
            string[] dirs = System.IO.Directory.GetFiles(path, "*.*");

            string[] p;
            string Name;
            foreach(string file in dirs)
            {
                p = file.Split('\\');
                Name = p.Last();
                if(Name.Equals(name))
                {
                    System.IO.File.Delete(file);
                    return;
                }
            }
        }

        public byte[] Download(string fileName, string al)
        {
            if (!ZapocetoDekriptovanje)
            {
                string path = "C:\\Users\\Aca\\Desktop\\Cloud\\" + fileName;
                KriptovanFile = System.IO.File.ReadAllBytes(path);

               
                brCelihPaketa = KriptovanFile.Length / velicinaPaketa;
                int ukupnoPaketa = brCelihPaketa;
                if (KriptovanFile.Length % velicinaPaketa != 0)
                {
                    ostatak = true;
                    ukupnoPaketa++;
                }
                ZapocetoDekriptovanje = true;
                byte[] o = System.Text.Encoding.ASCII.GetBytes("" + ukupnoPaketa);
                return o;

            }
            else
            {
                byte[] tmpDeo;
                byte[] decryptedMsgDeo;
             //   byte[] cryptedMsg = { };

                if(brDekriptovanihPaketa<brCelihPaketa)
                {
                    tmpDeo = KriptovanFile.Skip(brDekriptovanihPaketa * velicinaPaketa).Take(velicinaPaketa).ToArray();
                    if (al == "rc4")
                    {
                        decryptedMsgDeo = rc4.Decrypt(tmpDeo);
                    }
                    else if (al == "rc4CTR")
                    {
                        decryptedMsgDeo = rc4.DecryptCTR(tmpDeo);
                    }
                    else if (al == "rsa")
                    {
                        decryptedMsgDeo = rsa.Decrypt(tmpDeo);
                    }
                    else if (al == "rsaCTR")
                    {
                        decryptedMsgDeo = rsa.DecryptCTR(tmpDeo);
                    }
                    else //if (al == "a5_2")
                    {
                        decryptedMsgDeo = a5_2.Decrypt(tmpDeo);
                    }
                    
                    
                    brDekriptovanihPaketa++;
                    return decryptedMsgDeo;
                   // return tmpDeo;
                }
                else if(ostatak)
                {
                    tmpDeo = KriptovanFile.Skip(brCelihPaketa * velicinaPaketa).Take(KriptovanFile.Length - brCelihPaketa * velicinaPaketa).ToArray();
                    if (al == "rc4")
                    {
                        decryptedMsgDeo = rc4.Decrypt(tmpDeo);
                    }
                    else if (al == "rc4CTR")
                    {
                        decryptedMsgDeo = rc4.DecryptCTR(tmpDeo);
                    }
                    else if (al == "rsa")
                    {
                        decryptedMsgDeo = rsa.Decrypt(tmpDeo);
                    }
                    else if (al == "rsaCTR")
                    {
                        decryptedMsgDeo = rsa.DecryptCTR(tmpDeo);
                    }
                    else //if (al == "a5_2")
                    {
                        decryptedMsgDeo = a5_2.Decrypt(tmpDeo);
                    }

                    ostatak = false;
                    ZapocetoDekriptovanje = false;
                    brDekriptovanihPaketa = 0;

                    return decryptedMsgDeo;
                    //return tmpDeo;
                }

                return null;
            }

        }

        public void Update(byte[] input)
        {

        }
    }
}

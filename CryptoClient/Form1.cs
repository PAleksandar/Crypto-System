using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using CryptoClient.CryptoServiceReference1;


using Buffer;
using System.IO;

namespace CryptoClient
{
    public partial class Form1 : Form
    {
        CryptoServiceReference1.CryptoServiceClient proxy;
        
        private string _sourcePath="C:\\Users\\Aca\\Desktop\\R3";
        private string _destinationPath = "C:\\Users\\Aca\\Desktop\\Cloud";
        private string _keyPath;
        private bool _tread = true;
        private DateTime _lastTimeRun;
        private string _sourcePathCloud = "C:\\Users\\Aca\\Desktop\\R3";
        private string selectedAlgorithm = "rc4";

        private byte[] keyA5;
        private byte[] ivA5;
        private bool a5Set = false;
        private byte[] kriptovanTextA5;

        MyQueue queue;
        Thread newThread;
        Thread newThreadCloud;

        public Form1()
        {
            InitializeComponent();
            proxy = new CryptoServiceReference1.CryptoServiceClient();


            queue = new MyQueue();

            fileSystemWatcher1.EnableRaisingEvents = false;
            cbFileSysWatc.Checked = false;
            this.ReadLastTimeRun();
        }

        private void ReadLastTimeRun()
        {
            this._lastTimeRun = new DateTime();

            try
            {
                using (StreamReader reader = new StreamReader("vreme.txt"))
                {
                    this._lastTimeRun = DateTime.Parse(reader.ReadLine());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private bool Set()
        {
            // Key
            if (this.tbxRC4Key.Text != "")
            {
                byte[] key = System.Text.Encoding.ASCII.GetBytes(this.tbxRC4Key.Text);
                proxy.RC4SetKey(key);
            }
            else
            {
                MessageBox.Show("Unesite kljuc");
                return false;
            }

            //Properties
            if (this.tbxRC4i.Text == "")
            {
                
                this.tbxRC4i.Text = "3";
                
                
            }
            byte[] pi = BitConverter.GetBytes(Int32.Parse(this.tbxRC4i.Text));

            if (this.tbxRC4j.Text == "")
            {
                this.tbxRC4j.Text = "4";

            }
            byte[] pj = BitConverter.GetBytes(Int32.Parse(this.tbxRC4j.Text));
            

            Dictionary<string, byte[]> prop = new Dictionary<string, byte[]>();
            prop.Add("i", pi);
            prop.Add("j", pj);
            proxy.RC4SetAlgorithmProperties(prop);

            if(checkBoxCTR.Checked)
            {
                if (this.tbxIV.Text != "")
                {
                    byte[] key = System.Text.Encoding.ASCII.GetBytes(this.tbxRC4Key.Text);
                    proxy.RC4SetIV(key);
                }
                else
                {
                    MessageBox.Show("Unesite IV");
                    return false;
                }
            }


            return true;
            //
        }


        private bool SetRSA()
        {
            

            //Properties
            if (this.tbxRSAp.Text == "")
            {

                this.tbxRSAp.Text = "17";


            }
            byte[] pi = BitConverter.GetBytes(Int32.Parse(this.tbxRSAp.Text));

            if (this.tbxRSAq.Text == "")
            {
                this.tbxRSAq.Text = "23";

            }
            byte[] qi = BitConverter.GetBytes(Int32.Parse(this.tbxRSAq.Text));


            Dictionary<string, byte[]> prop = new Dictionary<string, byte[]>();
            prop.Add("p", pi);
            prop.Add("q", qi);
            proxy.RSASetAlgorithmProperties(prop);

            if (this.checkBoxRSACTR.Checked)
            {
                if (this.tbxRSAIV.Text != "")
                {
                    byte[] key = System.Text.Encoding.ASCII.GetBytes(this.tbxRSAIV.Text);
                    proxy.RSASetIV(key);
                }
                else
                {
                    MessageBox.Show("Unesite IV");
                    return false;
                }
            }


            return true;
            //
        }

        private bool SetA5_2()
        {
            
                // Key
                if (this.tbxA5Key.Text != "")
                {
                    byte[] key = System.Text.Encoding.ASCII.GetBytes(this.tbxA5Key.Text);
                    proxy.A5_2SetKey(this.keyA5);
                }
                else
                {
                    MessageBox.Show("Unesite kljuc");
                    return false;
                }

                // IV
                if (this.tbxA5IV.Text != "")
                {
                    byte[] iv = System.Text.Encoding.ASCII.GetBytes(this.tbxA5IV.Text);
                    proxy.A5_2SetIV(this.ivA5);
                }
                else
                {
                    MessageBox.Show("Unesite kljuc");
                    return false;
                }

                


            return true;
            //
        }
       
        private void btnRSACrypt_Click(object sender, EventArgs e)
        {
            byte[] input = System.Text.Encoding.ASCII.GetBytes(this.tbxRSASource.Text);
            byte[] res = System.Text.Encoding.ASCII.GetBytes("");

            if(selectedAlgorithm.Equals("rc4"))
            {
                bool setovano = Set();

                if (!setovano)
                {
                    return;
                }

                

                if(checkBoxCTR.Checked)
                {
                    res = proxy.RC4CryptCTR(input);
                }
                else
                {
                    res = proxy.RC4Crypt(input);
                }
            }
            else if(selectedAlgorithm.Equals("rsa"))
            {
                bool setovano = SetRSA();

                if (!setovano)
                {
                    return;
                }

                if (checkBoxRSACTR.Checked)
                {
                    res = proxy.RSACryptCTR(input);
                }
                else
                {
                    res = proxy.RSACrypt(input);
                }

                
            }
            else if (selectedAlgorithm.Equals("a5_2"))
            {
                bool setovano = SetA5_2();

                if (!setovano)
                {
                    return;
                }

               // MessageBox.Show("Setovan kljuc");
                input = System.Text.Encoding.Unicode.GetBytes(this.tbxRSASource.Text);
                res = proxy.A5_2Crypt(input);
               // this.kriptovanTextA5 = res;

                String r = System.Text.Encoding.Unicode.GetString(res);

                this.tbxRSAResult.Text = r;
                return;

            }


            String rezultat = System.Text.Encoding.ASCII.GetString(res);

            this.tbxRSAResult.Text = rezultat;
            

        }

        private void rbCrypt_CheckedChanged(object sender, EventArgs e)
        {
            gbPath.Enabled = true;
        }

        private void rbDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            gbPath.Enabled = true;
        }

        private void btnSource_Click(object sender, EventArgs e)
        {
            btnDestination.Enabled = true;

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {

                _sourcePath = fbd.SelectedPath;
               
                fileSystemWatcher1.Path = _sourcePath;
            }
        }

        private void btnDestination_Click(object sender, EventArgs e)
        {
           // btnKey.Enabled = true;
           // btnStart.Enabled = true;

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {

                _destinationPath = fbd.SelectedPath;
               
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DateTime dt = DateTime.Now;
            try
            {
                using (StreamWriter time = new StreamWriter("vreme.txt"))
                {
                    time.WriteLine(dt);
                }
            }
            catch (Exception)
            {

            }
            Console.Write("Datum " + dt.ToString() + " je sacuvan u vreme.txt\n");
           // myTimer.Stop();
            _tread = false;
        }

        public void _SysWatcherChecking()
        {
            if (this._sourcePath != null)
            {
                string[] dirs = System.IO.Directory.GetFiles(this._sourcePath, "*.*");

                foreach (string f in dirs)
                {
                    FileInfo fi = new FileInfo(f);
                    DateTime dt = fi.LastAccessTime;


                   // if (DateTime.Compare(this._lastTimeRun, dt) < 0)
                    {
                        queue.addInQueue(f); //f - File path
                    }
                }
                _lastTimeRun = DateTime.Now;
            }
            else
            {
                MessageBox.Show("Unesite izvorni direktorijum");
            }
        }

        private bool Validate()
        {
            bool setovano=false;
            if (selectedAlgorithm.Equals("rc4"))
            {
                 setovano = Set();



                if (!setovano)
                {
                    MessageBox.Show("Unesite kljuc");
                   // cbFileSysWatc.Checked = false;
                    return setovano;
                }
            }
            else if (selectedAlgorithm.Equals("rsa"))
            {
                 setovano = SetRSA();

                if (!setovano)
                {
                    MessageBox.Show("Unesite kljuc");
                    //cbFileSysWatc.Checked = false;
                    return setovano;
                }
            }
            else if (selectedAlgorithm.Equals("a5_2"))
            {
                 setovano = SetA5_2();

                if (!setovano)
                {
                    MessageBox.Show("Unesite kljuc");
                    //cbFileSysWatc.Checked = false;
                    return setovano;
                }
            }

            return setovano;
        }

        private void cbFileSysWatc_CheckedChanged(object sender, EventArgs e)
        {
            if (_sourcePath != null && _destinationPath != null)
            {
                if (cbFileSysWatc.Checked)
                {
                    if (selectedAlgorithm.Equals("rc4"))
                    {
                        bool setovano = Set();

                        

                        if (!setovano)
                        {
                            MessageBox.Show("Unesite kljuc");
                             cbFileSysWatc.Checked = false;
                             return;
                        }
                    }
                    else if (selectedAlgorithm.Equals("rsa"))
                    {
                        bool setovano = SetRSA();

                        if (!setovano)
                        {
                            MessageBox.Show("Unesite kljuc");
                            cbFileSysWatc.Checked = false;
                            return;
                        }
                    }
                    else if (selectedAlgorithm.Equals("a5_2"))
                    {
                        bool setovano = SetA5_2();

                        if (!setovano)
                        {
                            MessageBox.Show("Unesite kljuc");
                            cbFileSysWatc.Checked = false;
                            return;
                        }
                    }
                    
                  

                    fileSystemWatcher1.EnableRaisingEvents = true;
                    _SysWatcherChecking();

                    newThread = new System.Threading.Thread(chiper);
                    newThread.Start();
                }
                else
                {
                    fileSystemWatcher1.EnableRaisingEvents = false;
                    if(newThread!=null)
                         newThread.Abort();
                }
            }
            else
            {
                if (cbFileSysWatc.Checked)
                {
                    MessageBox.Show("Unesite izvorni i odredisni folder");
                    cbFileSysWatc.Checked = false;
                }
            }
            
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
           // FileInfo fi = new FileInfo(e.FullPath);
            //fi.LastAccessTime = DateTime.Now;
            _SysWatcherChecking();
          // MessageBox.Show("Dotat novi file"+e.FullPath);
        }

        private void CryptTiger(string file)
        {
            byte[] tmp = ReadBIN(file);
            byte[] res = proxy.TigerHash(tmp); 
            ///////////
            byte[] pom = new byte[8];
            String r = "";
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    pom[i] = res[i + j * 8];
                }

                ulong p1 = BitConverter.ToUInt64(pom, 0);
                //ulong p1 = Convert.ToUInt64(pu);
                String rpom = p1.ToString();
                r = r + rpom;
                //j++;
            }

            // String rezultat = System.Text.Encoding.ASCII.GetString(r);

           // this.tbxRSAResult.Text = r;
            ////////////

            string[] path = file.Split('\\');
            string newName = path.Last();
            string newPath = _destinationPath + "\\" + newName;

            System.IO.File.WriteAllText(newPath, r);
        }

        private void chiper()
        {
            while (_tread)
            {
                if (rbCrypt.Checked)
                {
                    if (!queue.isEmpty())
                    {
                        string file = null;
                        lock (queue)
                        {
                            file = queue.getFromQueue();
                        }

                        string[] path = file.Split('\\');
                        string newName = path.Last() + ".crypt";
                        string newPath = _destinationPath + "\\" + newName;

                        bool tg = false;

                        if ((DateTime.Compare(File.GetLastWriteTime(file), File.GetLastWriteTime(newPath)) > 0) || !File.Exists(newPath))
                        {
                             bool setovano = false ;
                             if (selectedAlgorithm.Equals("rc4"))
                             {
                                 setovano = Set();
                             }
                             else if (selectedAlgorithm.Equals("rsa"))
                             {
                                 setovano = SetRSA();
                             }
                             else if (selectedAlgorithm.Equals("a5_2"))
                             {
                                 setovano = SetA5_2();
                             }

                             if (selectedAlgorithm.Equals("tiger"))
                             {
                                 CryptTiger(file);
                                 tg = true;
                             }
                         
                            // Key
                            if (!setovano)
                            {
                                MessageBox.Show("Unesite kljuc");
                               // cbFileSysWatc.Checked = false;
                            }
                            else
                            {
                            

                                byte[] tmp = ReadBIN(file);

                                if(checkBoxTigerHash.Checked)
                                {
                                    tmp=tmp.Concat(proxy.TigerHash(tmp)).ToArray();
                                }

                                byte[] tmpDeo;
                                byte[] cryptedMsgDeo;

                                byte[] cryptedMsg = { };

                                int velicinaPaketa = 4000;
                                int brCelih = tmp.Length / velicinaPaketa;

                                for (int i = 0; i < brCelih; i++)
                                {
                                    tmpDeo = tmp.Skip(i * velicinaPaketa).Take(velicinaPaketa).ToArray();
                                    if (selectedAlgorithm.Equals("rc4"))
                                    {
                                        if(this.checkBoxCTR.Checked)
                                        {
                                            cryptedMsgDeo = proxy.RC4CryptCTR(tmpDeo);
                                        }
                                        else
                                        {
                                            cryptedMsgDeo = proxy.RC4Crypt(tmpDeo);
                                        }
                                         
                                    }
                                    else if (selectedAlgorithm.Equals("rsa"))
                                    {
                                        if(this.checkBoxRSACTR.Checked)
                                        {
                                            cryptedMsgDeo = proxy.RSACryptCTR(tmpDeo);
                                        }
                                        else
                                        {
                                            cryptedMsgDeo = proxy.RSACrypt(tmpDeo);
                                        }
                                        
                                    }
                                    else //if (selectedAlgorithm.Equals("a5_2"))
                                    {
                                        cryptedMsgDeo = proxy.A5_2Crypt(tmpDeo);
                                    }
                                   
                                    
                                   
                                    
                                    

                                    cryptedMsg = cryptedMsg.Concat(cryptedMsgDeo).ToArray();

                                }

                                if (tmp.Length % velicinaPaketa != 0)
                                {
                                    tmpDeo = tmp.Skip(brCelih * velicinaPaketa).Take(tmp.Length - brCelih * velicinaPaketa).ToArray();
                                    if (selectedAlgorithm.Equals("rc4"))
                                    {
                                        if (this.checkBoxCTR.Checked)
                                        {
                                            cryptedMsgDeo = proxy.RC4CryptCTR(tmpDeo);
                                        }
                                        else
                                        {
                                            cryptedMsgDeo = proxy.RC4Crypt(tmpDeo);
                                        }
                                    }
                                    else if (selectedAlgorithm.Equals("rsa"))
                                    {
                                        if (this.checkBoxRSACTR.Checked)
                                        {
                                            cryptedMsgDeo = proxy.RSACryptCTR(tmpDeo);
                                        }
                                        else
                                        {
                                            cryptedMsgDeo = proxy.RSACrypt(tmpDeo);
                                        }
                                    }
                                    else //if (selectedAlgorithm.Equals("a5_2"))
                                    {
                                        cryptedMsgDeo = proxy.A5_2Crypt(tmpDeo);
                                    }
                                    

                                    //cryptedMsgDeo = proxy.RC4Crypt(tmpDeo);
                                    //cryptedMsgDeo = proxy.RSACrypt(tmpDeo);
                                   // cryptedMsgDeo = proxy.A5_2Crypt(tmpDeo);

                                    cryptedMsg = cryptedMsg.Concat(cryptedMsgDeo).ToArray();
                                }

                              //  MessageBox.Show("Kriptovan je file: " + newPath);



                                System.IO.File.WriteAllBytes(newPath, cryptedMsg);
                            }
                            
                        }


                    }
                }
                if(rbDecrypt.Checked)
                {
                    if (!queue.isEmpty())
                    {
                        string file = null;
                        lock (queue)
                        {
                            file = queue.getFromQueue();
                        }

                        string[] path = file.Split('\\');
                        string fileName = path.Last();
                        string[] n = fileName.Split('.');

                        //MessageBox.Show(n.Last());

                        if(n.Last().Equals("crypt"))
                        {
                           
                            string newName = "";

                            for (int i = 0; i < n.Length - 2; i++)
                            {
                                newName +=n[i]+'.';
                            }
                            newName+=n[n.Length-2];
                            string newPath = _destinationPath + "\\" + newName;
                           
                            if (!File.Exists(newPath)) //(DateTime.Compare(File.GetLastWriteTime(file), File.GetLastWriteTime(newPath)) > 0) ||
                            {

                                bool setovano = false;
                                if (selectedAlgorithm.Equals("rc4"))
                                {
                                    setovano = Set();
                                }
                                else if (selectedAlgorithm.Equals("rsa"))
                                {
                                    setovano = SetRSA();
                                }
                                else if (selectedAlgorithm.Equals("a5_2"))
                                {
                                    setovano = SetA5_2();
                                }

                                // Key
                                if (!setovano)
                                {
                                    MessageBox.Show("Unesite kljuc");
                                    // cbFileSysWatc.Checked = false;
                                }
                                else
                                {
                                   

                                    byte[] tmp = ReadBIN(file);

                                    byte[] tmpDeo;
                                    byte[] cryptedMsgDeo;

                                    byte[] cryptedMsg = { };

                                    int velicinaPaketa = 64000;

                                    int brCelih = tmp.Length / velicinaPaketa;

                                    for (int i = 0; i < tmp.Length / velicinaPaketa; i++)
                                    {
                                        tmpDeo = tmp.Skip(i * velicinaPaketa).Take(velicinaPaketa).ToArray();

                                        if (selectedAlgorithm.Equals("rc4"))
                                        {
                                            if(this.checkBoxCTR.Checked)
                                            {
                                                cryptedMsgDeo = proxy.RC4DecryptCTR(tmpDeo);
                                            }
                                            else
                                            {
                                                cryptedMsgDeo = proxy.RC4Decrypt(tmpDeo);
                                            }
                                            
                                        }
                                        else if (selectedAlgorithm.Equals("rsa"))
                                        {
                                            if (this.checkBoxRSACTR.Checked)
                                            {
                                                cryptedMsgDeo = proxy.RSADecryptCTR(tmpDeo);
                                            }
                                            else
                                            {
                                                cryptedMsgDeo = proxy.RSADecrypt(tmpDeo);
                                            }
                                            
                                        }
                                        else //if (selectedAlgorithm.Equals("a5_2"))
                                        {
                                            cryptedMsgDeo = proxy.A5_2Decrypt(tmpDeo);
                                        }
                                        //cryptedMsgDeo = proxy.RC4Decrypt(tmpDeo);
                                        //cryptedMsgDeo = proxy.RSADecrypt(tmpDeo);
                                        //cryptedMsgDeo = proxy.A5_2Decrypt(tmpDeo);

                                        cryptedMsg = cryptedMsg.Concat(cryptedMsgDeo).ToArray();

                                    }

                                    if (tmp.Length % velicinaPaketa != 0)
                                    {
                                        tmpDeo = tmp.Skip(brCelih * velicinaPaketa).Take(tmp.Length - brCelih * velicinaPaketa).ToArray();
                                        if (selectedAlgorithm.Equals("rc4"))
                                        {
                                            if (this.checkBoxCTR.Checked)
                                            {
                                                cryptedMsgDeo = proxy.RC4DecryptCTR(tmpDeo);
                                            }
                                            else
                                            {
                                                cryptedMsgDeo = proxy.RC4Decrypt(tmpDeo);
                                            }
                                        }
                                        else if (selectedAlgorithm.Equals("rsa"))
                                        {
                                            if (this.checkBoxRSACTR.Checked)
                                            {
                                                cryptedMsgDeo = proxy.RSADecryptCTR(tmpDeo);
                                            }
                                            else
                                            {
                                                cryptedMsgDeo = proxy.RSADecrypt(tmpDeo);
                                            }
                                        }
                                        else //if (selectedAlgorithm.Equals("a5_2"))
                                        {
                                            cryptedMsgDeo = proxy.A5_2Decrypt(tmpDeo);
                                        }
                                        //cryptedMsgDeo = proxy.RC4Crypt(tmpDeo);
                                        //cryptedMsgDeo = proxy.RSADecrypt(tmpDeo);
                                       // cryptedMsgDeo = proxy.A5_2Decrypt(tmpDeo);

                                        cryptedMsg = cryptedMsg.Concat(cryptedMsgDeo).ToArray();
                                    }

                                  //  MessageBox.Show("Dekriptovan je file: " + newPath);

                                    System.IO.File.WriteAllBytes(newPath, cryptedMsg);
                                }
                            }
                            
                        }

                       


                    }

                }
            }
        }


        private byte[] ReadBIN(string path)
        {
            byte[] array = File.ReadAllBytes(path);

            //string ret = "";
            //for (int i = 0; i < array.Length; i++)
            //{
            //    string result = Convert.ToString(array[i], 2).PadLeft(8, '0');
            //    ret = ret + result;
            //}

            /* BitArray ba = new BitArray(array); //109 - 0110 1101 napise kao 1011 0110
             for (int i = 0; i < ba.Count; i++)
             {
                 if (ba.Get(i))
                     ret += "1";
                 else
                     ret += "0";
             }*/
            return array;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //if (rbCrypt.Checked)
            //{
            //    if (this._sourcePath != null)
            //    {
            //        string[] dirs = System.IO.Directory.GetFiles(this._sourcePath, "*.*");

            //        foreach (string f in dirs)
            //        {
            //            queue.addInQueue(f); //f - File path
            //        }
            //    }
            //}
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            byte[] input = System.Text.Encoding.ASCII.GetBytes(this.tbxRSASource.Text);
            byte[] res = System.Text.Encoding.ASCII.GetBytes("");

            if (selectedAlgorithm.Equals("rc4"))
            {
                bool setovano = Set();

                if (!setovano)
                {
                    return;
                   
                }

                if (checkBoxCTR.Checked)
                {
                    res = proxy.RC4DecryptCTR(input);
                }
                else
                {
                    res = proxy.RC4Decrypt(input);
                }
            }
            else if (selectedAlgorithm.Equals("rsa"))
            {
                bool setovano = SetRSA();

                if (!setovano)
                {
                    return;

                }

                if (checkBoxRSACTR.Checked)
                {
                    res = proxy.RSADecryptCTR(input);
                }
                else
                {
                    res = proxy.RSADecrypt(input);
                }
                
            }
            else if (selectedAlgorithm.Equals("a5_2"))
            {
                bool setovano = SetA5_2();

                if (!setovano)
                {
                    return;

                }

                
                input = System.Text.Encoding.Unicode.GetBytes(this.tbxRSASource.Text);
                res = proxy.A5_2Decrypt(input);

                String r = System.Text.Encoding.Unicode.GetString(res);

                this.tbxRSAResult.Text = r;
                return;

            }

            String rezultat = System.Text.Encoding.ASCII.GetString(res);

            this.tbxRSAResult.Text = rezultat;
            
        }

        private void btnRandomKey_Click(object sender, EventArgs e)
        {
            if (selectedAlgorithm.Equals("rc4"))
            {
                byte[] randomKey = proxy.RC4GenerateRandomKey();

                tbxRC4Key.Text = System.Text.Encoding.ASCII.GetString(randomKey);
            }
            else if (selectedAlgorithm.Equals("a5_2"))
            {
               // MessageBox.Show("random key");
                this.keyA5 = proxy.A5_2GenerateRandomKey();
               // byte[] randomKey = proxy.A5_2GenerateRandomKey();

                this.tbxA5Key.Text = System.Text.Encoding.ASCII.GetString(keyA5);
            }
        }

       

        private void btnSourcePath_Click(object sender, EventArgs e)
        {
            btnUpload.Enabled = true;

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {

                _sourcePath = fbd.SelectedPath;

                fileSystemWatcher1.Path = _sourcePath;
            }
        }
        private void upload()
        {
            while (_tread)
            {
               // if (rbCrypt.Checked)
                {
                    //MessageBox.Show("Start upload");
                    if (!queue.isEmpty())
                    {
                        
                        string file = null;
                        lock (queue)
                        {
                            file = queue.getFromQueue();
                        }

                        string[] path = file.Split('\\');
                        string newName = path.Last();// +".crypt";
                       // string newPath = _destinationPath + "\\" + newName;
                        string[] n;
                        string n2;

                        bool uploadovan = false;
                        string[] s = proxy.GetFiles();
                        foreach(string fileName in s)
                        {
                            n = fileName.Split('.');
                            n2 = n[0] +"."+ n[1];
                            if(n2.Equals(newName))
                            {
                                uploadovan = true;
                               // MessageBox.Show("Vec postoji "+ n2+" - "+newName);
                            }
                        }

                        if (!uploadovan)
                        {
                            string al="x";

                            bool setovano = false;
                            if (selectedAlgorithm.Equals("rc4"))
                            {
                                setovano = Set();
                                if (checkBoxCTR.Checked)
                                {
                                    al = "rc4CTR";
                                }
                                else
                                {
                                    al = "rc4";
                                }
                                
                            }
                            else if (selectedAlgorithm.Equals("rsa"))
                            {
                                setovano = SetRSA();
                                if (checkBoxRSACTR.Checked)
                                {
                                    al = "rsaCTR";
                                }
                                else
                                {
                                    al = "rsa";
                                }
                                
                            }
                            else if (selectedAlgorithm.Equals("a5_2"))
                            {
                                setovano = SetA5_2();
                                al = "a5_2";
                            }

                            //if (selectedAlgorithm.Equals("tiger"))
                            //{
                            //   // CryptTiger(file);
                            //    al = "tiger";
                            //   // tg = true;
                            //}

                            // Key
                            if (!setovano)
                            {
                                MessageBox.Show("Unesite kljuc");
                                cbFileSysWatc.Checked = false;
                            }
                            else
                            {
                                
                                byte[] tmp = ReadBIN(file);

                                if (checkBoxTigerHash.Checked)
                                {
                                    tmp = tmp.Concat(proxy.TigerHash(tmp)).ToArray();
                                }

                                byte[] tmpDeo;
                                byte[] cryptedMsgDeo;

                                byte[] cryptedMsg = { };

                                int velicinaPaketa = 4000;
                                int brCelih = tmp.Length / velicinaPaketa;

                                ////
                               // string al = "rc4";
                                byte[] algoritam = System.Text.Encoding.ASCII.GetBytes(al);
                                int brP = brCelih;
                                if (tmp.Length % velicinaPaketa != 0)
                                    brP++;
                                //MessageBox.Show("Broj paketa: "+brP);
                                byte[] brPaketa = System.Text.Encoding.ASCII.GetBytes(""+brP);
                                byte[] name = System.Text.Encoding.ASCII.GetBytes(newName);

                                ////
                                proxy.Upload(name);
                                proxy.Upload(algoritam);
                                proxy.Upload(brPaketa);
                                ///

                                for (int i = 0; i < brCelih; i++)
                                {
                                    tmpDeo = tmp.Skip(i * velicinaPaketa).Take(velicinaPaketa).ToArray();
                                   // MessageBox.Show("Sadrzaj paketa " + i + Convert.ToInt32(System.Text.Encoding.ASCII.GetString(tmpDeo)));
                                   // cryptedMsgDeo = proxy.Upload(tmpDeo);
                                    proxy.Upload(tmpDeo);

                                   // cryptedMsg = cryptedMsg.Concat(cryptedMsgDeo).ToArray();

                                }

                                if (tmp.Length % velicinaPaketa != 0)
                                {
                                    tmpDeo = tmp.Skip(brCelih * velicinaPaketa).Take(tmp.Length - brCelih * velicinaPaketa).ToArray();
                                   // cryptedMsgDeo = proxy.RC4Crypt(tmpDeo);
                                   // MessageBox.Show("Sadrzaj paketa (d) " + System.Text.Encoding.ASCII.GetString(tmpDeo));
                                   
                                    proxy.Upload(tmpDeo);
                                   // cryptedMsg = cryptedMsg.Concat(cryptedMsgDeo).ToArray();
                                }

                               // MessageBox.Show("Uploadovan je file: " + newName);



                               // System.IO.File.WriteAllBytes(newPath, cryptedMsg);
                            }

                        }


                    }
                    else
                    {
                       // return;
                    }
                }
                
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            
            if(!Validate())
            {
                return;
            }

            fileSystemWatcher1.EnableRaisingEvents = true;
            _SysWatcherChecking();

            newThread = new System.Threading.Thread(upload);
            newThread.Start();
            
        }

        private void btnGet_Click(object sender, EventArgs e)
        {

            //string[] s = { "file 1", "file 2", "file 3" };
             string[] s = proxy.GetFiles();
            listBox1.DataSource = s.ToList();
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedValue == null)
                return;

            String fileName = listBox1.SelectedValue as String;
           // MessageBox.Show(fileName);
            proxy.DeleteFile(fileName);
            btnGet_Click(sender,e);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedValue == null)
                return;
            String fileName = listBox1.SelectedValue as String;

            ////////////////
            string[] n = fileName.Split('.');
            string name=n[0] +"."+ n[1];
            ////////////////

            bool setovano = false;
            String al = "x";
            if (selectedAlgorithm.Equals("rc4"))
            {
                setovano = Set();
                if(this.checkBoxCTR.Checked)
                {
                    al = "rc4CTR";
                }
                else
                {
                    al = "rc4";
                }
                
            }
            else if (selectedAlgorithm.Equals("rsa"))
            {
                setovano = SetRSA();
                if(this.checkBoxRSACTR.Checked)
                {
                    al = "rsaCTR";
                }
                else
                {
                    al = "rsa";
                }
                
            }
            else if (selectedAlgorithm.Equals("a5_2"))
            {
                setovano = SetA5_2();
                al = "a5_2";
            }

            if (selectedAlgorithm.Equals("tiger"))
            {
                //CryptTiger(file);
                al = "tiger";
                // tg = true;
            }

            if (setovano)
            {

                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {

                    string DownloadPath = fbd.SelectedPath;

                    byte[] o = proxy.Download(fileName, al);
                    int brPaketa = Convert.ToInt32(System.Text.Encoding.ASCII.GetString(o));
                  //  MessageBox.Show("Broj paketa:" + brPaketa);
                    byte[] tmpDeo;
                    byte[] decryptedMsgDeo;
                    byte[] decryptedMsg = { };

                    for (int i = 0; i < brPaketa; i++)
                    {
                        decryptedMsgDeo = proxy.Download(fileName, al);
                        decryptedMsg = decryptedMsg.Concat(decryptedMsgDeo).ToArray();
                    }


                    System.IO.File.WriteAllBytes(DownloadPath + "\\" + name, decryptedMsg);
                    MessageBox.Show("Downloadovan file: " + DownloadPath + "\\" + name);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedValue == null)
                return;

            String fileName = listBox1.SelectedValue as String;
            string[] n = fileName.Split('.');
            string newName = n[0]+"."+n[1];

            bool setovano = Set();

            if (setovano)
            {

                //FolderBrowserDialog fbd = new FolderBrowserDialog();
                OpenFileDialog fbd = new OpenFileDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {

                    string FilePath = fbd.FileName;

                   
                    ///////////

                    byte[] tmp = ReadBIN(FilePath);

                    byte[] tmpDeo;
                    byte[] cryptedMsgDeo;

                    byte[] cryptedMsg = { };

                    int velicinaPaketa = 4000;
                    int brCelih = tmp.Length / velicinaPaketa;

                    ////
                    string al = "rc4";
                    byte[] algoritam = System.Text.Encoding.ASCII.GetBytes(al);
                    int brP = brCelih;
                    if (tmp.Length % velicinaPaketa != 0)
                        brP++;
                    //MessageBox.Show("Broj paketa: "+brP);
                    byte[] brPaketa = System.Text.Encoding.ASCII.GetBytes("" + brP);
                    byte[] name = System.Text.Encoding.ASCII.GetBytes(newName);

                    ////
                    proxy.Upload(name);
                    proxy.Upload(algoritam);
                    proxy.Upload(brPaketa);
                    ///

                    for (int i = 0; i < brCelih; i++)
                    {
                        tmpDeo = tmp.Skip(i * velicinaPaketa).Take(velicinaPaketa).ToArray();
                        proxy.Upload(tmpDeo);
                    }

                    if (tmp.Length % velicinaPaketa != 0)
                    {
                        tmpDeo = tmp.Skip(brCelih * velicinaPaketa).Take(tmp.Length - brCelih * velicinaPaketa).ToArray();
                        proxy.Upload(tmpDeo);
                    }
                    ///////////

                   
                    MessageBox.Show("Updatovan file: " + fileName + "sa adrese" + FilePath);
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageRC4"])
            {
                this.selectedAlgorithm = "rc4";
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageRSA"])
            {
                this.selectedAlgorithm = "rsa";
                
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabPageA5"])
            {
                this.selectedAlgorithm = "a5_2";
                
            }
            else if (tabControl1.SelectedTab == tabControl1.TabPages["tabTigerHash"])
            {
                this.selectedAlgorithm = "tiger";

            }
        }

        private void checkBoxCTR_CheckedChanged(object sender, EventArgs e)
        {
            tbxIV.Enabled = !tbxIV.Enabled;
        }

        private void btnRandomIV_Click(object sender, EventArgs e)
        {
            this.ivA5 = proxy.RC4GenerateRandomIV();
           // byte[] randomIV = proxy.RC4GenerateRandomIV();

            this.tbxIV.Text = System.Text.Encoding.ASCII.GetString(ivA5);
        }

        private void checkBoxRSACTR_CheckedChanged(object sender, EventArgs e)
        {
            this.tbxRSAIV.Enabled = !tbxRSAIV.Enabled;
        }

        private void btnRSARandomIV_Click(object sender, EventArgs e)
        {
            byte[] randomIV = proxy.RSAGenerateRandomIV();

            this.tbxRSAIV.Text = System.Text.Encoding.ASCII.GetString(randomIV);
        }

        private void btnA5RandomIV_Click(object sender, EventArgs e)
        {
            this.ivA5 = proxy.A5_2GenerateRandomIV();

            this.tbxA5IV.Text = System.Text.Encoding.ASCII.GetString(ivA5);
        }

        private void btnTigetHash_Click(object sender, EventArgs e)
        {
            byte[] input = System.Text.Encoding.ASCII.GetBytes(this.tbxRSASource.Text);
            byte[] res = proxy.TigerHash(input);

            //MessageBox.Show(res.Count().ToString());
            byte[] pom = new byte[8];
            String r = "";
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    pom[i] = res[i + j*8];
                }

                ulong p1 = BitConverter.ToUInt64(pom,0);
                //ulong p1 = Convert.ToUInt64(pu);
                String rpom= p1.ToString();
                r = r + rpom;
                //j++;
            }

           // String rezultat = System.Text.Encoding.ASCII.GetString(r);

            this.tbxRSAResult.Text = r;
        }

        
    }
}

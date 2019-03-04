using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfCryptoService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICryptoService" in both code and config file together.
    [ServiceContract]
    public interface ICryptoService
    {
        //////RSA-------------------------------------------------------

        [OperationContract]
        byte[] RSACrypt(byte[] input);

        [OperationContract]
        byte[] RSADecrypt(byte[] input);

        [OperationContract]
        byte[] RSACryptCTR(byte[] input);

        [OperationContract]
        byte[] RSADecryptCTR(byte[] input);

        [OperationContract]
        bool RSASetIV(byte[] input);

        [OperationContract]
        byte[] RSAGenerateRandomIV();

        [OperationContract]
        bool RSASetAlgorithmProperties(IDictionary<string, byte[]> specArguments); 

        //////end RSA-------------------------------------------------------


        ///////RC4------------------------------------------------------

        [OperationContract]
        byte[] RC4Crypt(byte[] input);

        [OperationContract]
        byte[] RC4CryptCTR(byte[] input);

        [OperationContract]
        byte[] RC4Decrypt(byte[] input);

        [OperationContract]
        byte[] RC4DecryptCTR(byte[] input); 

        [OperationContract]
        bool RC4SetKey(byte[] input);

        [OperationContract]
        byte[] RC4GenerateRandomKey();

        [OperationContract]
        bool RC4SetIV(byte[] input);

        [OperationContract]
        byte[] RC4GenerateRandomIV();

        [OperationContract]
        bool RC4SetAlgorithmProperties(IDictionary<string, byte[]> specArguments);

        ////////end RC4--------------------------------------------------

        ////////A5/2-----------------------------------------------------

        [OperationContract]
        byte[] A5_2Crypt(byte[] input);

        [OperationContract]
        byte[] A5_2Decrypt(byte[] input);

        [OperationContract]
        bool A5_2SetKey(byte[] input);

        [OperationContract]
        byte[] A5_2GenerateRandomKey();

        [OperationContract]
        bool A5_2SetIV(byte[] input);

        [OperationContract]
        byte[] A5_2GenerateRandomIV(); 

        ////////A5/2-----------------------------------------------------

        ////////tiger hash-----------------------------------------------------

        [OperationContract]
        byte[] TigerHash(byte[] input); 

        ////////end tiger hash-----------------------------------------------------


        /////Cloud
        [OperationContract]
        void Upload(byte[] input);

        [OperationContract]
        byte[] Download(string fileName, string al);

        [OperationContract]
        string[] GetFiles();

        [OperationContract]
        void DeleteFile(string name);

        [OperationContract]
        void Update(byte[] input);


    }

}

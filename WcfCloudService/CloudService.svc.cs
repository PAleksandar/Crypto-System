using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Crypto;

namespace WcfCloudService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CloudService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CloudService.svc or CloudService.svc.cs at the Solution Explorer and start debugging.
    public class CloudService : ICloudService
    {

        string filePath = "";

        static RC4 rc4;
        public CloudService()
        {
            if(rc4==null)
            {
                rc4 = new RC4();
            }
        }

        public void Add(byte[] input)
        {
           

        }

        public byte[] Get(string file)
        {
            return null;
        }

        public void Delete(string file)
        {

        }

        public void Update(byte[] input, string file)
        {

        }
    }
}

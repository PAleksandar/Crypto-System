using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfCloudService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICloudService" in both code and config file together.
    [ServiceContract]
    public interface ICloudService
    {
        [OperationContract]
        void Add(byte[] input);

        [OperationContract]
        byte[] Get(string file);

        [OperationContract]
        void Delete(string file);

        [OperationContract]
        void Update(byte[] input, string file);
    }
}

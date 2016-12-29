using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace kr_avt.Servise
{
    [DataContract]
    public class Payment
    {
        [DataMember]
        public string Schet { get; set; }
        
        [DataMember]
        public int Balanse { get; set; }
    }
}

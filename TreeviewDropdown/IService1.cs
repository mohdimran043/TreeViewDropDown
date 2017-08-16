using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TreeviewDropDown
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetAllItems")]
        List<DllItem> GetAllItems();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "GetAllTreeviewItems")]
        List<TreeItem> GetAllTreeviewItems();
    }

    [DataContract]
    public class Items
    {
        [DataMember]
        public List<DllItem> ItemList { get; set; }
    }

    [DataContract]
    public class DllItem
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Int32 ID { get; set; }
        
    }

    [DataContract]
    public class TreeItem
    {
        [DataMember]
        public string text { get; set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public bool expanded { get; set; }
        [DataMember]
        public List<MyItem> items { get; set; }
    }

    [DataContract]
    public class MyItem
    {
        [DataMember]
        public string text { get; set; }
        [DataMember]
        public string id { get; set; }
        
    }
}

using System.Runtime.Serialization;

namespace MVC_Core.Client
{
    [DataContract]
    public class Message<T>
    {
        [DataMember(Name = "IsSuccess")] 
        public bool IsSuccess {set;get;}

        [DataMember(Name="ReturnMessage")]
        public  string ReturnMessage {set; get;}
        
        [DataMember(Name="Data")]
        public T Data {set; get;}
    }
}
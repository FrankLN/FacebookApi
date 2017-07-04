using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FacebookRestApiConnector
{
    [DataContract]
    public class FbAccount
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public Picture picture { get; set; }
        [DataMember]
        public Friend friends { get; set; }
        [DataMember]
        public Post posts { get; set; }
        [DataMember]
        public Photo photos { get; set; }
    }

    [DataContract]
    public class Photo
    {
        [DataMember]
        public List<PhotoData> data { get; set; }
    }

    [DataContract]
    public class PhotoData
    {
        [DataMember]
        public string picture { get; set; }
        [DataMember]
        public string id { get; set; }
    }

    [DataContract]
    public class Post
    {
        [DataMember]
        public List<PostData> data { get; set; }
    }

    [DataContract]
    public class PostData
    {
        [DataMember]
        public string message { get; set; }
        [DataMember]
        public string created_time { get; set; }
    }

    [DataContract]
    public class Picture
    {
        [DataMember]
        public Data data { get; set; }
    }

    [DataContract]
    public class Data
    {
        [DataMember]
        public string url { get; set; }
    }

    [DataContract]
    public class Friend
    {
        [DataMember]
        public List<FriendData> data { get; set; }
    }

    [DataContract]
    public class FriendData
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public Picture picture { get; set; }
    }

}

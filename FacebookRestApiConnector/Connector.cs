using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace FacebookRestApiConnector
{
    public class Connector
    {
        private string token;
        private string baseUrl;

        public Connector(string token, string baseUrl)
        {
            this.token = token;
            this.baseUrl = baseUrl;
        }

        public FbAccount Request(string request)
        {
            FbAccount result;
            
            result = SendRequest(baseUrl + request + "&access_token=" + token);
            
            return result;
        }


        private FbAccount SendRequest(string requestUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(requestUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);

            var bytes = readStream.ReadToEnd();

            MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(bytes));
            DataContractJsonSerializer dj = new DataContractJsonSerializer(typeof(FbAccount));
            FbAccount result = (FbAccount)dj.ReadObject(stream);

            response.Close();
            readStream.Close();

            return result;
        }
    }
}
